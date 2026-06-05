from typing import Sequence, Collection

import ollama
import chromadb
import pymupdf4llm
from langchain_text_splitters import MarkdownTextSplitter


#region CONFIG
DB_PATH = "./rag_vdb"
CLEAR_DB = False

MODEL = ["all-minilm:latest", "all-minilm:33m"][0]
FILE_PDF = "./Manuale_Gestione_SIARB.pdf"


N_CHUNKS = 5 # chunk da recuperare durante la query
CHAT_MODEL = "ministral-3:3b"
#endregion

#region CREAZIONE KNOWLEDGE BASE
def init_db(db_path: str, clear_db: bool = False) -> Collection:
    db = chromadb.PersistentClient(path="./rag_vdb")  # CREA DB PERSISTENTE
    if clear_db:
        try:
            db.delete_collection("collection")
            print("DB azzerato")
        except:
            print("impossibile azzerare DB")

    collection : Collection = db.get_or_create_collection(
        name="collection",
        # metadata={"description": "Prima collection di test"}
    )
    print(f"dimensione knowledge base: {collection.count()}")
    return collection

def gen_embedding(file_path: str) -> list[tuple[str, Sequence[float]]]:
    CHUNK_SIZE = 1000  # 1000 (MAX 322?)
    CHUNK_OVERLAP = 200  # 200
    md_text = pymupdf4llm.to_markdown(FILE_PDF)
    splitter = MarkdownTextSplitter(chunk_size=CHUNK_SIZE, chunk_overlap=CHUNK_OVERLAP)

    results = list()

    chunks_list = splitter.split_text(md_text)
    embeddings_list = list()

    i: int = 0
    while i < len(chunks_list):
        cur_chunk = chunks_list[i]
        print(f"processando chunk {i + 1}/{len(chunks_list)}...")

        # try to generate embedding
        try:
            embedding: Sequence[float] = ollama.embed(model=MODEL, input=cur_chunk).embeddings[0]

        # if failed split chunk, try again
        except:
            print("embedding fallito")
            print(f"dimensioni chunk: {len(cur_chunk)}")
            chunk_size = len(cur_chunk) / 2
            chunk_overlap = chunk_size / 5

            chunk_splitter = MarkdownTextSplitter(chunk_size=chunk_size, chunk_overlap=chunk_overlap)
            subchunk_list = chunk_splitter.split_text(cur_chunk)

            chunks_list[i:i+1] = subchunk_list
            continue

        # if succeded go to next
        embeddings_list.append(embedding)
        results.append((cur_chunk, embedding))
        i += 1
    print("embedding generati")


    return results


collection = init_db(DB_PATH, CLEAR_DB)

if collection.count() == 0:
    chunk_embeddings = gen_embedding(FILE_PDF)

    for i, (chunk, embedding) in enumerate(chunk_embeddings):
        collection.add(
                embeddings=[embedding],
                documents=[chunk],
                metadatas=[{"chunk_index": i, "source": FILE_PDF}],
                ids=[f"chunk_{i}"]
            )
    print(f"\nKnowledge base pronta: {collection.count()} chunk indicizzati")
#endregion


#region QUERIES
queries = [
    "Quali moduli compongono la sezione UMA del sistema?",
    "Come funziona la gestione dei bandi regionali?",
    "Quali procedure amministrative gestisce il comparto fitosanitario?",
    "Come si richiedono gli indennizzi per danni da calamità naturali?"
]

# domanda > embedding > chromaDB > contesto prompt > risposta basata SOLO sul contesto

for query in queries:
    print(f"Domanda: {query}\n")
    query_embedding = ollama.embed(model=MODEL, input=query).embeddings[0]

    risultati = collection.query(
        query_embeddings=[query_embedding],
        n_results=N_CHUNKS
    )

    chunk_recuperati = risultati['documents'][0]
    distanze = risultati['distances'][0]

    print(f"Chunk recuperati (top {N_CHUNKS}):")
    for i, (chunk, dist) in enumerate(zip(chunk_recuperati, distanze), 1):
        print(f"  [{i}] dist={dist:.3f} → {chunk.replace(chr(10), ' ')}")

    contesto = "\n\n---\n\n".join(chunk_recuperati)

    prompt = \
f"""Sei un assistente esperto. Rispondi alla domanda basandoti ESCLUSIVAMENTE sul contesto fornito.
Se la risposta non è nel contesto, rispondi: "Non ho informazioni sufficienti nel documento."
    
CONTESTO:
{contesto}

DOMANDA:
{query}

RISPOSTA:"""

    print(f"\nRisposta ({CHAT_MODEL}):")
    response = ollama.chat(
        model=CHAT_MODEL,
        messages=[{"role": "user", "content": prompt}]
    )

    risposta = response.message.content
    print(risposta)

#endregion