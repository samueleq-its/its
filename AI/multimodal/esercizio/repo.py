import uuid

import chromadb
from typing import Sequence, Collection


from config import *

class Repo:
    def __init__(self):
        self.db = chromadb.PersistentClient("./db")
        self.collection = self.db.get_or_create_collection(
            name=COLLECTION_NAME
            )

    def reset_collection(self):
        try:
            self.db.delete_collection("collection")
            print("DB azzerato")
        except:
            print("impossibile azzerare DB")
        self.collection = self.db.get_or_create_collection(name=COLLECTION_NAME)

    def insert(self,
               embeddings : Sequence[float],
               description: str,
               img_path: str,
               metadata: dict = {}):

        doc_id = str(uuid.uuid4())
        metadata["image_uri"] = img_path

        self.collection.add(
            embeddings=[embeddings],
            documents=[description],
            metadatas=[metadata],
            ids=[doc_id],
        )

    def retrieve(self, query: str, top_k: int = 3):
        results = self.collection.query(
            query_texts=[query],
            n_results=top_k,
            include=['metadatas', 'documents', 'distances']
        )
        return results

    def size(self) -> int:
        return self.collection.count()