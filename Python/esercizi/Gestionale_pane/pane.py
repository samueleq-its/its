import io_utils
import utils

#TODO: match case invece di elif
#TODO: impedire l'inserimento di virgole e > nel file, limitare dimensioni codice pane
#TODO: tipi_pane viene ricreato ogni volta leggendo il file
#TODO? è possibile modificare il file invece di riscriverlo?

#legge file tipi_pane.txt
#aggiunge dati in dizionario tipi_pane
#1. stampa il dizionario
#2. cerca per chiave o per descrizione nel dizionario
#	può modificare prezzo
#3. aggiunge un nuovo tipo al dizionario e al file in append

file_pane = "./data/tipi_pane.txt"

def gestione_pane():
	while True:
		menu = (
			"\n=========================\n"
			"Gestione tipi pane\n"
			"1. Visualizza elenco tipi di pane\n"
			"2. Cerca o modifica tipo di pane\n"
			"3. Aggiungi nuovo tipo di pane\n"
			"0. Indietro\n"
		)
		print(menu)
		try:
			user_input = int(input("inserisci il numero corrispondente alla funzione scelta: "))
		except:
			utils.errore("valore errato")
			continue
		print()
		if user_input == 0: # ritorna al menu principale
			return
		elif user_input == 1: # stampa tipi pane
			tipi_pane = leggi_tipi()
			for pane in tipi_pane:
				print("codice: '%s' \ndescrizione: %s \nprezzo: %0.2f\n"
					%(pane, tipi_pane[pane]["descrizione"], tipi_pane[pane]["prezzo"]))
		elif user_input == 2: # ricerca e modifica tipo pane
			cerca_modifica()
		elif user_input == 3: # aggiungi nuovo tipo
			aggiungi_tipo()
		else:
			utils.errore("opzione non disponibile")
			

#legge il file e crea un dizionario 
#{"codice": {
#	"descrizione": str,
#	"prezzo": float},
#...}
def leggi_tipi():
	linee_file = io_utils.read_file(file_pane)
	pane_dict = dict()
	for linea in linee_file:
		#linea = "codice, descrizione, prezzo"
		linea = linea.split(",")
		codice = linea[0].strip()
		descrizione = linea[1].strip()
		prezzo = float(linea[2].strip())
		pane_dict[codice] = {
			"descrizione": descrizione,
			"prezzo": prezzo
			}
	return pane_dict

#aggiunge un nuovo tipo di pane al dizionario e al file in append
#il codice non deve essere già presente
def aggiungi_tipo():
	codice = input("inserisci il codice del nuovo tipo di pane: ").strip().upper()
	if codice in tipi_pane:
		utils.errore("il codice è già presente")
		return
	descrizione = input("inserisci la descrizione del pane: ").strip().lower()
	prezzo = utils.input_prezzo()
	tipi_pane[codice] = {
			"descrizione": descrizione,
			"prezzo": prezzo
			}
	nuova_linea = str(codice) + "," + str(descrizione) + "," + str(prezzo)
	io_utils.append_file(file_pane, [nuova_linea])


#TODO: scegliere se fare ricerca per codice o descrizione invece di farle entrambe
#ricerca per chiave e descrizione, cambia il prezzo del pane trovato
def cerca_modifica():
	chiave = input("inserisci il codice o la descrizione da cercare: ").strip().upper()
	if not cerca_codice(chiave): #cerca tra i codici, se non lo trova cerca nelle descrizioni
		chiave = cerca_descrizione(chiave.lower())
		if chiave == None: #se non viene trovato neanche nelle descrizioni, stampa avviso
			utils.errore("Nessun risultato trovato")
			return
	print("codice: '%s' \ndescrizione: %s \nprezzo: %0.2f\n"
					%(chiave, tipi_pane[chiave]["descrizione"], tipi_pane[chiave]["prezzo"]))
	# modifica del prezzo se richiesto
	while True:
		scelta = input("Modificare il prezzo? s/n: ").lower()
		match scelta:
			case "n":
				return
			case "s":
				modifica_prezzo(chiave)
				return
			case _:
				utils.errore("valore errato, inserisci 's' o 'n'")

#return: True se viene trovato, False altrimenti
def cerca_codice(codice):
	return codice in tipi_pane

#TODO: se ci sono più descrizioni che corrispondono?
#cerca la stringa nelle descrizioni dei tipi di pane
#return: codice del tipo se trovato, None altrimenti
def cerca_descrizione(chiave):
	for codice in tipi_pane:
		if chiave in tipi_pane[codice]["descrizione"]:
			return codice
	return None

#riceve da tastiera il nuovo prezzo e lo salva su dizionario e file
def modifica_prezzo(codice):
	prezzo = utils.input_prezzo("inserisci il prezzo del pane: ")
	tipi_pane[codice]["prezzo"] = prezzo
	data = list()
	for tipo in tipi_pane:
		data.append(str(tipo) + "," + str(tipi_pane[tipo]["descrizione"]) + "," + str(tipi_pane[	tipo]["prezzo"]))
	io_utils.write_file(file_pane, data)
	print("prezzo aggiornato")

tipi_pane = leggi_tipi()