import chromadb
from config import *
from utils import gen_embedding, get_collection

db = chromadb.PersistentClient(path="./rag_vdb")

try:
    db.delete_collection("knowledge_base")
    print(f"knowledge_base azzerato")
except:
    print(f"knowledge_base NON azzerato")

try:
    db.delete_collection("chat_memory")
    print(f"chat_memory azzerato")
except:
    print(f"chat_memory NON azzerato")

print("generazione knowledge base")
chunk_embeddings = gen_embedding(FILE_PDF)

knowledge_base = get_collection(db=db, nome="knowledge_base")

for i, (chunk, embedding) in enumerate(chunk_embeddings):
    knowledge_base.add(
        embeddings=[embedding],
        documents=[chunk],
        metadatas=[{"chunk_index": i, "source": FILE_PDF}],
        ids=[f"chunk_{i}"]
    )
print(f"\nKnowledge base pronta: {knowledge_base.count()} chunk indicizzati")
