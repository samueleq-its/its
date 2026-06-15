from typing import Sequence

import ollama

from config import *



def embed(documento: str) -> Sequence[float]:
    return ollama.embed(model=EMBEDDING_MODEL, input=documento, options={"num_ctx ": 8192}).embeddings[0]