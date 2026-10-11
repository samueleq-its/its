import json
import os
from typing import Any

DATA_PATH = os.path.join(os.path.dirname(__file__), "films_dict.json")

# Load the JSON data during Lambda initialization (cold start)
db: dict[str, Any] = {}
if os.path.exists(DATA_PATH):
    with open(DATA_PATH, "r", encoding="utf-8") as f:
        db = json.load(f)

def response(status: int, body: Any) -> dict[str, Any]:
    return {
        "statusCode": status,
        "headers": {"Content-Type": "application/json"},
        "body": json.dumps(body),
    }

def lambda_handler(event: dict[str, Any], context: Any) -> dict[str, Any]:
    # Safely retrieve HTTP method across API Gateway payload formats
    request_context = event.get("requestContext") or {}
    http_info = request_context.get("http") or {}
    method: str = (event.get("httpMethod") or http_info.get("method") or "").upper()

    if method != "GET":
        return response(405, {"error": "wrong method, use GET"})

    path_params: dict[str, str] = event.get("queryStringParameters") or {}

    film_keys: list[str] = []

    if "title" in path_params:
        film_keys = db.get(f"TITLE#{path_params['title'].lower()}", [])
    elif "actor" in path_params:
        film_keys = db.get(f"ACTOR#{path_params['actor'].lower()}", [])
    elif "director" in path_params:
        film_keys = db.get(f"DIRECTOR#{path_params['director'].lower()}", [])
    elif "genre" in path_params:
        film_keys = db.get(f"GENRE#{path_params['genre'].lower()}", [])
    else:
        return response(400, {"error": "missing search param"})

    # Fetch corresponding film objects from db
    results = [db[key] for key in film_keys if key in db]

    return response(200, results)