from ollama import Client

client = Client()

messages = [
	{
	"role":"user",
	"content":"What is the capital of France?"
	}
]

# response = client.chat("ministral-3:3b", messages=messages)
# print(response.message.content)

for part in client.chat('ministral-3:3b', messages=messages, stream=True):
  print(part.message.content, end='', flush=True)