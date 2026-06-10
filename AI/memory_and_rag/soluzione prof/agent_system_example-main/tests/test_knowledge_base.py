"""
Test per rag/knowledge_base.py

Usa ChromaDB EphemeralClient (in-memory) e Ollama reale per gli embedding.
pymupdf4llm e mockato per non richiedere il PDF.

Richiedono Ollama attivo su localhost:11434 con all-minilm:latest.
"""

import uuid
from unittest.mock import patch

import chromadb
import pytest


@pytest.fixture(scope="module", autouse=True)
def require_ollama():
    from ollama import Client
    try:
        Client(host="http://localhost:11434").list()
    except Exception:
        pytest.skip("Ollama non raggiungibile. Avvialo con: ollama serve")


def _make_page(text: str, page_number: int = 1) -> dict:
    """Costruisce un chunk nel formato restituito da pymupdf4llm.to_markdown(page_chunks=True)."""
    return {
        "text": text,
        "metadata": {"page_number": page_number},
        "toc_items": [],
        "page_boxes": [],
    }


@pytest.fixture()
def fresh_collection(require_ollama):
    """
    Collection ChromaDB in-memory con nome univoco.
    Usa OllamaEmbeddingFunction reale per coerenza con il sistema in produzione.
    """
    from rag.embeddings import OllamaEmbeddingFunction
    client = chromadb.EphemeralClient()
    name = f"test_kb_{uuid.uuid4().hex}"
    return client.get_or_create_collection(name, embedding_function=OllamaEmbeddingFunction())


# Test retrieve()

class TestRetrieve:

    def test_restituisce_lista(self, fresh_collection):
        fresh_collection.add(
            ids=["1", "2"],
            documents=["Il SIARB gestisce i dati agricoli", "Regione Basilicata"],
        )
        from rag.knowledge_base import retrieve
        results = retrieve("SIARB", fresh_collection, top_k=2)
        assert isinstance(results, list)
        assert len(results) == 2

    def test_top_k_rispettato(self, fresh_collection):
        fresh_collection.add(
            ids=[str(i) for i in range(5)],
            documents=[f"documento numero {i} sul sistema SIARB" for i in range(5)],
        )
        from rag.knowledge_base import retrieve
        results = retrieve("documento SIARB", fresh_collection, top_k=3)
        assert len(results) == 3

    def test_top_k_limitato_alla_dimensione(self, fresh_collection):
        fresh_collection.add(ids=["solo"], documents=["unico documento"])
        from rag.knowledge_base import retrieve
        results = retrieve("documento", fresh_collection, top_k=10)
        assert len(results) == 1

    def test_collection_vuota_restituisce_lista_vuota(self, fresh_collection):
        from rag.knowledge_base import retrieve
        assert retrieve("query", fresh_collection, top_k=5) == []

    def test_restituisce_stringhe(self, fresh_collection):
        fresh_collection.add(ids=["x"], documents=["testo di prova"])
        from rag.knowledge_base import retrieve
        results = retrieve("testo", fresh_collection, top_k=1)
        assert all(isinstance(r, str) for r in results)


# Test setup_kb()

class TestSetupKb:

    def test_salta_reindicizzazione_se_popolata(self, fresh_collection):
        fresh_collection.add(ids=["x"], documents=["dato esistente"])
        with patch("rag.knowledge_base._get_collection", return_value=fresh_collection):
            from rag import knowledge_base
            coll = knowledge_base.setup_kb()
        assert coll.count() == 1

    def test_indicizza_chunk_dal_pdf(self, fresh_collection):
        fake_pages = [
            _make_page(
                "Primo paragrafo del manuale SIARB abbastanza lungo da superare il minimo di caratteri.\n\n"
                "Secondo paragrafo del manuale SIARB altrettanto informativo e significativo per il test.",
                page_number=1,
            ),
        ]
        with patch("rag.knowledge_base._get_collection", return_value=fresh_collection), \
             patch("rag.knowledge_base.pymupdf4llm.to_markdown", return_value=fake_pages):
            from rag import knowledge_base
            coll = knowledge_base.setup_kb()
        assert coll.count() >= 2

    def test_paragrafi_corti_esclusi(self, fresh_collection):
        fake_pages = [
            _make_page(
                "Corto.\n\n"
                "Paragrafo sufficientemente lungo da superare la soglia minima di ottanta caratteri.",
                page_number=1,
            ),
        ]
        with patch("rag.knowledge_base._get_collection", return_value=fresh_collection), \
             patch("rag.knowledge_base.pymupdf4llm.to_markdown", return_value=fake_pages):
            from rag import knowledge_base
            coll = knowledge_base.setup_kb()
        assert coll.count() == 1

    def test_metadata_include_numero_pagina(self, fresh_collection):
        fake_pages = [
            _make_page(
                "Paragrafo di prova del manuale SIARB abbastanza lungo da passare il filtro minimo dei caratteri.",
                page_number=3,
            ),
        ]
        with patch("rag.knowledge_base._get_collection", return_value=fresh_collection), \
             patch("rag.knowledge_base.pymupdf4llm.to_markdown", return_value=fake_pages):
            from rag import knowledge_base
            knowledge_base.setup_kb()
        item = fresh_collection.get(include=["metadatas"])
        assert item["metadatas"][0]["page"] == 3

    def test_piu_pagine_indicizzate(self, fresh_collection):
        fake_pages = [
            _make_page("Contenuto della prima pagina, abbastanza lungo per essere indicizzato correttamente.", 1),
            _make_page("Contenuto della seconda pagina, abbastanza lungo per essere indicizzato correttamente.", 2),
        ]
        with patch("rag.knowledge_base._get_collection", return_value=fresh_collection), \
             patch("rag.knowledge_base.pymupdf4llm.to_markdown", return_value=fake_pages):
            from rag import knowledge_base
            knowledge_base.setup_kb()
        pages_indexed = {m["page"] for m in fresh_collection.get(include=["metadatas"])["metadatas"]}
        assert pages_indexed == {1, 2}
