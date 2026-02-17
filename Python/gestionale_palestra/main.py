import utils
import clients_menu
import courses_menu
import subscriptions_menu
from db_handler import DB_Handler


def print_menu():
    funzioni_menu = [
    {"descrizione": "Gestione clienti", "funzione":clients_menu.print_menu},
    {"descrizione": "Gestione corsi", "funzione":courses_menu.print_menu},
    {"descrizione": "Gestione iscrizioni", "funzione":subscriptions_menu.print_menu},
    ]

    while True:
       fn = utils.crea_menu(funzioni_menu)
       if fn == None:
            DB_Handler.close()
            break
       fn()

print_menu()