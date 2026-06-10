"""
Funzione di embedding Ollama per ChromaDB.

Usa all-minilm (disponibile via `ollama pull all-minilm`) coerentemente
con le lezioni del corso.  ChromaDB chiama ef(lista_di_testi) e si aspetta
una lista di vettori float — questa classe implementa quell'interfaccia.
"""

from chromadb import EmbeddingFunction, Documents, Embeddings
from ollama import Client

from config import EMBED_MODEL, OLLAMA_HOST


class OllamaEmbeddingFunction(EmbeddingFunction):
    def __init__(self, model: str = EMBED_MODEL, host: str = OLLAMA_HOST):
        self._client = Client(host=host)
        self._model  = model

    def __call__(self, input: Documents) -> Embeddings:
        response = self._client.embed(model=self._model, input=list(input))
        return response.embeddings
