"""
Server MCP — Ricerca raffinata nel vector store SIARB

Espone il tool search_rag usato dall'agente ReAct quando il retrieve
iniziale non produce chunk sufficienti.

Viene avviato come sottoprocesso stdio da react_agent.mcp_search()
— non è necessario lanciarlo manualmente.

Per testarlo in isolamento:
    python rag/mcp_rag_server.py
"""

import json
import sys
from pathlib import Path

import chromadb
from mcp.server.fastmcp import FastMCP

BASE_DIR = Path(__file__).parent.parent   # esempio_completo/
KB_PATH  = BASE_DIR / "vdb"

# Aggiunge esempio_completo/ al path per importare config e rag.embeddings
sys.path.insert(0, str(BASE_DIR))
from rag.embeddings import OllamaEmbeddingFunction  # noqa: E402

mcp = FastMCP("rag-search")


@mcp.tool()
def search_rag(query: str, top_k: int = 5) -> str:
    """
    Cerca nel database vettoriale del manuale SIARB con una query raffinata.

    Args:
        query:  Query ottimizzata rispetto alla domanda originale
        top_k:  Numero massimo di chunk da restituire
    """
    try:
        client = chromadb.PersistentClient(path=str(KB_PATH))
        coll   = client.get_collection("siarb_kb", embedding_function=OllamaEmbeddingFunction())
        n      = min(top_k, coll.count())
        res    = coll.query(query_texts=[query], n_results=n)
        return json.dumps(res["documents"][0], ensure_ascii=False)
    except Exception as e:
        print(f"[MCP] Errore: {e}", file=sys.stderr)
        return json.dumps([])


if __name__ == "__main__":
    mcp.run(transport="stdio")
