from ollama import Client
import json

MODEL = 'llama3.2:latest'

class ChatModel:
    def __init__(self, top_p=1.0, temperature=0.5, output_length=3000):
        self.client = Client(host='http://localhost:11434')
        self.top_p = top_p
        self.temperature = temperature
        self.output_length = output_length


    def set_parameters(self, top_p=1.0, temperature=0.5):
        self.top_p = top_p
        self.temperature = temperature


    def complete(self, prompt: str, system: str = ""):
        messages = []
        if system:
            messages.append({'role': 'system', 'content': system})
        messages.append({'role': 'user', 'content': prompt})

        response = self.client.chat(
            model=MODEL,
            messages=messages,
            options={
                'temperature': self.temperature,
                'top_p': self.top_p,
                'num_predict': self.output_length
            }
        )
        return response.message.content


    def complete_structured(self, prompt: str, schema: dict, system: str = ""):
        messages = []
        if system:
            messages.append({'role': 'system', 'content': system})
        messages.append({'role': 'user', 'content': prompt})

        response = self.client.chat(
            model=MODEL,
            messages=messages,
            format=schema,
            options={
                'temperature': self.temperature,
                'top_p': self.top_p,
                'num_predict': self.output_length
            }
        )
        return response.message.content
