from config import *
from agent import Agent
import tools


agent = Agent(tool_definitions=tools.definitions, tools=tools.tools)

print("inserisci una domanda per l'assistente IA, EXIT o lascia vuoto per uscire:")

while True:
    user_input = input("> ")
    if user_input.upper() == "EXIT" or user_input == "":
        break

    risposta = agent.chat(user_input)

    print ("\n\n----------------------------------\n\n")
    print(risposta)




# TODO: loop di domande, mantenere memoria chat temporanea
# TODO: riassunto