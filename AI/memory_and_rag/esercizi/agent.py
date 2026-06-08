import json
from ollama import Client
from config import *
from utils import embed,get_memory

SYSTEM_PROMPT = \
    """
    ## ISTRUZIONI:
    Sei un assistente esperto. Rispondi alla domanda basandoti ESCLUSIVAMENTE sul contesto fornito e sullo storico della chat.
    Se la risposta non è nel contesto, rispondi: "Non ho informazioni sufficienti nel documento o nello storico della chat."
    utilizza gli strumenti forniti per recuperare informazioni o leggere lo storico della chat
    puoi utilizzare più strumenti contemporaneamente o in passi successivi
    
    """


class Agent:
    MAX_ITERATIONS = 5

    def __init__(self, tool_definitions: list[dict], tools: list[dict]):
        self._client = Client(host='http://localhost:11434')
        self._tool_definitions = tool_definitions
        self._tools = tools
        self._rounds = 0
        self.history = list()

    def _chat_tools(self, messages: list[dict[str, str]]) -> str:

        for iteration in range(self.MAX_ITERATIONS):
            response = self._client.chat(
                model=CHAT_MODEL,
                messages=messages,
                tools=self._tool_definitions
            )

            if not response["message"].get("tool_calls"):
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

                if tool := self._tools.get(tool_name):
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

    def _save_memory(self, user_message: str, response: str):
        documento = f"Utente: {user_message}\nAssistente: {response}"
        embedding = embed(documento)

        memoria_chat = get_memory()
        memoria_chat.add(
            embeddings=[embedding],
            documents=[documento],
            metadatas=[{"turno": self._rounds, "anteprima_user": user_message[:80]}],
            ids=[f"turno_{self._rounds}"]
        )



    def chat(self, user_message: str):
        messages = [{"role": "system", "content": SYSTEM_PROMPT}, {"role": "user", "content": user_message}]

        response = self._chat_tools(messages)

        self._save_memory(user_message, response)


        self._rounds += 1
