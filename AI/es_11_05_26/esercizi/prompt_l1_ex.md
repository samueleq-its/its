# Esercizio Pratico: Chain-of-Thought + Structured Output

## Scenario

Un'azienda di logistica deve pianificare le consegne per la giornata.  
Il vostro compito è costruire un sistema che:

1. Legge i dati delle consegne da un file CSV
2. Usa un LLM con un prompt **Chain-of-Thought** per pianificare l'assegnazione ottimale ai furgoni
3. Ottiene l'output come **JSON strutturato e garantito** — senza parsing manuale

---

## Dati: `consegne.csv`

```
cliente_id,cliente_nome,peso_kg,distanza_km,tempo_minuti,priorita
C001,Cliente A,85,15,45,normale
C002,Cliente B,120,22,60,alta
C003,Cliente C,65,8,30,normale
C004,Cliente D,95,18,50,alta
C005,Cliente E,55,12,40,normale
C006,Cliente F,70,25,75,normale
```

**Vincoli operativi:**
- **3 furgoni** disponibili
- Capacità massima per furgone: **150 kg**
- Costo carburante: **€0.80 per km**
- Tariffa conducente: **€18/ora**
- Il tempo include andata e ritorno al deposito
- Clienti con priorità `alta` devono essere serviti nelle prime 2 ore

---

## Compito

### Step 1 — Lettura del CSV

Leggete `consegne.csv` e  costruite l'input da inserire nel prompt.  


### Step 2 — Prompt Chain-of-Thought

Progettate un prompt CoT che:

- Include i dati del CSV e i vincoli operativi nel contesto
- Guida il modello attraverso un ragionamento **step-by-step** su:
  - Analisi dei vincoli (peso, priorità, tempi)
  - Strategia di raggruppamento ottimale
  - Calcolo dei costi per ogni furgone
  - Validazione della soluzione

### Step 3 — Schema JSON

Definite uno **JSON Schema** per l'output atteso.  
Lo schema deve descrivere un oggetto con chiave `"piano_consegne"` contenente un array di furgoni, dove ogni furgone ha:

| Campo | Tipo | Descrizione |
|---|---|---|
| `furgone_id` | integer | Identificativo del furgone |
| `consegne` | array di stringhe | Es. `["C002", "C005"]` — in sequenza ottimale |
| `peso_totale_kg` | number | Somma dei pesi assegnati |
| `distanza_totale_km` | number | Distanza totale percorsa |
| `tempo_totale_minuti` | integer | Tempo totale stimato |
| `costo_carburante_euro` | number | `distanza_totale_km × 0.80` |
| `costo_conducente_euro` | number | `(tempo_totale_minuti / 60) × 18` |
| `costo_totale_euro` | number | Somma dei due costi |

### Step 4 — Chiamata al modello con output strutturato

Usate `client.chat()` con il parametro `format` per ottenere un JSON garantito che rispetta lo schema definito al passo precedente.

Consultate la documentazione della libreria `ollama` per capire come passare uno schema JSON al parametro `format`.

### Step 5 — Validazione

Verificate che:
- Il JSON sia parsabile con `json.loads()`
- Nessun furgone superi i 150 kg
- I clienti con priorità `alta` (C002, C004) siano assegnati

---

## Criteri di valutazione

- Il prompt CoT guida il modello attraverso tutti i passaggi richiesti
- Lo JSON Schema è corretto e completo
- Il risultato finale è un JSON valido e parsabile
- I vincoli operativi sono rispettati

---

## Note

- Tutti i costi devono essere arrotondati a 2 decimali
- L'ordine degli elementi in `consegne` deve riflettere la sequenza ottimale di consegna

---

## Librerie di Riferimento

### `pathlib` — Gestione dei percorsi file

`pathlib` è la libreria standard Python per lavorare con i percorsi del filesystem in modo cross-platform.

**Tutorial:** [docs.python.org/3/library/pathlib](https://docs.python.org/3/library/pathlib.html) · [realpython.com/python-pathlib](https://realpython.com/python-pathlib/)

```python
from pathlib import Path

# Percorso relativo alla directory corrente
p = Path("dati.csv")

# Percorso relativo allo script stesso (più robusto)
p = Path(__file__).parent / "dati.csv"

# Verificare che il file esista
if p.exists():
    print(f"File trovato: {p}")

# Leggere il contenuto come testo
testo = p.read_text(encoding="utf-8")

# Ottenere nome file, estensione, directory parent
print(p.name)       # "dati.csv"
print(p.stem)       # "dati"
print(p.suffix)     # ".csv"
print(p.parent)     # directory contenente il file
```

---

### `pandas` — Lettura e manipolazione dati tabulari

`pandas` è la libreria standard per lavorare con dati strutturati (CSV, Excel, tabelle).

**Tutorial:** [w3schools.com/python/pandas](https://www.w3schools.com/python/pandas/default.asp) · [pandas.pydata.org/docs](https://pandas.pydata.org/docs/getting_started/intro_tutorials/index.html)

```python
import pandas as pd

# Leggere un CSV
df = pd.read_csv("dati.csv")

# Visualizzare le prime righe
print(df.head())

# Accedere a una colonna
print(df["nome_colonna"])

# Filtrare le righe per condizione
filtrato = df[df["categoria"] == "valore"]

# Iterare sulle righe
for _, riga in df.iterrows():
    print(riga["colonna_a"], riga["colonna_b"])

# Convertire in stringa formattata
stringa = df.to_string(index=False)

# Convertire in lista di dizionari
records = df.to_dict(orient="records")
# → [{"colonna_a": ..., "colonna_b": ...}, ...]
```

---

### `json` — Serializzazione e parsing JSON

`json` è la libreria standard Python per lavorare con il formato JSON.

**Tutorial:** [docs.python.org/3/library/json](https://docs.python.org/3/library/json.html) · [w3schools.com/python/python_json](https://www.w3schools.com/python/python_json.asp)

```python
import json

# Parsare una stringa JSON → dizionario Python
testo_json = '{"nome": "Alice", "eta": 30, "hobby": ["lettura", "nuoto"]}'
dati = json.loads(testo_json)
print(dati["nome"])     # "Alice"
print(dati["hobby"])    # ["lettura", "nuoto"]

# Convertire un dizionario Python → stringa JSON
dati = {"risultati": [{"id": 1, "valore": 42}, {"id": 2, "valore": 7}]}
stringa = json.dumps(dati, indent=2, ensure_ascii=False)
print(stringa)

# Verificare che una stringa sia JSON valido
try:
    dati = json.loads(testo)
    print("JSON valido")
except json.JSONDecodeError as e:
    print(f"JSON non valido: {e}")

# Accedere a strutture annidate
for elemento in dati["risultati"]:
    print(elemento["id"], elemento["valore"])
```
