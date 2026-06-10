"""
Test per agents/memory_agent.py

I/O su file: usa tmp_path di pytest per isolare le scritture.
Sintesi LLM: usa Ollama reale (ministral-3:3b).
"""

import re
import pytest


@pytest.fixture(scope="module", autouse=True)
def require_ollama():
    from ollama import Client
    try:
        Client(host="http://localhost:11434").list()
    except Exception:
        pytest.skip("Ollama non raggiungibile. Avvialo con: ollama serve")


@pytest.fixture()
def tmp_memory(tmp_path):
    mf = tmp_path / "MEMORY.md"
    from unittest.mock import patch
    with patch("agents.memory_agent.MEMORY_FILE", mf), \
         patch("agents.memory_agent.MEMORY_WINDOW", 3):
        yield mf


class TestWriteMemory:

    def test_crea_file(self, tmp_memory):
        from agents import memory_agent
        memory_agent.write_memory("una sintesi")
        assert tmp_memory.exists()

    def test_aggiunge_piu_entry(self, tmp_memory):
        from agents import memory_agent
        memory_agent.write_memory("sintesi 1")
        memory_agent.write_memory("sintesi 2")
        content = tmp_memory.read_text(encoding="utf-8")
        assert content.count("## [") == 2

    def test_entry_ha_timestamp(self, tmp_memory):
        from agents import memory_agent
        memory_agent.write_memory("qualcosa")
        content = tmp_memory.read_text(encoding="utf-8")
        assert re.search(r"## \[\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}\]", content)


class TestReadMemory:

    def test_vuoto_senza_file(self, tmp_memory):
        from agents import memory_agent
        assert memory_agent.read_memory() == ""

    def test_restituisce_ultime_n_entry(self, tmp_memory):
        from agents import memory_agent
        for i in range(5):
            memory_agent.write_memory(f"sintesi {i}")
        result = memory_agent.read_memory()
        assert "sintesi 4" in result
        assert "sintesi 2" in result
        assert "sintesi 0" not in result

    def test_stringa_vuota_senza_entry(self, tmp_memory):
        from agents import memory_agent
        tmp_memory.write_text("# Memoria Conversazionale\n\n", encoding="utf-8")
        assert memory_agent.read_memory() == ""


class TestMemoryAgentRun:

    def test_salva_sintesi_nel_file(self, tmp_memory):
        from agents import memory_agent
        memory_agent.run(
            "Cos'e il SIARB?",
            "Il SIARB e il sistema informativo agricolo della Regione Basilicata.",
        )
        content = tmp_memory.read_text(encoding="utf-8")
        assert "## [" in content
        entries = content.split("## [")[1:]
        assert len(entries) == 1
        assert entries[0].strip()

    def test_sintesi_non_vuota(self, tmp_memory):
        from agents import memory_agent
        memory_agent.run(
            "Come si registra un'azienda?",
            "La registrazione richiede codice fiscale e dati catastali.",
        )
        content = tmp_memory.read_text(encoding="utf-8")
        body = content.split("## [")[1].split("]", 1)[1].strip()
        assert len(body) > 0
