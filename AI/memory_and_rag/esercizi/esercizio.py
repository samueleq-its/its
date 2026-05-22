import ollama
import chromadb
import pymupdf4llm
from langchain_text_splitters import MarkdownTextSplitter

#region CONFIG
USE_PERSISTENT_DB = True
CLEAR_DB = False
MODEL = ["all-minilm:latest", "all-minilm:33m"][0]
FILE_PDF = "./Manuale_Gestione_SIARB.pdf"
CHUNK_SIZE = 322 # 1000 (MAX 322?)
CHUNK_OVERLAP = 75 # 200
N_CHUNKS = 5 # chunk da recuperare durante la query
CHAT_MODEL = "ministral-3:3b"
#endregion

#region CREAZIONE KNOWLEDGE BASE
if USE_PERSISTENT_DB:
    db = chromadb.PersistentClient(path="./rag_vdb") # CREA DB PERSISTENTE
else:
    db = chromadb.Client() # CREA DB IN RAM

if CLEAR_DB:
    try:
        db.delete_collection("collection")
        print("DB azzerato")
    except:
        print("impossibile azzerare DB")

collection = db.get_or_create_collection(
        name="collection",
        # metadata={"description": "Prima collection di test"}
    )
print(f"dimensione knowledge base: {collection.count()}")

if CLEAR_DB or not USE_PERSISTENT_DB:
    md_text = pymupdf4llm.to_markdown(FILE_PDF)
    splitter = MarkdownTextSplitter(chunk_size= CHUNK_SIZE, chunk_overlap=CHUNK_OVERLAP)
    #splitter = RecursiveCharacterTextSplitter(chunk_size=CHUNK_SIZE, chunk_overlap=CHUNK_OVERLAP)
    chunks = splitter.split_text(md_text)
    print(f"Chunk creati: {len(chunks)}")

    # GENERATE EMBEDDING
    chunks_len = len(chunks)
    for i, chunk in enumerate(chunks):
            print(f"processando chunk {i+1}/{chunks_len}...")
            embedding = ollama.embed(model=MODEL, input=chunk).embeddings[0]
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