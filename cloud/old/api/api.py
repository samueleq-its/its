from fastapi import FastAPI
import os
import json
from typing import Any
from functools import partialmethod, Placeholder

app = FastAPI()

class Repository:

	db: dict[str, Any] = {}
	
	def __init__(self) -> None:
		DATA_PATH = os.path.join(os.path.dirname(__file__), "films_dict.json")
		if os.path.exists(DATA_PATH):
			with open(DATA_PATH, "r", encoding="utf-8") as f:
				self.db = json.load(f)

	def find_by_title(self, title: str) -> list[dict]:
		film_keys = self.db.get(f"TITLE#{title.lower()}", [])
		return [self.db[key] for key in film_keys]

	def find_by_director(self, title: str) -> list[dict]:
		film_keys = self.db.get(f"DIRECTOR#{title.lower()}", [])
		return [self.db[key] for key in film_keys]

	def find_by_actor(self, title: str) -> list[dict]:
		film_keys = self.db.get(f"ACTOR#{title.lower()}", [])
		return [self.db[key] for key in film_keys]

	def find_by_genre(self, title: str) -> list[dict]:
		film_keys = self.db.get(f"GENRE#{title.lower()}", [])
		return [self.db[key] for key in film_keys]

repo = Repository()

@app.get("/api/films/")
def get_films(title: str|None = None, director: str|None = None, actor: str|None = None, genre: str|None = None):

	result: list[dict]

	if title:
		results = repo.find_by_title(title)
	elif director:
		results = repo.find_by_director(director)
	elif actor:
		results = repo.find_by_actor(actor)
	elif genre:
		results = repo.find_by_genre(genre)
	else:
		return {"error": "missing search param"}
	
	return results

