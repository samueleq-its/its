"""
Crea e popola banca.db con dati bancari finti.
Esegui una sola volta: python seed_db.py
"""

import sqlite3
import random
from pathlib import Path

DB_PATH = Path(__file__).parent / "banca.db"

CLIENTI = [
    (1, "Mario",    "Rossi",     "mario.rossi@email.it",     "RSSMRA80A01H501Z", "1980-01-01"),
    (2, "Lucia",    "Bianchi",   "lucia.bianchi@email.it",   "BNCLCU85B41F205X", "1985-02-01"),
    (3, "Giovanni", "Verdi",     "g.verdi@email.it",         "VRDGNN72C03L219K", "1972-03-03"),
    (4, "Anna",     "Ferrari",   "anna.ferrari@email.it",    "FRRNNA90D44H501W", "1990-04-04"),
    (5, "Luca",     "Esposito",  "l.esposito@email.it",      "SPSLCU88E05F839P", "1988-05-05"),
    (6, "Sara",     "Romano",    "sara.romano@email.it",     "RMNSRA95F46H501A", "1995-06-06"),
    (7, "Marco",    "Colombo",   "m.colombo@email.it",       "CLMMRC77G07F205B", "1977-07-07"),
    (8, "Elena",    "Ricci",     "elena.ricci@email.it",     "RCCLNE92H48L219C", "1992-08-08"),
    (9, "Paolo",    "Marino",    "p.marino@email.it",        "MRNPLA68I09H501D", "1968-09-09"),
    (10,"Chiara",   "Gallo",     "chiara.gallo@email.it",    "GLLCHR98L50F839E", "1998-12-10"),
]

CONTI = [
    (101, 1, "IT60X0542811101000000123456", 12450.00,  "corrente"),
    (102, 2, "IT60X0542811101000000234567", 67300.00,  "corrente"),
    (103, 3, "IT60X0542811101000000345678",  3200.00,  "corrente"),
    (104, 4, "IT60X0542811101000000456789", 28750.50,  "corrente"),
    (105, 5, "IT60X0542811101000000567890",  8100.00,  "corrente"),
    (106, 6, "IT60X0542811101000000678901", 15600.75,  "risparmio"),
    (107, 7, "IT60X0542811101000000789012", 42000.00,  "risparmio"),
    (108, 8, "IT60X0542811101000000890123",  5900.00,  "corrente"),
    (109, 9, "IT60X0542811101000000901234", 89000.00,  "risparmio"),
    (110,10, "IT60X0542811101000000012345",  2300.25,  "corrente"),
]

MOVIMENTI = [
    # id, conto_id, data, importo (+ entrata, - uscita), descrizione
    (1,  101, "2026-05-01",  +2500.00, "Stipendio maggio"),
    (2,  101, "2026-05-03",   -120.00, "Supermercato"),
    (3,  101, "2026-05-10",   -800.00, "Affitto"),
    (4,  102, "2026-05-01",  +4200.00, "Stipendio maggio"),
    (5,  102, "2026-05-05",  -1500.00, "Rate mutuo"),
    (6,  102, "2026-05-15", +45000.00, "Bonifico investimento"),
    (7,  103, "2026-05-01",  +1800.00, "Stipendio maggio"),
    (8,  103, "2026-05-12",   -250.00, "Bollette"),
    (9,  104, "2026-05-01",  +3100.00, "Stipendio maggio"),
    (10, 104, "2026-05-20",  -5000.00, "Acquisto auto"),
    (11, 105, "2026-05-01",  +2200.00, "Stipendio maggio"),
    (12, 105, "2026-05-08",   -400.00, "Abbonamento palestra annuale"),
    (13, 106, "2026-05-01",  +1600.00, "Accredito interessi"),
    (14, 107, "2026-05-02", +10000.00, "Trasferimento da corrente"),
    (15, 109, "2026-05-01",  +6000.00, "Pensione maggio"),
]

PRESTITI = [
    (1, 3, 15000.00, 8.5,  36, "2024-01-15", "in corso"),
    (2, 5,  8000.00, 6.2,  24, "2025-03-01", "in corso"),
    (3, 8, 25000.00, 7.8,  60, "2023-06-10", "in corso"),
    (4, 1,  5000.00, 9.0,  12, "2025-11-01", "in corso"),
]

def seed():
    if DB_PATH.exists():
        DB_PATH.unlink()

    conn = sqlite3.connect(DB_PATH)
    cur = conn.cursor()

    cur.executescript("""
        CREATE TABLE clienti (
            id          INTEGER PRIMARY KEY,
            nome        TEXT NOT NULL,
            cognome     TEXT NOT NULL,
            email       TEXT NOT NULL,
            codice_fiscale TEXT NOT NULL,
            data_nascita   TEXT NOT NULL
        );

        CREATE TABLE conti (
            id          INTEGER PRIMARY KEY,
            cliente_id  INTEGER NOT NULL REFERENCES clienti(id),
            iban        TEXT NOT NULL,
            saldo       REAL NOT NULL,
            tipo        TEXT NOT NULL
        );

        CREATE TABLE movimenti (
            id          INTEGER PRIMARY KEY,
            conto_id    INTEGER NOT NULL REFERENCES conti(id),
            data        TEXT NOT NULL,
            importo     REAL NOT NULL,
            descrizione TEXT NOT NULL
        );

        CREATE TABLE prestiti (
            id              INTEGER PRIMARY KEY,
            cliente_id      INTEGER NOT NULL REFERENCES clienti(id),
            importo         REAL NOT NULL,
            tasso_annuo     REAL NOT NULL,
            durata_mesi     INTEGER NOT NULL,
            data_inizio     TEXT NOT NULL,
            stato           TEXT NOT NULL
        );
    """)

    cur.executemany(
        "INSERT INTO clienti VALUES (?,?,?,?,?,?)", CLIENTI
    )
    cur.executemany(
        "INSERT INTO conti VALUES (?,?,?,?,?)", CONTI
    )
    cur.executemany(
        "INSERT INTO movimenti VALUES (?,?,?,?,?)", MOVIMENTI
    )
    cur.executemany(
        "INSERT INTO prestiti VALUES (?,?,?,?,?,?,?)", PRESTITI
    )

    conn.commit()
    conn.close()
    print(f"Database creato: {DB_PATH}")
    print(f"  {len(CLIENTI)} clienti, {len(CONTI)} conti, "
          f"{len(MOVIMENTI)} movimenti, {len(PRESTITI)} prestiti")

if __name__ == "__main__":
    seed()
