"""
MCP Server — Banca Database

Espone strumenti di lettura sul database SQLite banca.db.
Trasporto: stdio (avviato dal client MCP come sottoprocesso).

Strumenti disponibili:
  - cerca_cliente(nome, cognome)       → dati anagrafici
  - saldo_conto(cliente_id)            → saldo e tipo conto
  - ultimi_movimenti(conto_id, n)      → n movimenti recenti
  - prestiti_cliente(cliente_id)       → prestiti attivi
  - lista_clienti()                    → tutti i clienti (solo id, nome, cognome)

ATTENZIONE: il server non implementa autenticazione ne autorizzazione.
E compito del sistema agentico operare in modo sicuro.
"""

import sqlite3
from pathlib import Path
from mcp.server.fastmcp import FastMCP

DB_PATH = Path(__file__).parent / "banca.db"

mcp = FastMCP("banca-mcp")


def _conn() -> sqlite3.Connection:
    conn = sqlite3.connect(DB_PATH)
    conn.row_factory = sqlite3.Row
    return conn


@mcp.tool()
def lista_clienti() -> list[dict]:
    """Restituisce id, nome e cognome di tutti i clienti."""
    with _conn() as conn:
        rows = conn.execute(
            "SELECT id, nome, cognome FROM clienti ORDER BY cognome, nome"
        ).fetchall()
    return [dict(r) for r in rows]


@mcp.tool()
def cerca_cliente(nome: str = "", cognome: str = "") -> list[dict]:
    """
    Cerca clienti per nome o cognome (ricerca parziale, case-insensitive).
    Restituisce dati anagrafici completi incluso codice fiscale e data di nascita.
    """
    with _conn() as conn:
        rows = conn.execute(
            """
            SELECT id, nome, cognome, email, codice_fiscale, data_nascita
            FROM clienti
            WHERE LOWER(nome) LIKE LOWER(?) OR LOWER(cognome) LIKE LOWER(?)
            """,
            (f"%{nome}%", f"%{cognome}%"),
        ).fetchall()
    return [dict(r) for r in rows]


@mcp.tool()
def saldo_conto(cliente_id: int) -> list[dict]:
    """
    Restituisce saldo, IBAN e tipo di tutti i conti del cliente.
    Richiede il cliente_id numerico.
    """
    with _conn() as conn:
        rows = conn.execute(
            "SELECT id, iban, saldo, tipo FROM conti WHERE cliente_id = ?",
            (cliente_id,),
        ).fetchall()
    return [dict(r) for r in rows]


@mcp.tool()
def ultimi_movimenti(conto_id: int, n: int = 5) -> list[dict]:
    """
    Restituisce gli ultimi n movimenti del conto (default: 5, max: 50).
    """
    n = min(max(1, n), 50)
    with _conn() as conn:
        rows = conn.execute(
            """
            SELECT data, importo, descrizione
            FROM movimenti
            WHERE conto_id = ?
            ORDER BY data DESC, id DESC
            LIMIT ?
            """,
            (conto_id, n),
        ).fetchall()
    return [dict(r) for r in rows]


@mcp.tool()
def prestiti_cliente(cliente_id: int) -> list[dict]:
    """
    Restituisce i prestiti attivi del cliente con importo, tasso e stato.
    """
    with _conn() as conn:
        rows = conn.execute(
            """
            SELECT id, importo, tasso_annuo, durata_mesi, data_inizio, stato
            FROM prestiti
            WHERE cliente_id = ?
            """,
            (cliente_id,),
        ).fetchall()
    return [dict(r) for r in rows]


if __name__ == "__main__":
    mcp.run(transport="stdio")
