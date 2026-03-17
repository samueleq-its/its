from db_handler import DB_Handler
from prenotazione import Prenotazione
import gest_studenti
import gest_aule
import utils

def add():
	#inserimento studente
	while True:
		id = utils.input_positive("inserisci l'id dello studente: ")
		studente = gest_studenti.find(id)
		if studente == None:
			print("studente non trovato")
			continue
		break
	#verifica vincoli studente
	if (find(id_studente=id) != None):
		print("studente ha già una prenotazione, non è possibile prenotare")
		return
	#inserimento aula
	while True:
		codice_aula = input("inserisci il codice della aula: ").upper()
		aula = gest_aule.find(codice_aula)
		if aula == None:
			print("aula non trovata")
			continue
		break
	#verifica vincoli aula
	posti_disponibili = aula.posti_disponibili - 5 if aula.codice == "DUMMY" else aula.posti_disponibili 
	if (posti_disponibili <= 0):
		print("aula piena, non è possibile prenotare")
		return
	crs = DB_Handler.get_cursor()
	crs.execute("INSERT INTO prenotazioni (codice_aula, id_studente) VALUES (?, ?);", (aula.codice, studente.id))
	gest_aule.change_available_seats(aula, aula.posti_disponibili - 1)
	DB_Handler.commit()
	crs.close()
	print("prenotazione salvata")

def get_all():
	crs = DB_Handler.get_cursor()
	crs.execute("SELECT * FROM prenotazioni;")
	risultati = crs.fetchall()
	if risultati == []:
		print("Nessuna prenotazione presente")
	prenotazioni = []
	for id, codice_aula ,idstudente in risultati:
		prenotazioni.append(Prenotazione(id, codice_aula, idstudente))
	crs.close()
	return prenotazioni

def find_helper():
	while True:
		# stampa tutte le voci
		menu = ("cerca prenotazione per:\n"
			"1. id prenotazione\n"
			"2. id studente\n"
			"3. codice aula\n"
			"0. indietro\n"
			)
		print(menu)
		try:
			choice = int(input("inserisci il numero corrispondente alla funzione scelta: "))
		except ValueError:
			print("opzione errata")
			continue
		match choice:
			case 1: #id prenotazione
				while True:
					try:
						id = int(input("inserisci l'id della prenotazione da cercare: "))
					except ValueError:
						print("Errore: inserire un numero valido.")
						continue
					break
				prenotazione = find(id=id)
				if prenotazione == None:
					print("Prenotazione non trovata")
					return
				print(prenotazione)
				break
			case 2: #id studente
				while True:
					try:
						id_studente = int(input("inserisci l'id dello studente: "))
					except ValueError:
						print("Errore: inserire un numero valido.")
						continue
					break
				prenotazione = find(id_studente=id_studente)
				if prenotazione == None:
					print("Prenotazione non trovata")
					return
				print(prenotazione)
				break
			case 3: #codice aula
				codice_aula = input("inserisci il codice della aula: ").upper()
				prenotazioni = find_all_by_aula(codice_aula)
				if prenotazioni == None:
					print("Prenotazione non trovata")
					return
				for prenotazione in prenotazioni:
					print(prenotazione)
				return
			case 0:
				return
			case _:
				print("opzione errata")
				continue
	if utils.domanda("cancellare prenotazione? s/n: "):
		delete(prenotazione)
		print("prenotazione cancellata")

def find(id=None, id_studente=None):
	''''restituisce una prenotazione dato il suo id o, se id è None, per id studente, restituisce None se non trovato.\n
	solo un parametro deve essere valorizzato'''
	crs = DB_Handler.get_cursor()
	query = "SELECT * FROM prenotazioni WHERE "
	if id is not None:
		crs.execute(query + "id=?", (id,))
	else:
		crs.execute(query + "id_studente=?", (id_studente,))
	result = crs.fetchone()
	crs.close()
	if result == None:
		return None
	id, codice_aula, id_studente = result
	return Prenotazione(id, codice_aula, id_studente)

def find_all_by_aula(codice_aula):
	crs = DB_Handler.get_cursor()
	crs.execute("SELECT * FROM prenotazioni WHERE codice_aula=?", (codice_aula,))
	result = crs.fetchall()
	crs.close()
	if result == None:
		return None
	prenotazioni = []
	for id, codice_aula, id_studente in result:
		prenotazioni.append(Prenotazione(id, codice_aula, id_studente))
	return prenotazioni

def delete(prenotazione):
	crs = DB_Handler.get_cursor()
	crs.execute("DELETE FROM prenotazioni WHERE id = ?;", (prenotazione.id,))
	aula = gest_aule.find(prenotazione.codice_aula)
	if aula != None:
		gest_aule.change_available_seats(aula, aula.posti_disponibili + 1)
	DB_Handler.commit()
	crs.close()

def delete_all_by_aula(codice_aula):
	crs = DB_Handler.get_cursor()
	prenotazioni = find_all_by_aula(codice_aula)
	if prenotazioni != None:
		for prenotazione in prenotazioni:
			delete(prenotazione)
	crs.execute("DELETE FROM prenotazioni WHERE codice_aula = ?;", (codice_aula,))
	DB_Handler.commit()
	crs.close()

