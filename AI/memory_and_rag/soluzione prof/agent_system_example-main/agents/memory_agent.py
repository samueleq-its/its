"""
Agent 4 — Memory

Mantiene la memoria conversazionale su MEMORY.md.
Salva solo gli scambi andati a buon fine (con answer dal ReAct agent).
I rifiuti non vengono memorizzati qui ma in WARNING.md.

Formato entry:
    ## [2025-06-09 14:00:00]
    sintesi in 2-3 righe

La funzione read_memory() restituisce le ultime MEMORY_WINDOW entry
come stringa da inserire nel contesto del ReAct agent.
"""

import datetime

from ollama import Client

from config import MODEL, OLLAMA_HOST, MEMORY_FILE, MEMORY_WINDOW

_ollama = Client(host=OLLAMA_HOST)


# I/O su MEMORY.md

def write_memory(synthesis: str) -> None:
    """Aggiunge una sintesi a MEMORY.md."""
    if not MEMORY_FILE.exists():
        MEMORY_FILE.parent.mkdir(parents=True, exist_ok=True)
        MEMORY_FILE.write_text("# Memoria Conversazionale\n\n", encoding="utf-8")
    ts = datetime.datetime.now().strftime("%Y-%m-%d %H:%M:%S")
    with open(MEMORY_FILE, "a", encoding="utf-8") as f:
        f.write(f"## [{ts}]\n{synthesis}\n\n")


def read_memory() -> str:
    """Restituisce le ultime MEMORY_WINDOW entry come stringa di contesto."""
    if not MEMORY_FILE.exists():
        return ""
    content = MEMORY_FILE.read_text(encoding="utf-8")
    entries = content.split("## [")[1:]
    recent  = entries[-MEMORY_WINDOW:]
    return "## [" + "\n## [".join(recent) if recent else ""


# Agente

def run(user_msg: str, answer: str) -> None:
    """Sintetizza lo scambio e lo salva in MEMORY.md."""
    system = (
        "You are a memory agent. Produce a concise summary (2-3 lines) "
        "of the exchange: topic discussed, answer given, key details. "
        "Write the summary in Italian. No headings, nothing else."
    )
    resp = _ollama.chat(
        model=MODEL,
        messages=[
            {"role": "system", "content": system},
            {"role": "user",   "content": f"User: {user_msg}\nAssistant: {answer}"},
        ],
    )
    write_memory(resp.message.content)
