from chromadb.utils import embedding_functions


if __name__ == "__main__":
    em = embedding_functions.SentenceTransformerEmbeddingFunction(
            model_name="all-MiniLM-L6-v2"
        )