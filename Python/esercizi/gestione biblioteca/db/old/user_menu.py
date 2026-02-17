import sqlite3
import utils
from user import User

def menu(conn:sqlite3.Connection):
    while True:
        menu = (
            "1. aggiungi utente\n"
            "2. cerca utente\n"
            "3. stampa utenti\n"
            "0. indietro"
            )
        print(menu)
        try:
            user_input = int(input("inserisci il numero corrispondente alla funzione scelta: "))
        except:
            utils.errore("valore errato")
            continue
        print()
        #avvia funzione richiesta
        match user_input:
            case 1:
                pass
            case 2:
                #WIP
                id = int(input("inserisci l'id dell'utente: "))
                result = User.search_user(conn, id)
                if result == None:
                    print("Utente non trovato")
                    continue
                print("UTENTE:",result.id,result.name,result.surname)
            case 3:
                pass
            case 0:
                return
            case _:
                utils.errore("opzione non disponibile")

if __name__ == "__main__":
    conn = sqlite3.connect("library.sqlite")
    menu(conn)


#aggiunta di un utente al DB
#ricerca su DB di utenti


# import utils
# import io_utils

# FILE_UTENTI = "DB_utenti.txt"

# #gestisce l'inserimento di un nuovo utente
# def inserimento_utente():
# 	users = read_DB()
# 	last_id = max(user_id for user_id in users) if len(users) > 0 else 0

# 	nome = utils.input_text("inserisci il nome: ").strip().capitalize()
# 	cognome = utils.input_text("inserisci il cognome: ").strip().capitalize()
# 	id = last_id + 1

# 	nuovo_utente = utils.list_to_string([id,nome,cognome])
# 	io_utils.append_file(FILE_UTENTI, [nuovo_utente])

# #restituisce un dizionario degli utenti come {id: (nome, cognome)}
# def read_DB():
# 	'''
# 	{id:(nome,cognome)}
# 	'''
# 	file_data = io_utils.read_file(FILE_UTENTI)
# 	if file_data == None:
# 		utils.errore("ERRORE: file DB_utenti.txt non trovato")
# 		exit()
# 	users = dict()
# 	for line in file_data:
# 		entry = line.split(",")
# 		#id = entry[0]
# 		#nome = entry[1]
# 		#cognome = entry[2]
# 		users[int(entry[0])] = (entry[1],entry[2].strip())
# 	return users


# if __name__ == "__main__":
# 	inserimento_utente()