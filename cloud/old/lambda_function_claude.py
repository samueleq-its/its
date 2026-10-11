import json
import os
from typing import Any
import boto3
from boto3.dynamodb.conditions import Key

# Reuse client and table across invocations
TABLE_NAME = os.environ.get("TABLE_NAME", "Films")
dynamodb = boto3.resource("dynamodb")
table = dynamodb.Table(TABLE_NAME)


def get_films_by_entity(entity_type: str, entity_value: str) -> list[dict[str, Any]]:
    """
    1. Queries the pointer record (e.g. PK = 'ACTOR#sigourney weaver')
    2. Collects target film keys (e.g. PK = 'FILM#f01', SK = 'FILM')
    3. Batch retrieves the main film items
    """
    # Standardize PK prefix and value (e.g., ACTOR#sigourney weaver)
    pk = f"{entity_type.upper()}#{entity_value.strip().lower()}"

    # Step 1: Query pointer items matching the partition key
    query_response = table.query(
        KeyConditionExpression=Key("PK").eq(pk)
    )
    pointer_items = query_response.get("Items", [])

    if not pointer_items:
        return []

    # Step 2: Build keys to fetch main film records
    # Pointer item SK contains the film ID (e.g. "FILM#f01")
    film_keys = [{"PK": item["SK"], "SK": "FILM"} for item in pointer_items]

    # Step 3: Fetch full film documents in batch
    batch_response = dynamodb.batch_get_item(
        RequestItems={
            TABLE_NAME: {
                "Keys": film_keys
            }
        }
    )

    return batch_response.get("Responses", {}).get(TABLE_NAME, [])


def lambda_handler(event: dict[str, Any], context: Any) -> dict[str, Any]:
    # Extract HTTP method (handles Payload v1 and v2)
    method: str = (
        event.get("httpMethod")
        or event.get("requestContext", {}).get("http", {}).get("method", "")
    ).upper()

    if method != "GET":
        return response(405, {"error": "Wrong method, use GET"})

    path_params: dict[str, str] = event.get("pathParameters") or {}

    # Identify search entity and parameter
    entity_type = None
    search_val = None

    for param in ["title", "actor", "director", "genre"]:
        if param in path_params:
            entity_type = param
            search_val = path_params[param]
            break

    if not entity_type or not search_val:
        return response(400, {"error": "Missing search parameter"})

    # Query DynamoDB
    films = get_films_by_entity(entity_type, search_val)

    if not films:
        return response(404, {"error": f"No films found for {entity_type} '{search_val}'"})

    return response(200, films)


def response(status: int, body: Any) -> dict[str, Any]:
    return {
        "statusCode": status,
        "headers": {"Content-Type": "application/json"},
        "body": json.dumps(body),
    }