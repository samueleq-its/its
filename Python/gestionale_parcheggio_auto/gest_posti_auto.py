from db_handler import DB_Handler
from posto_auto import PostoAuto
from sqlite3 import IntegrityError
import gest_dipendenti
import utils

def nuovo():
	''' aggiunge un  nuovo posto auto al DB, il codice del posto auto deve essere univoco'''
	#inserimento codice posto auto
	codice_posto_auto = input("inserisci il codice del posto auto: ")
	if codice_posto_auto == "":
		print("il codice del posto auto non può essere vuoto")
		return
	#salvataggio posto auto, verifica univocità codice
	crs = DB_Handler.get_cursor()
	try:
		crs.execute("insert into posti_auto (codice) values (?);", (codice_posto_auto,))
	except IntegrityError:
		print("il codice del posto auto è già presente")
		return
	finally:
		DB_Handler.commit()
		crs.close()
	print("nuovo posto auto salvato")

def modifica():
	'''
	cerca un posto auto per codice, stampa i suoi dati, permette di assegnarlo ad un dipendente
	se non è assegnato, o di rimuovere l'assegnazione se è già assegnato
	'''
	#cerca il posto auto
	codice = input("inserisci il codice del posto auto: ")
	if codice == "":
		print("il codice del posto auto non può essere vuoto")
		return
	posto_auto = get(codice)
	if posto_auto is None:
		print("posto auto non trovato")
		return
	stampa(posto_auto)
	#modifica assegnazione posto auto
	if posto_auto.id_dipendente != None:
		if utils.domanda("rimuovere l'assegnazione s/n: "):
			posto_auto.id_dipendente = None
			aggiorna(posto_auto)
	else:
		if utils.domanda("assegnare il posto auto ad un dipendente? s/n: "):
			id_dipendente = utils.input_int("id dipendente: ")
			#verifica se dipendente esiste, ha posto già assegnato
			if gest_dipendenti.get(id_dipendente) == None:
				print("dipendente non trovato")
				return
			if dipendente_gia_assegnato(id_dipendente):
				print("il dipendente ha già un posto auto assegnato")
				return
			posto_auto.id_dipendente = id_dipendente
			aggiorna(posto_auto)
			stampa(posto_auto)
	
def elenco():
	'''restituisce una elenco di tutti i posti auto presenti nel DB'''
	crs = DB_Handler.get_cursor()
	crs.execute("SELECT * from posti_auto;")
	results = crs.fetchall()
	crs.close()
	if results == []:
		return None
	posti_auto = list()
	for codice, id_dipendente in results:
		posti_auto.append(PostoAuto(codice, id_dipendente))
	return posti_auto

def elimina():
	'''elimina un posto auto dato il suo codice'''
	#inserimento codice posto auto
	codice = input("inserisci il codice del posto auto da eliminare: ")
	if codice == "":
		print("il codice del posto auto non può essere vuoto")
		return
	#verifica se posto auto esiste
	posto_auto = get(codice)
	if posto_auto is None:
		print("posto auto non trovato")
		return
	#elimina posto auto
	crs = DB_Handler.get_cursor()
	crs.execute("DELETE from posti_auto WHERE codice = ?;", (posto_auto.codice,))
	DB_Handler.commit()
	crs.close()
	print("posto auto eliminato")

def get(codice):
	'''restituisce un posto auto dato il suo codice, None se non trovato'''
	crs = DB_Handler.get_cursor()
	crs.execute("SELECT * from posti_auto WHERE codice = ?;", (codice,))
	result = crs.fetchone()
	crs.close()
	if result == None:
		return None
	codice, id_dipendente = result
	return PostoAuto(codice, id_dipendente)

def stampa(posto_auto):
	'''stampa i dati di un posto auto e il dipendente assegnato se presente'''
	#se dipendente.id_dipendente = None, non è assegnato
	#se gest_dipendenti.get(posto_auto.id_dipendente) == None, NON DEVE CAPITARE
	dipendente = gest_dipendenti.get(posto_auto.id_dipendente)
	print(f"Posto auto: {posto_auto.codice}, dipendente assegnato: {dipendente if dipendente is not None else 'nessuno'}")

def aggiorna(posto_auto):
	'''aggiorna il posto auto sul DB'''
	crs = DB_Handler.get_cursor()
	crs.execute("UPDATE posti_auto SET id_dipendente = ? WHERE codice = ?;", (posto_auto.id_dipendente, posto_auto.codice))
	DB_Handler.commit()
	crs.close()

def dipendente_gia_assegnato(id_dipendente):
	'''restituisce True se il dipendente ha già un posto auto assegnato, False altrimenti'''
	crs = DB_Handler.get_cursor()
	crs.execute("SELECT codice from posti_auto WHERE id_dipendente = ?;", (id_dipendente,))
	return crs.fetchone() != None