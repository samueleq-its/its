"""
Fixtures condivise tra tutti i test.

Aggiunge la root del progetto al sys.path in modo che gli import
"from agents import ...", "from rag import ...", "from config import ..."
funzionino senza installare il pacchetto.
"""

import sys
from pathlib import Path

# root = esempio_completo/
sys.path.insert(0, str(Path(__file__).parent.parent))
