"""
Knowledge Base — caricamento PDF e vector store ChromaDB.

Responsabilita:
  - Estrarre testo dal PDF con pymupdf4llm (output markdown per pagina).
  - Suddividere ogni pagina in chunk per paragrafo (min MIN_CHUNK_CHARS caratteri).
  - Indicizzare i chunk in ChromaDB con embedding all-minilm via Ollama.
  - Esporre setup_kb() e retrieve() usati da app.py e dal server MCP.
"""

import pymupdf4llm
import chromadb

from config import MANUAL_PATH, KB_PATH
from rag.embeddings import OllamaEmbeddingFunction

MIN_CHUNK_CHARS = 80


def _get_collection() -> chromadb.Collection:
    client = chromadb.PersistentClient(path=str(KB_PATH))
    return client.get_or_create_collection("siarb_kb", embedding_function=OllamaEmbeddingFunction())


def setup_kb() -> chromadb.Collection:
    """
    Inizializza la knowledge base dal PDF.
    Se gia esistente (chunk > 0) la restituisce senza ricaricare.
    """
    coll = _get_collection()

    if coll.count() > 0:
        print(f"Knowledge base pronta ({coll.count()} chunk).")
        return coll

    print("Indicizzazione manuale in corso...")
    ids, docs, metas = [], [], []

    pages = pymupdf4llm.to_markdown(str(MANUAL_PATH), page_chunks=True)
    for page in pages:
        page_num = page["metadata"]["page_number"]
        paras = [p.strip() for p in page["text"].split("\n\n") if len(p.strip()) >= MIN_CHUNK_CHARS]
        for i, para in enumerate(paras):
            ids.append(f"p{page_num}_c{i}")
            docs.append(para)
            metas.append({"page": page_num})

    if ids:
        coll.add(ids=ids, documents=docs, metadatas=metas)

    print(f"Indicizzati {len(ids)} chunk su {len(set(m['page'] for m in metas))} pagine.")
    return coll


def retrieve(query: str, coll: chromadb.Collection, top_k: int = 5) -> list[str]:
    """Recupera i top_k chunk piu rilevanti per la query."""
    n = min(top_k, coll.count())
    if n == 0:
        return []
    return coll.query(query_texts=[query], n_results=n)["documents"][0]
