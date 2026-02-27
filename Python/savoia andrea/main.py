from service.UserService import *
from service.CourseService import *
from service.RegistrationService import *
import dump

def main():

    dump.dump()

    # Menu loop for user/course/registration management.
    while True:
        print("\n=== MENU GESTIONE CORSI ===")
        print("1. Inserisci utente")
        print("2. Aggiorna abbonamento utente")
        print("3. Cancella utente")
        print("4. Mostra utente")
        print("5. Mostra tutti gli utenti")
        print("6. Inserisci nuovo corso")
        print("7. Cancella corso")
        print("8. Modifica numero posti massimi")
        print("9. Mostra corso")
        print("10. Mostra lista dei corsi")
        print("11. Aggiungi nuova iscrizione")
        print("12. Mostra iscrizioni")
        print("13. Cancella Inscrizione")
        print("14. Esci")

        scelta = input("\nInserisci la tua scelta: ").strip()

        match scelta:
            # Route menu choice to the corresponding action.
            case "1":
                add_user()
            case "2":
                update_user_subscription()
            case "3":
                delete_user()
            case "4":
                show_user()
            case "5":
                show_all_users()
            case "6":
                add_course()
            case "7":
                delete_course()
            case "8":
                update_course_seats()
            case "9":
                show_course()
            case "10":
                show_all_courses()
            case "11":
                add_registration()
            case "12":
                find_all_registrations()
            case "13":
                delete_registration()
            case "14":
                print("Arrivederci!")
                break
            case _:
                print("Scelta non valida. Riprova.")


def add_user():
    name = input("\nInserisci nome: ")
    lastname = input("Inserisci cognome: ")
    print(UserService().save_user(name, lastname))
    input("premi invio per continuare...")

def update_user_subscription():
    id_user = input("\nInserisci codice abbonamento dell'utente: ").strip()
    print(UserService().update_subscription_state(id_user))
    input("premi invio per continuare...")

def delete_user() -> None:
    id_user = input("\nInserisci codice abbonamento dell'utente: ").strip()
    print(UserService().delete_user(id_user))
    input("premi invio per continuare...")

def show_user():
    id_user = input("\nInserisci codice abbonamento dell'utente: ").strip()
    print(UserService().find_user_by_id(id_user))
    input("premi invio per continuare...")

def show_all_users():
    users = UserService().find_all_users()
    if not users:
        print("non ci sono utenti registrati")
    else:
        for user in users:
            print(user)
    input("premi invio per continuare...")

def add_course():
    name = input("\nInserisci nome del corso: ")
    places = input("Inserisci i posti disponibili: ")
    print(CourseService().save_course(name, places))
    input("premi invio per continuare...")

def show_course():
    course_name = input("\nInserisci il nome del corso: ").strip()
    print(CourseService().find_course_by_name(course_name))
    input("premi invio per continuare...")

def show_all_courses():
    courses = CourseService().find_all_courses()
    if not courses:
        print("non ci sono corsi")
    else:
        for course in courses:
            print(course)
    input("premi invio per continuare...")

def delete_course():
    name = input("\nInserisci nome del corso: ")
    CourseService().delete_course(name)
    input("premi invio per continuare...")

def update_course_seats():
    course_name = input("\nInserisci nome del corso: ")
    new_places = input("Inserisci i nuovi posti per il corso: ")
    print(CourseService().update_max_places(course_name, new_places))
    input("premi invio per continuare...")

def add_registration():
    course_name = input("\nInserisci nome del corso: ").strip()
    id_user = input("Inserisci codice abbonamento dell'utente: ").strip()
    print(RegistrationService().save_registration(id_user,course_name))
    input("premi invio per continuare...")

def delete_registration():
    id_registration = input("\nInserisci id della registrazione: ").strip()
    print(RegistrationService().delete_registration(id_registration))
    input("premi invio per continuare...")

def find_all_registrations() :
    registrations = RegistrationService().find_all_registrations()
    if not registrations:
        print("non ci sono utenti registrati")
    else:
        for registration in registrations:
            print(registration)
    input("premi invio per continuare...")

if __name__ == "__main__":
    main()