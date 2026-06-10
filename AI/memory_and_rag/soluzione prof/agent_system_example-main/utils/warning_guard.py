"""
Agent 2 — Warning

Gestisce WARNING.md e blocca la sessione se i rifiuti accumulati
superano MAX_WARNINGS.

WARNING.md registra ogni conversazione fermata per linguaggio tossico
o domanda non pertinente. Formato entry:

    ## [2025-06-09 14:00:00]
    **Messaggio:** ...
    **Motivazione:** ...

Output strutturato (WarningOutput):
  - validation: True se la sessione puo continuare, False se bloccata.
  - motivation: motivazione del blocco, stringa vuota se la sessione e attiva.
"""

import datetime

from config import WARNING_FILE, MAX_WARNINGS
from schemas import WarningOutput


# I/O su WARNING.md

def write_warning(message: str, reason: str) -> None:
    """Aggiunge una entry al file WARNING.md."""
    if not WARNING_FILE.exists():
        WARNING_FILE.parent.mkdir(parents=True, exist_ok=True)
        WARNING_FILE.write_text("# Conversazioni Rifiutate\n\n", encoding="utf-8")
    ts = datetime.datetime.now().strftime("%Y-%m-%d %H:%M:%S")
    with open(WARNING_FILE, "a", encoding="utf-8") as f:
        f.write(f"## [{ts}]\n**Messaggio:** {message[:300]}\n**Motivazione:** {reason}\n\n")


def count_warnings() -> int:
    """Conta il numero di rifiuti registrati in WARNING.md."""
    if not WARNING_FILE.exists():
        return 0
    return WARNING_FILE.read_text(encoding="utf-8").count("## [")


# Agente

def run() -> WarningOutput:
    """Blocca la sessione se count_warnings() supera MAX_WARNINGS."""
    n = count_warnings()
    if n > MAX_WARNINGS:
        return WarningOutput(
            validation=False,
            motivation=(
                f"Sessione bloccata: registrati {n} tentativi non validi "
                f"(limite: {MAX_WARNINGS}). Riavvia una nuova sessione."
            ),
        )
    return WarningOutput(validation=True, motivation="")
