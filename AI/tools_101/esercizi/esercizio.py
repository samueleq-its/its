import agent, tools
from functools import partial

# Implementa le seguenti funzionalità:
#
# Importazione Dataset: Carica i dati CSV in un database SQLite
# Funzioni SQL: Crea almeno 5 funzioni Python che eseguono query sul database
# Tool Definitions: Definisci gli schemi JSON per ogni funzione
# Agente Conversazionale: Implementa un agente che risponde a query in linguaggio naturale

# Domande Esempio da Supportare
#
# "Qual è il fatturato totale per paese?"
# "Chi sono i top 5 clienti per volume di acquisti?"
# "Mostrami i prodotti più venduti nel ..."
# "In quale trimestre abbiamo avuto le migliori performance di vendita?"

#tool_agent = partial(agent.agent_database, tool_definitions=tools.definitions, tools=tools.tools)

def main():
    print("write query for AI: ")
    query = input()

    result  = agent.agent_database(query, tools.definitions, tools.tools)
    print(f"\n RISPOSTA FINALE:\n{result}")


if __name__ == "__main__":
    main()