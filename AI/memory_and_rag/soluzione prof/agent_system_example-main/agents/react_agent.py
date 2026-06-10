"""
Agent 3 — ReAct (Reasoning + Acting)

Loop iterativo (max MAX_REACT_ITERATIONS) per rispondere a domande sul manuale SIARB.

Ogni iterazione chiama _reason_and_act() che produce uno dei tre output:
  - rejected: domanda non pertinente al manuale. Ferma il flusso e scrive WARNING.md.
  - search: chunk insufficienti. Chiama MCP con query raffinata e riprova.
  - answer: risposta trovata. Ferma il flusso e salva in MEMORY.md.

Alla terza iterazione il prompt forza sempre "answer" con il materiale disponibile.

Il server mcp_rag_server.py viene avviato come sottoprocesso stdio ogni volta
che serve una ricerca raffinata.
"""

import asyncio
import json

from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client
from ollama import Client

from config import MODEL, OLLAMA_HOST, MCP_SERVER, MAX_REACT_ITERATIONS
from schemas import ReactOutput

_ollama = Client(host=OLLAMA_HOST)


# MCP: ricerca raffinata

async def _mcp_search_async(query: str) -> list[str]:
    params = StdioServerParameters(command="python", args=[str(MCP_SERVER)])
    async with stdio_client(params) as (r, w):
        async with ClientSession(r, w) as session:
            await session.initialize()
            result = await session.call_tool("search_rag", {"query": query, "top_k": 5})
            return json.loads(result.content[0].text)


def mcp_search(query: str) -> list[str]:
    """Wrapper sincrono per la chiamata MCP asincrona."""
    return asyncio.run(_mcp_search_async(query))


# Singolo step ReAct

def _reason_and_act(
    message: str,
    chunks: list[str],
    memory: str,
    iteration: int,
) -> ReactOutput:
    chunks_text  = "\n---\n".join(chunks) if chunks else "No chunks retrieved."
    last_attempt = (iteration == MAX_REACT_ITERATIONS - 1)

    final_note = (
        "\nLAST ATTEMPT: do not use 'search'. "
        "Write in 'answer' the best response with the available material, "
        "or explain what you found and ask the user if it may be sufficient. "
        "The answer must be written in Italian."
        if last_attempt else ""
    )

    system = f"""You are an assistant specialized in the SIARB Management Manual \
(Agricultural Information System, Basilicata Region, Italy).

CONVERSATIONAL MEMORY:
{memory or "No previous conversation."}

RETRIEVED CHUNKS:
{chunks_text}

INSTRUCTIONS:
Analyze the question and the chunks. Fill in ONLY ONE field, leave the others empty:

- "rejected": use this field if the question is NOT about the SIARB manual.
- "search": use this field if the chunks are insufficient. Write a refined search query in Italian.
- "answer": use this field if the chunks are sufficient. Write the complete answer IN ITALIAN.
{final_note}

Reply ONLY with valid JSON."""

    resp = _ollama.chat(
        model=MODEL,
        messages=[
            {"role": "system", "content": system},
            {"role": "user",   "content": message},
        ],
        format=ReactOutput.model_json_schema(),
    )
    return ReactOutput.model_validate_json(resp.message.content)


# Loop principale

def run(
    message: str,
    chunks: list[str],
    memory: str,
    fallback_retrieve,
) -> ReactOutput:
    """
    Esegue il loop ReAct fino a MAX_REACT_ITERATIONS.

    Args:
        message: domanda dell'utente.
        chunks: chunk iniziali dal retrieve.
        memory: contesto da MEMORY.md.
        fallback_retrieve: callable(query) -> list[str], usato se MCP fallisce.
    """
    for i in range(MAX_REACT_ITERATIONS):
        out = _reason_and_act(message, chunks, memory, i)

        if out.rejected or out.answer:
            return out

        if out.search and i < MAX_REACT_ITERATIONS - 1:
            try:
                new_chunks = mcp_search(out.search)
                if new_chunks:
                    chunks = new_chunks
            except Exception:
                fallback = fallback_retrieve(out.search)
                if fallback:
                    chunks = fallback

    # Failsafe: non dovrebbe arrivare qui perche l'ultima iterazione forza answer.
    return ReactOutput(
        answer=(
            "Non ho trovato materiale sufficiente nel manuale. "
            "Ecco i frammenti più rilevanti:\n\n"
            + "\n\n---\n\n".join(chunks[:2])
            + "\n\nPossono essere utili come punto di partenza?"
        )
    )
