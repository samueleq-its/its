from typing import Sequence, Collection

import ollama
import chromadb
import pymupdf4llm
from langchain_text_splitters import MarkdownTextSplitter


#region CONFIG
DB_PATH = "./rag_vdb"
CLEAR_DB = True

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

def gen_embedding(chunk_list: list[str], index: int) -> list[Sequence[float]]:
    print(f"processando chunk {index + 1}/{len(chunks_list)}...")
    cur_chunk = chunk_list[index]

    embedding : Sequence[float] | None = None
    try:
        embedding = ollama.embed(model=MODEL, input=cur_chunk).embeddings[0]
        next_index = index + 1
    except: # if it fails, split the chunk
        print("embedding fallito")
        print(f"dimensioni chunk: {len(cur_chunk)}")

        chunk_size = len(cur_chunk) / 2
        chunk_overlap = chunk_size / 5

        chunk_splitter = MarkdownTextSplitter(chunk_size=chunk_size, chunk_overlap=chunk_overlap)
        subchunk_list = chunk_splitter.split_text(cur_chunk)

        chunks_list[index:index+1] = subchunk_list
        next_index = index

    return ([embedding] if embedding else []) + (gen_embedding(chunk_list, next_index) if next_index < len(chunk_list) else [])


collection = init_db(DB_PATH, CLEAR_DB)

if collection.count() == 0:
    # generate embedding
    md_text = pymupdf4llm.to_markdown(FILE_PDF)
    splitter = MarkdownTextSplitter(chunk_size=1000, chunk_overlap=200)
    chunks_list = splitter.split_text(md_text)
    embeddings_list = gen_embedding(chunks_list, 0)

    exit()

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