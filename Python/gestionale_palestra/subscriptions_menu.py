import utils
from subscription import Subscription
from course import Course
from client import Client


def print_menu():
    funzioni_menu = [
    {"descrizione": "Nuova iscrizione", "funzione":add_sub},
    {"descrizione": "Elenco iscrizioni", "funzione":read},
    {"descrizione": "Trova/elimina iscrizione", "funzione":find_delete},
    ]

    while True:
       print("")
       fn = utils.crea_menu(funzioni_menu)
       print("")
       if fn == None:
            break
       fn()

def add_sub():
    while True:
        course = Course.find(utils.input_int("Inserisci il codice del corso: "))
        if course.id == 0:
            print("codice errato")
            break
        if course.available < 1:
            print("nessun posto disponibile")
            break
        break
    while True:
        client = Client.find(utils.input_int("Inserisci il codice del cliente: "))
        if client.id == 0:
            print("codice errato")
            break
        if not client.subscribed:
            print("il cliente deve avere un abbonamento attivo")
            break
        break
    if Subscription.add(course.id,client.id) == None:
        utils.print_pause("iscrizione già presente")

def read():
    text = ""
    for subscription in Subscription.read():
       text += subscription.to_string() + "\n"
    utils.print_pause(text.rstrip())

def find_delete():
    while True:
        course = Course.find(utils.input_int("Inserisci il codice del corso: "))
        if course.id == 0:
            utils.print_pause("codice errato")
            break
        break
    while True:
        client = Client.find(utils.input_int("Inserisci il codice del cliente: "))
        if client == 0:
            utils.print_pause("codice errato")
            break
        break
    sub = Subscription.find(course.id, client.id)
    if sub.id_course == 0:
        print("iscrizione non trovata")
        return
    print("iscrizione presente")
    if utils.domanda("Eliminare l'iscrizione? s/n"):
        sub.delete()


if __name__ == "__main__":
    print_menu()