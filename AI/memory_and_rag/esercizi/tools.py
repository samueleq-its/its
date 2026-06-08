from config import *
from utils import init_db, get_collection, get_embeddings_list

definitions = list()
tools = dict()

definitions.append({
    "type": "function",
    "function": {
        "name": "recupera_informazioni",
        "description": """
            restituisce le informazioni più rilevanti in base alla query
            usa questo strumento ogni volta che l'utente chiede informazioni
        """,
        "parameters": {
            "type": "object",
            "properties": {
                "query": {
                    "type": "string",
                    "description": "le informazioni da ricercare, può essere l'intera domanda dell'utente"
                }
            },
            "required": ["query"]
        }
    }
})
def recupera_informazioni(query: str) -> list[str]:
    db = init_db(DB_PATH)
    collection = get_collection(db, KNOWLEDGE_BASE_NAME)
    return get_embeddings_list(collection=collection, query=query, num_risultati=N_CHUNKS)
tools["recupera_informazioni"] = recupera_informazioni


definitions.append({
    "type": "function",
    "function": {
        "name": "recupera_storico_chat",
        "description": """
            restituisce i messaggi con l'utente più rilevanti in base alla query
            usa questo strumento SOLO quando l'utente richiede di ricordare comunicazioni precedenti
        """,
        "parameters": {
            "type": "object",
            "properties": {
                "query": {
                    "type": "string",
                    "description": "i messaggi da ricercare, può essere l'intera domanda dell'utente"
                }
            },
            "required": ["query"]
        }
    }
})
def recupera_storico_chat(query: str) -> list[str]:
    db = init_db(DB_PATH)
    collection = get_collection(db, CHAT_MEMORY_NAME)
    return get_embeddings_list(collection=collection, query=query, num_risultati=N_CHUNKS)
tools["recupera_storico_chat"] = recupera_storico_chat
