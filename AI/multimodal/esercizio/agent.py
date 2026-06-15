from pathlib import Path

from ollama import Client

from config import *

class MultimodalAgent:
    def __init__(self):
        self.client =  Client(host='http://localhost:11434')
        self.model = AGENT

    def complete(self,
                 user_message: str,
                 image_path: Path | None = None,
                 schema: dict | None = None,
                 temperature: float = 0.5):

        if image_path is not None:
            messages = [{
                "role": "user",
                "content": user_message,
                "images": [image_path]
            }]
        else:
            messages = [{
                "role": "user",
                "content": user_message
            }]

        response = self.client.chat(model=self.model,
                                    messages=messages,
                                    options={"temperature": temperature},
                                    format=schema)

        return response['message']['content']

    def describe(self, image_path: Path, temperature: float = 0.5):
        MAX_TOKENS = 200

        prompt = {
            "role": "system",
            "images": [image_path],
            "content": f"""
            # INSTRUCTIONS
            you are an image description agent.
            Your task is to generate an accurate description of the content of the image provided.
            Focus on the main elements of the image, such as objects, people, and their relationships.
            
            # OUTPUT FORMAT
            - description focused on the main elements of the image, such as objects, people, and their relationships.
            - output limited to {MAX_TOKENS} tokens.
            """
        }

        response = self.client.chat(model=self.model,
                         messages=[prompt],
                         options={
                             "temperature": temperature,
                             'num_predict': MAX_TOKENS
                            }
                         )
        return response['message']['content']