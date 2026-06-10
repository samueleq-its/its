"""
Agent 1 — Security

Verifica che il messaggio dell'utente non contenga linguaggio tossico,
violento o offensivo prima che entri nella pipeline.

Output strutturato (SecurityOutput):
  - validation: True se il messaggio e accettabile, False altrimenti.
  - motivation: motivazione del rifiuto, stringa vuota se accettabile.

Se validation e False il chiamante deve:
  1. Scrivere il rifiuto in WARNING.md via utils.warning_guard.write_warning().
  2. Restituire la motivazione all'utente e fermare il flusso.
"""

from ollama import Client

from config import MODEL, OLLAMA_HOST
from schemas import SecurityOutput

_ollama = Client(host=OLLAMA_HOST)

_SYSTEM = """You are a content moderation system.
Analyze the user message and determine whether it contains:
profanity, vulgar, offensive, discriminatory or violent language.

If the message is normal and civil: set validation=true and motivation="".
If it is problematic: set validation=false and motivation=short explanation in Italian.

Reply ONLY with valid JSON following the provided schema."""


def run(message: str) -> SecurityOutput:
    resp = _ollama.chat(
        model=MODEL,
        messages=[
            {"role": "system", "content": _SYSTEM},
            {"role": "user",   "content": f"Message to analyze: {message}"},
        ],
        format=SecurityOutput.model_json_schema(),
    )
    return SecurityOutput.model_validate_json(resp.message.content)
