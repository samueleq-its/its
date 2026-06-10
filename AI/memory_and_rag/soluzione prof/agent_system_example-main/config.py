from pathlib import Path

BASE_DIR     = Path(__file__).parent
MANUAL_PATH  = BASE_DIR / "docs" / "Manuale_Gestione_SIARB.pdf"
MEM_DIR      = BASE_DIR / "mem"
WARNING_FILE = MEM_DIR / "WARNING.md"
MEMORY_FILE  = MEM_DIR / "MEMORY.md"
KB_PATH      = BASE_DIR / "vdb"
MCP_SERVER   = BASE_DIR / "rag" / "mcp_rag_server.py"

MODEL       = "ministral-3:3b"
EMBED_MODEL = "all-minilm:latest"
OLLAMA_HOST = "http://localhost:11434"

MAX_WARNINGS         = 3
MAX_REACT_ITERATIONS = 3
MEMORY_WINDOW        = 5
