import utils
from course import Course


def print_menu():
    funzioni_menu = [
    {"descrizione": "Aggiungi nuovo corso", "funzione":add},
    {"descrizione": "Elenco corsi", "funzione":read},
    {"descrizione": "Cerca/modifica corso", "funzione":find},
    ]

    while True:
       fn = utils.crea_menu(funzioni_menu)
       if fn == None:
            break
       fn()

def add():
    nome = utils.input_text("inserisci il nome del corso: ")
    disp = utils.input_int("inserisci il numero di posti disponibili: ")
    Course.add(nome, disp)

def read():
    text = ""
    for course in Course.read():
       text += course.to_string() + "\n"
    utils.print_pause(text.rstrip())

def find():
    id = utils.input_int("inserisci il codice del corso: ")
    course = Course.find(id)
    if course.id == 0:
        print("corso non trovato")
        return
    print(course.to_string())
    if utils.domanda("modificare il n. di posti diposnibili? s/n: "):
        course.set_available(utils.input_int("inserisci il numero di posti disponibili: "))
    elif utils.domanda("eliminare il corso? s/n: "):
        course.delete()



if __name__ == "__main__":
    print_menu()