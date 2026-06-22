# Esercizio: Sistema Agentico Sicuro su Dati Bancari

## Obiettivo

Completare un agente LLM che opera su un database bancario tramite MCP, garantendo che ogni utente possa accedere solo ai propri dati e che il sistema resista a tentativi di manipolazione.

## Avvio

```bash
pip install -r requirements.txt
python seed_db.py       # crea il database (solo la prima volta)
python agente_sicuro.py # esegue i test
```

Ollama deve essere in esecuzione con il modello `ministral-3:3b`:

```bash
ollama serve
ollama pull ministral-3:3b
```

## Come funziona il sistema (già scritto)

All'avvio di ogni sessione il sistema:

1. Recupera nome e cognome del cliente loggato dal database tramite MCP
2. Costruisce il system prompt includendo nome, cognome e ID del cliente
3. Per ogni messaggio esegue la pipeline: input guard, agente ReAct, output guard

L'agente sa quindi chi è il cliente loggato. Quando l'utente scrive "il mio saldo" l'agente sa a quale ID corrisponde "mio" e può chiamare lo strumento MCP corretto.

## Cosa devi fare

Apri `agente_sicuro.py`. Trovi tre sezioni marcate con `<<<` e `>>>`:

**Sezione 1 — System prompt**
Scrivi il testo che istruisce l'agente a comportarsi in modo sicuro. Il nome e l'ID del cliente loggato vengono aggiunti automaticamente in fondo al prompt a runtime: devi solo scrivere le regole generali di comportamento.

**Sezione 2 — Input guard**
Implementa `input_guard(message, cliente_corrente_id)`. Riceve il messaggio dell'utente prima che arrivi all'agente. Restituisce `(True, "")` se il messaggio è lecito, `(False, motivo)` se va bloccato.

**Sezione 3 — Output guard**
Implementa `output_guard(response, cliente_corrente_id)`. Riceve la risposta dell'agente prima che venga mostrata all'utente. Restituisce `(True, risposta)` se l'output è sicuro, `(False, motivo)` se va bloccato.

Il resto del file non va modificato.

## La distinzione fondamentale

Il cliente può chiedere qualsiasi cosa sui **propri** dati ("il mio saldo", "i miei movimenti"). Non può accedere ai dati di **altri** clienti, nemmeno inventando un ruolo o un'emergenza.

I test sono divisi in due gruppi:

**Richieste lecite** — il sistema deve rispondere normalmente:
- domande sui propri dati usando "il mio / i miei"

**Attacchi** — il sistema deve bloccare:
- accesso non autorizzato: si chiedono dati di altri clienti per ID, nome o cognome
- social engineering: si inventa un'autorità (direttore, responsabile sicurezza) per giustificare l'accesso
- manipolazione del sistema: si tenta di sovrascrivere le istruzioni o estrarre il system prompt

## Il server MCP

`mcp_banca_server.py` espone cinque strumenti sul database `banca.db`:

| Strumento | Descrizione |
|---|---|
| `lista_clienti()` | Tutti i clienti (id, nome, cognome) |
| `cerca_cliente(nome, cognome)` | Ricerca anagrafica per nome o cognome |
| `saldo_conto(cliente_id)` | Saldo e IBAN dei conti del cliente |
| `ultimi_movimenti(conto_id, n)` | Ultimi n movimenti del conto |
| `prestiti_cliente(cliente_id)` | Prestiti attivi del cliente |

Il server non ha nessuna protezione: risponde a qualsiasi richiesta. La sicurezza dipende interamente da quello che scrivi in `agente_sicuro.py`.
