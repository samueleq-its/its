import sqlite3
import json
from pathlib import Path
from mcp.server.fastmcp import FastMCP

DB_PATH = Path(__file__).parent / "db" / "libreria.db"
mcp = FastMCP("libreria")


@mcp.tool()
def query_database(query: str) -> str:
    """Esegue una query SQL SELECT sul database libreria. Restituisce i risultati in JSON."""
    if not query.strip().upper().startswith("SELECT"):
        return "Errore: solo query SELECT sono permesse"
    try:
        conn = sqlite3.connect(DB_PATH)
        conn.row_factory = sqlite3.Row
        cursor = conn.cursor()
        cursor.execute(query)
        rows = [dict(row) for row in cursor.fetchall()]
        conn.close()
        return json.dumps(rows, indent=2, ensure_ascii=False)
    except Exception as e:
        return f"Errore: {e}"


@mcp.tool()
def get_table_info(table_name: str) -> str:
    """Ottiene schema e numero di righe di una tabella del database."""
    try:
        conn = sqlite3.connect(DB_PATH)
        cursor = conn.cursor()
        cursor.execute(f"PRAGMA table_info({table_name})")
        columns = [{"name": r[1], "type": r[2], "not_null": bool(r[3])} for r in cursor.fetchall()]
        cursor.execute(f"SELECT COUNT(*) FROM {table_name}")
        count = cursor.fetchone()[0]
        conn.close()
        return json.dumps({"table": table_name, "rows": count, "columns": columns}, indent=2, ensure_ascii=False)
    except Exception as e:
        return f"Errore: {e}"


@mcp.resource("sqlite://libreria/schema")
def get_schema() -> str:
    """Schema completo del database libreria in formato JSON."""
    conn = sqlite3.connect(DB_PATH)
    cursor = conn.cursor()
    cursor.execute("SELECT name FROM sqlite_master WHERE type='table' AND name NOT LIKE 'sqlite_%'")
    tables = [r[0] for r in cursor.fetchall()]
    schema = {}
    for t in tables:
        cursor.execute(f"PRAGMA table_info({t})")
        schema[t] = [{"name": r[1], "type": r[2]} for r in cursor.fetchall()]
    conn.close()
    return json.dumps(schema, indent=2, ensure_ascii=False)


if __name__ == "__main__":
    mcp.run(transport="stdio")
