import gradio as gr
from ollama import Client



MODEL = 'ministral-3:3b'

class ChatModel:
    def __init__(self, top_p = 1.0, temperature = 0.5, output_length = 3000):
      
        self.client =  Client(host='http://localhost:11434')
        self.top_p = top_p
        self.temperature = temperature
        self.output_length = output_length


    def set_parameters(self, top_p = 1.0, temperature = 0.5):
        self.top_p = top_p
        self.temperature = temperature


    def complete(self, prompt: str):
        response = self.client.chat(
            model=MODEL,
             messages=[
                {
                    'role': 'user',
                    'content': prompt,
                },
            ],
            options={
                'temperature': self.temperature, 
                'top_p': self.top_p,
                'num_predict': self.output_length
            }
        )
        return response.message.content




# Chat function
def chat(message, history):
    model = ChatModel()
    return model.complete(message)




# MAIN
if __name__ == "__main__":
    gr.ChatInterface(fn=chat).launch()