import utils
from client import Client


def print_menu():
    funzioni_menu = [
    {"descrizione": "Aggiungi nuovo cliente", "funzione":new_client},
    {"descrizione": "Mostra clienti", "funzione":print_clients},
    {"descrizione": "Cerca Cliente", "funzione":find_client},
    ]

    while True:
       fn = utils.crea_menu(funzioni_menu)
       if fn == None:
            break
       fn()

def new_client():
    name = input("inserisci il nome del cliente: ")
    surname = input("inserisci il cognome del cliente: ")
    utils.print_pause("aggiunto: " + Client.add(name, surname).to_string())

def print_clients():
    clients = Client.read()
    for client in clients:
        print(client.to_string())
    utils.print_pause("")

def find_client():
    id = utils.input_int("inserisci l'id del cliente: ")
    client = Client.find(id)
    if client.id == 0:
        print("cliente non trovato")
        return
    print(client.to_string())
    if utils.domanda("modificare l'abbonamento? s/n: "):
        client.set_subscription(not client.subscribed)
    elif utils.domanda("eliminare il cliente? s/n: "):
        client.delete()


if __name__ == "__main__":
    print_menu()