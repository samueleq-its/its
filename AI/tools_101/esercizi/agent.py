import json
from typing import Callable

from ollama import Client

MODEL = 'ministral-3:3b'

SYSTEM_PROMPT = \
"""
# ROLE
You are a front-end assistant for a database system. Your job is to answer user queries by using
the tools provided to inspect, query, and summarize database data.

# CONTEXT
- Use the available tools to retrieve facts before answering.
- Be accurate, concise, and grounded in tool results.
- Never invent data or claim you ran a query you did not run.
- When a tool can answer the question, use it first and present the result clearly to the user.
- If a tool returns an error or incomplete data, explain the issue plainly and suggest the next best step.
- the user cannot respond, if a request is ambiguous ask for clarification but still attempt to respond
- you can use multiple tools together or call them in subsequent steps 
"""

class SimpleAgent:
    def __init__(self, top_p=1.0):
        self.client = Client(host='http://localhost:11434')

    def chat(self, messages: list[dict]):
        response = self.client.chat(
            model=MODEL,
            messages=messages
        )
        return response["message"]["content"]

    def tools(self, messages: list[dict], tools: list[dict]):
        return self.client.chat(
            model=MODEL,
            messages=messages,
            tools=tools
        )


def agent_database(user_message: str, tool_definitions: list[dict], tools: dict[str, Callable]):
    MAX_ITERATIONS = 5

    agent = SimpleAgent()
    messages = [{"role": "system", "content": SYSTEM_PROMPT},{"role": "user", "content": user_message}]

    for iteration in range(MAX_ITERATIONS): # TODO: turn into while?
        response = agent.tools(messages, tool_definitions)

        if not response["message"].get("tool_calls"): # TODO potrebbe andare nel while?
            return response['message']['content']

        # L'LLM si attiva per usare uno o più tool!
        print(f"\n{'=' * 70}")
        print(f"ITERAZIONE {iteration
                            + 1}")
        print(f"{'=' * 70}")

        # Aggiungi il messaggio dell'LLM
        messages.append(response['message'])

        # Esegui TUTTI i tool richiesti dall'LLM
        for tool_call in response['message']['tool_calls']:
            tool_name = tool_call['function']['name']
            arguments = tool_call['function']['arguments']

            print(f"\n - Tool Chiamato: {tool_name}")
            print(f" - Argomenti: {json.dumps(arguments, indent=2)}")

            if tool := tools.get(tool_name):
                try:
                    result = tool(**arguments)

                    # Mostra risultato (troncato se troppo lungo)
                    result_str = json.dumps(result, indent=2, ensure_ascii=False)
                    if len(result_str) > 300:
                        print(f"- Risultato: {result_str[0:300]}...")
                    else:
                        print(f"- Risultato: {result_str}")

                    # Aggiungi risultato alla storia per l'LLM
                    messages.append({
                        'role': 'tool',
                        'content': json.dumps(result)
                    })
                except Exception as e:
                    error_msg = f"Errore esecuzione {tool_name}: {str(e)}"
                    print(error_msg)

                    messages.append({
                        'role': 'tool',
                        'content': json.dumps({'error': error_msg})
                    })
            else:
                print(f" Funzione sconosciuta: {tool_name}")

    return "Query troppo complessa - raggiunto limite iterazioni. Prova a semplificare la richiesta."


if __name__ == "__main__":
    agent = SimpleAgent()
    response = agent.chat([{"role": "user", "content": "hi"}])
    print(response)
