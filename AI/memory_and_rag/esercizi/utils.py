import time
from typing import Sequence
import ollama
import chromadb
import pymupdf4llm
from chromadb import ClientAPI
from chromadb.api.models.Collection import Collection
from langchain_text_splitters import MarkdownTextSplitter
from config import *


def init_db(db_path: str) -> ClientAPI:
    return chromadb.PersistentClient(path=db_path)  # CREA DB PERSISTENTE


def get_collection(db: ClientAPI, nome: str) -> Collection:
    return db.get_or_create_collection(name=nome, metadata={"hnsw:space": "cosine"})

def get_kb():
    return get_collection(init_db(DB_PATH), KNOWLEDGE_BASE_NAME)

def get_memory():
    return get_collection(init_db(DB_PATH), CHAT_MEMORY_NAME)

def embed(documento: str) -> Sequence[float]:
    return ollama.embed(model=EMBEDDING_MODEL, input=documento, options={"num_ctx ": 8192}).embeddings[0]

def gen_embedding(file_path: str) -> list[tuple[str, Sequence[float]]]:
    CHUNK_SIZE = 1000  # 1000 (MAX 322?)
    CHUNK_OVERLAP = 200  # 200
    md_text = pymupdf4llm.to_markdown(file_path)
    splitter = MarkdownTextSplitter(chunk_size=CHUNK_SIZE, chunk_overlap=CHUNK_OVERLAP)

    results = list()

    chunks_list = splitter.split_text(md_text)
    embeddings_list = list()

    i: int = 0
    while i < len(chunks_list):
        cur_chunk = chunks_list[i]
        print(f"processando chunk {i + 1}/{len(chunks_list)}...")

        # try to generate embedding
        try:
            embedding: Sequence[float] = embed(cur_chunk)

        # if failed split chunk, try again
        except:
            print("embedding fallito")
            print(f"dimensioni chunk: {len(cur_chunk)}")
            chunk_size = len(cur_chunk) / 2
            chunk_overlap = chunk_size / 5

            chunk_splitter = MarkdownTextSplitter(chunk_size=chunk_size, chunk_overlap=chunk_overlap)
            subchunk_list = chunk_splitter.split_text(cur_chunk)

            chunks_list[i:i + 1] = subchunk_list
            continue

        # if succeded go to next
        embeddings_list.append(embedding)
        results.append((cur_chunk, embedding))
        i += 1
    print("embedding generati")

    return results


def get_embeddings_list(collection: Collection, query: str, num_risultati: int) -> list[str]:
    query_embedding = ollama.embed(model=EMBEDDING_MODEL, input=query).embeddings[0]
    risultati = collection.query(
        query_embeddings=[query_embedding],
        n_results=num_risultati
    )
    return risultati['documents'][0]


def get_embeddings(collection: Collection, query: str, num_risultati: int) -> str:
    chunk_recuperati = get_embeddings_list(collection, query, num_risultati)
    return "\n\n---\n\n".join(chunk_recuperati)
