import time
from typing import Sequence
import ollama
import chromadb
import pymupdf4llm
from chromadb import ClientAPI
from chromadb.api.models.Collection import Collection
from langchain_text_splitters import MarkdownTextSplitter
from config import *
from utils import *

#region CONFIG

#endregion


db : ClientAPI # ChromaDB
knowledge_base : Collection
#region RECUPERO KNOWLEDGE BASE


db = init_db(DB_PATH)
knowledge_base = get_collection(db=db, nome="knowledge_base")
print(f"dimensione knowledge base: {knowledge_base.count()}")

#endregion


memoria_chat: Collection
#region RECUPERO MEMORIA CHAT
memoria_chat = get_collection(db=db, nome="chat_memory")
print(f"dimensione memoria chat: {memoria_chat.count()}")

#endregion



query: str # domanda utente
risposta: str # risposta IA
#region QUERIES
query = input("inserisci una domanda per l'assistente IA: ")

contesto = get_embeddings(collection=knowledge_base, query=query, num_risultati=N_CHUNKS)
storico_chat = get_embeddings(collection=memoria_chat, query=query, num_risultati=N_CHUNKS)

prompt = \
f"""
## CONTESTO:
{contesto}

## STORICO CHAT:
{storico_chat}

##DOMANDA:
{query}
"""

print(f"\nRisposta ({CHAT_MODEL}):")
response = ollama.chat(
    model=CHAT_MODEL,
    messages=[{"role": "user", "content": prompt}]
)

risposta = response.message.content
print(risposta)
#endregion


#region SALVATAGGIO MEMORIA CHAT
documento  = f"Utente: {query}\nAssistente: {risposta}"
embedding = ollama.embed(model=EMBEDDING_MODEL, input=documento).embeddings[0]
timestamp = round(time.time() * 100)
memoria_chat.add(
        embeddings=[embedding],
        documents=[documento],
        metadatas=[{"time": timestamp, "anteprima_user": query[:80]}],
        ids=[f"time_{timestamp}"]
    )
#endregion

# TODO: loop di domande, mantenere memoria chat temporanea
# TODO? ai può richiedere storico chat o documento a seconda delle necessità
# TODO: riassunto
# TODO? risposte in JSON