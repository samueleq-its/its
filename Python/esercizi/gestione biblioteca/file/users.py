import utils
import io_utils

FILE_UTENTI = "DB_utenti.txt"

#gestisce l'inserimento di un nuovo utente
def inserimento_utente():
	users = read_DB()
	last_id = max(user_id for user_id in users) if len(users) > 0 else 0

	nome = utils.input_text("inserisci il nome: ").strip().capitalize()
	cognome = utils.input_text("inserisci il cognome: ").strip().capitalize()
	id = last_id + 1

	nuovo_utente = utils.list_to_string([id,nome,cognome])
	io_utils.append_file(FILE_UTENTI, [nuovo_utente])

#restituisce un dizionario degli utenti come {id: (nome, cognome)}
def read_DB():
	'''
	{id:(nome,cognome)}
	'''
	file_data = io_utils.read_file(FILE_UTENTI)
	if file_data == None:
		utils.errore("ERRORE: file DB_utenti.txt non trovato")
		exit()
	users = dict()
	for line in file_data:
		entry = line.split(",")
		#id = entry[0]
		#nome = entry[1]
		#cognome = entry[2]
		users[int(entry[0])] = (entry[1],entry[2].strip())
	return users


if __name__ == "__main__":
	inserimento_utente()