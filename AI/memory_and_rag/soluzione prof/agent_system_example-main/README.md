# Assistente SIARB — Progetto Didattico Multi-Agente

Esempio completo di **chatbot RAG multi-agente** costruito interamente con modelli locali (Ollama).  
Il sistema risponde a domande sul *Manuale di Gestione SIARB* (Sistema Informativo Agricolo — Regione Basilicata) applicando una pipeline composta da tre agenti LLM, un componente deterministico di guardia, una knowledge base vettoriale e un server MCP per la ricerca raffinata.

---

## Indice

1. [Prerequisiti](#1-prerequisiti)
2. [Installazione](#2-installazione)
3. [Avvio](#3-avvio)
4. [Test](#4-test)
5. [Struttura del progetto](#5-struttura-del-progetto)
6. [Architettura — la pipeline](#6-architettura--la-pipeline)
7. [Agente 1 — Security](#7-agente-1--security)
8. [Componente 2 — Warning Guard](#8-componente-2--warning-guard)
9. [Agente 3 — ReAct](#9-agente-3--react)
10. [Agente 4 — Memory](#10-agente-4--memory)
11. [RAG e Knowledge Base](#11-rag-e-knowledge-base)
12. [MCP — Model Context Protocol](#12-mcp--model-context-protocol)
13. [Structured Output con Pydantic](#13-structured-output-con-pydantic)
14. [Scelte tecniche](#14-scelte-tecniche)

---

## 1. Prerequisiti

| Strumento | Versione minima | Note |
|-----------|----------------|------|
| Python | 3.10+ | |
| [Ollama](https://ollama.com) | qualsiasi | deve girare su `localhost:11434` |
| Modello LLM | `ministral-3:3b` | `ollama pull ministral-3:3b` |
| Modello embedding | `all-minilm:latest` | `ollama pull all-minilm:latest` |

```bash
ollama pull ministral-3:3b
ollama pull all-minilm:latest
```

---

## 2. Installazione

```bash
git clone <repo>
cd esempio_completo
pip install -r requirements.txt
```

`requirements.txt`:
```
pymupdf4llm
chromadb
ollama
gradio
mcp[cli]
pydantic
```

> **Nota:** `sentence-transformers` non è richiesto. L'embedding viene eseguito da Ollama (`all-minilm:latest`), il che garantisce coerenza con il modello di retrieval usato a runtime.

---

## 3. Avvio

```bash
python app.py
```

Al primo avvio, `setup_kb()` legge il PDF in `docs/`, lo converte in Markdown con `pymupdf4llm`, lo suddivide in chunk e li indicizza in ChromaDB (`vdb/`). Le esecuzioni successive riusano la KB già costruita.

Dopo l'indicizzazione si apre l'interfaccia Gradio su `http://localhost:7860`.

### Configurazione (`config.py`)

```python
MODEL       = "ministral-3:3b"   # modello generativo
EMBED_MODEL = "all-minilm:latest" # modello di embedding
OLLAMA_HOST = "http://localhost:11434"

MAX_WARNINGS         = 3   # rifiuti prima del blocco sessione
MAX_REACT_ITERATIONS = 3   # iterazioni massime del loop ReAct
MEMORY_WINDOW        = 5   # scambi passati inclusi nel contesto
```

---

## 4. Test

```bash
python -m pytest tests/ -v
```

La maggior parte dei test richiede Ollama attivo su `localhost:11434` con i modelli `ministral-3:3b` e `all-minilm:latest`. Se il servizio non è raggiungibile i test saltano automaticamente. `test_schemas.py` e `test_warning_guard.py` non usano Ollama e girano sempre. Il file `tests/conftest.py` aggiunge la root al `sys.path`.

```
tests/
├── conftest.py             # sys.path setup
├── test_schemas.py         # validazione Pydantic (senza Ollama)
├── test_security_agent.py  # security_agent con Ollama reale
├── test_warning_guard.py   # utils/warning_guard — I/O su file (senza Ollama)
├── test_react_agent.py     # react_agent con Ollama reale + ChromaDB in-memory
├── test_memory_agent.py    # memory_agent con Ollama reale + tmp_path
├── test_knowledge_base.py  # ChromaDB in-memory + Ollama embedding reale
└── test_integration.py     # pipeline end-to-end con Ollama reale e file .md reali
```

---

## 5. Struttura del progetto

```
esempio_completo/
│
├── app.py              # entry point: pipeline + interfaccia Gradio
├── config.py           # parametri globali
├── schemas.py          # structured output Pydantic
├── requirements.txt
│
├── agents/             # agenti LLM
│   ├── security_agent.py
│   ├── react_agent.py
│   └── memory_agent.py
│
├── utils/              # componenti deterministici (nessun LLM)
│   └── warning_guard.py    # gestione WARNING.md e blocco sessione
│
├── rag/                # recupero informazioni e server MCP
│   ├── embeddings.py       # OllamaEmbeddingFunction
│   ├── knowledge_base.py   # indicizzazione PDF + retrieve()
│   └── mcp_rag_server.py   # server FastMCP espone search_rag
│
├── docs/               # documenti sorgente
│   └── Manuale_Gestione_SIARB.pdf
│
├── vdb/                # ChromaDB persistente (creato al primo avvio, poi riutilizzato)
├── mem/                # stato conversazionale
│   ├── WARNING.md      # log rifiuti (svuotato ad ogni avvio)
│   └── MEMORY.md       # log sintesi scambi (svuotato ad ogni avvio)
│
└── tests/
```

---

## 6. Architettura — la pipeline

Ogni messaggio dell'utente attraversa tre agenti LLM e un componente deterministico in sequenza. Ognuno può bloccare il flusso oppure arricchire il contesto per il successivo.

```
Utente
  │
  ▼
┌─────────────────┐
│  Security Agent │  ── tossico? ──► rifiuta + scrivi WARNING.md
└────────┬────────┘
         │ ok
         ▼
┌─────────────────┐
│  Warning Guard  │  ── troppi rifiuti? ──► blocca sessione
└────────┬────────┘
         │ ok
         ▼
┌─────────────────────────────────────────┐
│  ReAct Agent                            │
│                                         │
│  retrieve(query) ──► chunks             │
│       │                                 │
│  _reason_and_act()                      │
│       ├── rejected ──► scrivi WARNING   │
│       ├── search   ──► MCP ──► retry    │
│       └── answer   ──► risposta         │
└────────┬────────────────────────────────┘
         │ answer
         ▼
┌─────────────────┐
│  Memory Agent   │  ── sintetizza scambio ──► scrivi MEMORY.md
└─────────────────┘
         │
         ▼
      Risposta
```

Il codice di orchestrazione in `app.py`:

```python
def process(message: str) -> str:
    sec = security_agent.run(message)
    if not sec.validation:
        warning_guard.write_warning(message, sec.motivation)
        return f"Messaggio rifiutato: {sec.motivation}"

    warn = warning_guard.run()
    if not warn.validation:
        return warn.motivation

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
    memory_agent.run(message, answer)
    return answer
```

---

## 7. Agente 1 — Security

**File:** `agents/security_agent.py`  
**Scopo:** filtrare linguaggio tossico, offensivo o violento prima che entri nella pipeline.

Il prompt è in inglese (più robusto per modelli addestrati prevalentemente su testi inglesi), con istruzione esplicita a rispondere in italiano se necessario:

```python
_SYSTEM = """You are a content moderation system.
Analyze the user message and determine whether it contains:
profanity, vulgar, offensive, discriminatory or violent language.

If the message is normal and civil: set validation=true and motivation="".
If it is problematic: set validation=false and motivation=short explanation in Italian.

Reply ONLY with valid JSON following the provided schema."""
```

L'output è forzato tramite **structured output** (vedi §13):

```python
resp = _ollama.chat(
    model=MODEL,
    messages=[...],
    format=SecurityOutput.model_json_schema(),  # forza JSON strutturato
)
return SecurityOutput.model_validate_json(resp.message.content)
```

Se `validation=False`, il messaggio non raggiunge mai il ReAct agent e l'evento viene registrato in `WARNING.md`.

---

## 8. Componente 2 — Warning Guard

**File:** `utils/warning_guard.py`  
**Scopo:** tenere traccia dei rifiuti accumulati e bloccare la sessione se superano `MAX_WARNINGS`.

Questo componente **non usa LLM**: legge e scrive un file Markdown (`mem/WARNING.md`) che registra ogni rifiuto con timestamp.

```python
def write_warning(message: str, reason: str) -> None:
    if not WARNING_FILE.exists():
        WARNING_FILE.parent.mkdir(parents=True, exist_ok=True)
        WARNING_FILE.write_text("# Conversazioni Rifiutate\n\n", encoding="utf-8")
    ts = datetime.datetime.now().strftime("%Y-%m-%d %H:%M:%S")
    with open(WARNING_FILE, "a", encoding="utf-8") as f:
        f.write(f"## [{ts}]\n**Messaggio:** {message[:300]}\n**Motivazione:** {reason}\n\n")

def count_warnings() -> int:
    return WARNING_FILE.read_text(encoding="utf-8").count("## [") if WARNING_FILE.exists() else 0
```

Il controllo avviene a ogni chiamata:

```python
def run() -> WarningOutput:
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
```

**Perché un file Markdown?** È leggibile direttamente dall'istruttore o dallo studente, persiste tra sessioni e non richiede un database.

---

## 9. Agente 3 — ReAct

**File:** `agents/react_agent.py`  
**Scopo:** rispondere alla domanda usando i chunk RAG, con possibilità di ricerca raffinata tramite MCP.

### Il pattern ReAct

ReAct (*Reasoning + Acting*) è un pattern in cui il modello alterna ragionamento e azioni in un loop:

```
Thought → Action → Observation → Thought → ...
```

In questa implementazione ogni iterazione produce uno di tre output mutuamente esclusivi:

| Campo | Significato | Azione successiva |
|-------|-------------|-------------------|
| `rejected` | domanda fuori scope | stop, scrivi warning |
| `search` | chunk insufficienti | chiama MCP con query raffinata, riprova |
| `answer` | risposta trovata | stop, salva memoria |

```python
def _reason_and_act(message, chunks, memory, iteration) -> ReactOutput:
    chunks_text = "\n---\n".join(chunks) if chunks else "No chunks retrieved."

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

Reply ONLY with valid JSON."""

    resp = _ollama.chat(model=MODEL, messages=[...], format=ReactOutput.model_json_schema())
    return ReactOutput.model_validate_json(resp.message.content)
```

### Gestione dell'ultimo tentativo

All'iterazione finale il prompt cambia per forzare sempre una risposta:

```python
last_attempt = (iteration == MAX_REACT_ITERATIONS - 1)
final_note = (
    "\nLAST ATTEMPT: do not use 'search'. "
    "Write in 'answer' the best response with the available material, "
    "or explain what you found and ask the user if it may be sufficient. "
    "The answer must be written in Italian."
    if last_attempt else ""
)
```

### Loop principale

```python
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
```

---

## 10. Agente 4 — Memory

**File:** `agents/memory_agent.py`  
**Scopo:** sintetizzare ogni scambio riuscito e mantenerlo in `mem/MEMORY.md` come contesto per le conversazioni future.

Solo gli scambi con una `answer` valida vengono memorizzati; i rifiuti vanno in `WARNING.md`.

```python
system = (
    "You are a memory agent. Produce a concise summary (2-3 lines) "
    "of the exchange: topic discussed, answer given, key details. "
    "Write the summary in Italian. No headings, nothing else."
)
```

La lettura usa una **finestra scorrevole** (`MEMORY_WINDOW = 5`):

```python
def read_memory() -> str:
    if not MEMORY_FILE.exists():
        return ""
    content = MEMORY_FILE.read_text(encoding="utf-8")
    entries = content.split("## [")[1:]
    recent  = entries[-MEMORY_WINDOW:]
    return "## [" + "\n## [".join(recent) if recent else ""
```

Questo contesto viene poi inserito nel prompt del ReAct agent, permettendo risposte coerenti con la conversazione in corso.

---

## 11. RAG e Knowledge Base

**File:** `rag/knowledge_base.py`, `rag/embeddings.py`

### Estrazione del testo — pymupdf4llm

Il PDF viene convertito in Markdown strutturato con `pymupdf4llm`, che riconosce intestazioni, tabelle e layout meglio di un semplice `extract_text()`:

```python
pages = pymupdf4llm.to_markdown(str(MANUAL_PATH), page_chunks=True)
# Restituisce una lista di dict: [{"text": "...", "metadata": {"page_number": 1}}, ...]
```

Ogni pagina viene poi divisa in paragrafi (split su `\n\n`) e filtrata per lunghezza minima:

```python
paras = [p.strip() for p in page["text"].split("\n\n") if len(p.strip()) >= MIN_CHUNK_CHARS]
```

### Embedding con Ollama

L'embedding non usa `sentence-transformers` ma chiama direttamente Ollama con il modello `all-minilm:latest`. Questo garantisce che il vettore del documento e il vettore della query siano prodotti dallo stesso modello nello stesso ambiente:

```python
class OllamaEmbeddingFunction(EmbeddingFunction):
    def __call__(self, input: Documents) -> Embeddings:
        response = self._client.embed(model=self._model, input=list(input))
        return response.embeddings
```

L'istanza viene passata direttamente a ChromaDB:

```python
client.get_or_create_collection("siarb_kb", embedding_function=OllamaEmbeddingFunction())
```

### Retrieval

```python
def retrieve(query: str, coll: chromadb.Collection, top_k: int = 5) -> list[str]:
    n = min(top_k, coll.count())
    if n == 0:
        return []
    return coll.query(query_texts=[query], n_results=n)["documents"][0]
```

ChromaDB calcola la similarità coseno tra l'embedding della query e tutti i chunk, restituendo i `top_k` più vicini.

---

## 12. MCP — Model Context Protocol

**File:** `rag/mcp_rag_server.py`

In questo progetto, il ReAct agent usa un'interfaccia MCP per eseguire una ricerca *raffinata* quando i chunk iniziali non bastano.

### Il server

```python
from mcp.server.fastmcp import FastMCP

mcp = FastMCP("rag-search")

@mcp.tool()
def search_rag(query: str, top_k: int = 5) -> str:
    """Cerca nel database vettoriale del manuale SIARB con una query raffinata."""
    client = chromadb.PersistentClient(path=str(KB_PATH))
    coll   = client.get_collection("siarb_kb", embedding_function=OllamaEmbeddingFunction())
    res    = coll.query(query_texts=[query], n_results=min(top_k, coll.count()))
    return json.dumps(res["documents"][0], ensure_ascii=False)

if __name__ == "__main__":
    mcp.run(transport="stdio")
```

### Il client (nel ReAct agent)

Il server viene avviato come sottoprocesso stdio a ogni chiamata. La comunicazione è asincrona, wrappata in modo sincrono per compatibilità con Gradio:

```python
async def _mcp_search_async(query: str) -> list[str]:
    params = StdioServerParameters(command="python", args=[str(MCP_SERVER)])
    async with stdio_client(params) as (r, w):
        async with ClientSession(r, w) as session:
            await session.initialize()
            result = await session.call_tool("search_rag", {"query": query, "top_k": 5})
            return json.loads(result.content[0].text)

def mcp_search(query: str) -> list[str]:
    return asyncio.run(_mcp_search_async(query))
```

**Perché MCP e non una chiamata diretta a ChromaDB?** Scopo didattico: mostrare come un agente possa usare strumenti esterni senza conoscerne l'implementazione interna — esattamente il caso d'uso per cui MCP è stato progettato.

---

## 13. Structured Output con Pydantic

Tutti gli agenti che usano LLM ricevono output **tipizzato e validato** passando lo schema JSON di un modello Pydantic come parametro `format=` a Ollama. Questo elimina il parsing manuale del testo e garantisce che il modello risponda sempre con la struttura attesa.

**Definizione dello schema:**

```python
class ReactOutput(BaseModel):
    rejected: str = Field(default="", description="Compila solo se la domanda non riguarda il manuale.")
    search:   str = Field(default="", description="Compila solo se i chunk non bastano.")
    answer:   str = Field(default="", description="Compila solo se hai la risposta.")
```

**Passaggio a Ollama:**

```python
resp = _ollama.chat(
    model=MODEL,
    messages=[{"role": "system", "content": system}, {"role": "user", "content": message}],
    format=ReactOutput.model_json_schema(),   # istruzione al modello
)
output = ReactOutput.model_validate_json(resp.message.content)
```

**Perché è importante:** senza structured output il modello potrebbe rispondere con testo libero, rendendo il parsing fragile e il comportamento degli agenti imprevedibile. Con `format=`, Ollama usa il *grammar sampling* per garantire che l'output sia JSON valido conforme allo schema.

---

## 14. Scelte tecniche

| Scelta | Alternativa considerata | Motivazione |
|--------|------------------------|-------------|
| Ollama locale | API cloud (OpenAI, Anthropic) | Privacy, zero costi, funziona offline |
| `ministral-3:3b` | modelli più grandi | Buon rapporto qualità/velocità su hardware consumer |
| `all-minilm:latest` via Ollama | `sentence-transformers` | Coerenza: embedding e generazione dallo stesso runtime |
| `pymupdf4llm` | `pdfplumber`, `pypdf` | Output Markdown strutturato, riconosce tabelle e intestazioni |
| ChromaDB | FAISS, Qdrant, Weaviate | Semplicità, zero configurazione, persistenza su file |
| MCP (FastMCP) | chiamata diretta a ChromaDB | Didattico: separa il tool dall'agente, esattamente come nei sistemi reali |
| File Markdown per stato | SQLite, Redis | Leggibili senza strumenti, ispezionabili durante lo sviluppo |
| Pydantic structured output | parsing regex/JSON manuale | Robusto, auto-documentato, validazione automatica |
| Gradio | Streamlit, FastAPI | Chatbot in 5 righe, nessuna configurazione frontend |
