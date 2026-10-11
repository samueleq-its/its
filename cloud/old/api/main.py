from fastapi import FastAPI
import os
import json
from typing import Any

app = FastAPI()

#region CONTROLLER
@app.get("/api/films/")
def get_films(title: str|None = None, director: str|None = None, actor: str|None = None, genre: str|None = None) -> list[dict]:

	if title:
		pass
	elif director:
		pass
	elif actor:
		pass
	elif genre:
		pass
	else:
		pass
	return []

@app.get("/api/films/{id}")
def get_by_id(id: int) -> dict:
	return {}

# TODO: other crud routes

#endregion


#region SERVICE

# TODO implementation
def find_all_films() -> list[dict]:
	return []

def find_by_title() -> list[dict]:
	return []

#endregion


#region REPO
# TODO use sqlite

#endregion



