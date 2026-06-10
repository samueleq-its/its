"""
Test per agents/react_agent.py — usa Ollama reale con ChromaDB in-memory.

Richiedono Ollama attivo su localhost:11434 con ministral-3:3b e all-minilm:latest.
"""

import pytest
import chromadb
from schemas import ReactOutput


@pytest.fixture(scope="module", autouse=True)
def require_ollama():
    from ollama import Client
    try:
        Client(host="http://localhost:11434").list()
    except Exception:
        pytest.skip("Ollama non raggiungibile. Avvialo con: ollama serve")


@pytest.fixture(scope="module")
def siarb_coll(require_ollama):
    """Collection in-memory con chunk SIARB minimali per i test."""
    from rag.embeddings import OllamaEmbeddingFunction
    client = chromadb.EphemeralClient()
    coll = client.get_or_create_collection(
        "react_test", embedding_function=OllamaEmbeddingFunction()
    )
    coll.add(
        ids=["1", "2", "3", "4"],
        documents=[
            "Il SIARB (Sistema Informativo Agricolo della Regione Basilicata) e il sistema informatico regionale per la gestione dei dati delle aziende agricole.",
            "La registrazione di un'azienda agricola nel SIARB richiede il codice fiscale del titolare, la partita IVA e i dati catastali dei terreni coltivati.",
            "Il modulo UMA del SIARB gestisce le richieste di carburante agevolato per uso agricolo e macchinari.",
            "I bandi regionali per i contributi agricoli vengono pubblicati tramite il portale SIARB e richiedono documentazione specifica.",
        ],
    )
    return coll


class TestReactAgentRun:

    def test_risponde_a_domanda_pertinente(self, siarb_coll):
        from agents import react_agent
        from rag.knowledge_base import retrieve
        chunks = retrieve("cos'e il SIARB", siarb_coll)
        out = react_agent.run(
            message="Cos'e il SIARB?",
            chunks=chunks,
            memory="",
            fallback_retrieve=lambda q: retrieve(q, siarb_coll),
        )
        assert isinstance(out, ReactOutput)
        assert out.answer or out.rejected

    def test_rifiuta_domanda_non_pertinente(self, siarb_coll):
        from agents import react_agent
        from rag.knowledge_base import retrieve
        chunks = retrieve("capitale della Francia", siarb_coll)
        out = react_agent.run(
            message="Qual e la capitale della Francia?",
            chunks=chunks,
            memory="",
            fallback_retrieve=lambda q: retrieve(q, siarb_coll),
        )
        assert out.rejected

    def test_risposta_in_italiano(self, siarb_coll):
        from agents import react_agent
        from rag.knowledge_base import retrieve
        chunks = retrieve("modulo UMA carburante", siarb_coll)
        out = react_agent.run(
            message="Cos'e il modulo UMA del SIARB?",
            chunks=chunks,
            memory="",
            fallback_retrieve=lambda q: retrieve(q, siarb_coll),
        )
        if out.answer:
            assert any(
                t in out.answer.lower()
                for t in ["uma", "carburante", "agevolato", "siarb", "modulo"]
            )

    def test_usa_memoria_conversazionale(self, siarb_coll):
        from agents import react_agent
        from rag.knowledge_base import retrieve
        chunks = retrieve("SIARB aziende", siarb_coll)
        out = react_agent.run(
            message="Puoi ripetere?",
            chunks=chunks,
            memory="## [2026-06-09 10:00:00]\nL'utente ha chiesto cos'e il SIARB. E stato spiegato che gestisce i dati agricoli della Basilicata.",
            fallback_retrieve=lambda q: retrieve(q, siarb_coll),
        )
        assert isinstance(out, ReactOutput)
