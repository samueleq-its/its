import json

from langchain_text_splitters import MarkdownTextSplitter
from ollama import Client
from config import *
from utils import embed,get_memory

SYSTEM_PROMPT = \
    """
    ## ISTRUZIONI:
    - utilizza gli strumenti forniti per recuperare informazioni o cercare messaggi precedenti 
    - rispondi unicamente in base alle informazioni disponibili tramite gli strumenti o nello storico della chat, indica chiaramente quando non hai informazioni sufficienti per rispondere
    - puoi utilizzare più strumenti contemporaneamente o in passi successivi
    
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

    def _genera_riassunto(self, message: str) -> str:
        system_prompt = \
f'''
riassumi il seguente testo in massimo 300 caratteri, mantenendo dati forniti dall'utente e informazioni chiave
'''
        response = self._client.chat(
            model=CHAT_MODEL,
            messages=[
                {
                    "role": "system",
                    "content": system_prompt
                },
                {
                    "role": "user",
                    "content": message
                }
            ],
            options={"num_predict":250}
        )
        print(f"riassunto generato: \n {response.message.content}")
        return response.message.content

    def _save_memory(self, user_message: str, response: str):
        documento = f"Utente: {user_message}\nAssistente: {response}"

        riassunto = self._genera_riassunto(documento)
        embedding = embed(riassunto)

        memoria_chat = get_memory()
        memoria_chat.add(
            embeddings=[embedding],
            documents=[documento],
            metadatas=[{"turno": self._rounds, "anteprima_user": user_message[:80]}],
            ids=[f"turno_{self._rounds}"]
        )

    def _update_history(self, user_message: str, response: str, max_lenght: int):
        print("DEBUG: updating history...")
        self.history.append({"role": "user", "content": user_message})
        self.history.append({"role": "assistant", "content": response})
        print(self.history)

        if len(self.history) > max_lenght * 2:
            print("DEBUG: culling history...")
            self.history.pop(0)
            self.history.pop(0)

    def _append_history(self):
        history_text = ""
        for entry in self.history:
            history_text += f"{entry['role']} {entry['content']}"

    def chat(self, user_message: str):
        # SI ROMPE DIZIONARIO
        system_prompt = SYSTEM_PROMPT + f"""
        ## MESSAGGI PRECEDENTI:
        {self._append_history()} 
        """
        print(system_prompt)
        messages = [{"role": "system", "content": system_prompt}, {"role": "user", "content": user_message}]

        response = self._chat_tools(messages)

        self._save_memory(user_message, response)
        self._update_history(user_message, response, max_lenght=3)

        self._rounds += 1
        return response