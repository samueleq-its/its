import json
import boto3


dynamodb = boto3.resource('dynamodb')
# table = dynamodb.Table("films")
dynamodb.Table("aaa")

def lambda_handler(event, context):
    FILM_TITLE = "Alien"
    # try:
    # response = table.get_item(
    #     key={
    #         'film_title': FILM_TITLE
    #     },
    #     ConsistentRead=False
    # )
    # except Exception as e:
    #     response = e

    return {
        'statusCode': 200,
        'body': json.dumps("response_iterator")
    }
