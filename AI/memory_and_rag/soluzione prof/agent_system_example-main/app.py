"""
Pipeline principale e interfaccia Gradio.

Orchestrazione degli agenti:
  1. security_agent: valida il messaggio
  2. warning_guard (utils): controlla il limite di rifiuti
  3. react_agent: ragiona, recupera, risponde (con MCP se necessario)
  4. memory_agent: salva la sintesi degli scambi riusciti

Avvio:
    python app.py
"""

import gradio as gr

from agents import security_agent, react_agent, memory_agent
from utils import warning_guard
from rag.knowledge_base import setup_kb, retrieve
from config import WARNING_FILE, MEMORY_FILE

# Knowledge base, inizializzata una sola volta per sessione.

_collection = None


def reset_mem_files() -> None:
    """
    Svuota WARNING.md e MEMORY.md mantenendo i file.
    Chiamata all'avvio di Gradio e all'avvio dei test di integrazione,
    in modo da partire sempre da uno stato pulito senza cancellare i file.
    """
    for path, header in [
        (WARNING_FILE, "# Conversazioni Rifiutate\n\n"),
        (MEMORY_FILE,  "# Memoria Conversazionale\n\n"),
    ]:
        path.parent.mkdir(parents=True, exist_ok=True)
        path.write_text(header, encoding="utf-8")


def get_collection():
    global _collection
    if _collection is None:
        _collection = setup_kb()
    return _collection


# Pipeline

def process(message: str) -> str:

    # 1. Security: filtra linguaggio tossico
    sec = security_agent.run(message)
    if not sec.validation:
        warning_guard.write_warning(message, sec.motivation)
        return f"Messaggio rifiutato: {sec.motivation}"

    # 2. Warning: blocca se troppi rifiuti accumulati
    warn = warning_guard.run()
    if not warn.validation:
        return warn.motivation

    # 3. ReAct: ragiona sui chunk e produce la risposta
    coll   = get_collection()
    memory = memory_agent.read_memory()
    chunks = retrieve(message, coll)

    out = react_agent.run(
        message=message,
        chunks=chunks,
        memory=memory,
        fallback_retrieve=lambda q: retrieve(q, coll),
    )

    if out.rejected:
        warning_guard.write_warning(message, out.rejected)
        return f"Domanda non pertinente: {out.rejected}"

    answer = out.answer

    # 4. Memory: salva la sintesi dello scambio riuscito
    memory_agent.run(message, answer)

    return answer


# Gradio

def chat_fn(message: str, history: list) -> str:
    return process(message)


if __name__ == "__main__":
    print("Pulizia file di stato...")
    reset_mem_files()
    print("Inizializzazione knowledge base...")
    get_collection()

    demo = gr.ChatInterface(
        fn=chat_fn,
        title="Assistente SIARB",
        description=(
            "Assistente basato sul Manuale di Gestione SIARB "
            "(Sistema Informativo Agricolo, Regione Basilicata)."
        ),
        examples=[
            "Quali moduli compongono la sezione UMA del sistema?",
            "Come funziona la gestione dei bandi regionali?",
            "Quali procedure gestisce il comparto fitosanitario?",
            "Come si richiedono gli indennizzi per danni da calamità naturali?",
        ],
        cache_examples=False,
    )
    demo.launch()
