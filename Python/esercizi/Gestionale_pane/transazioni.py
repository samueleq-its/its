import datetime
import io_utils
import utils
import pane
import cassa

trans_file = "./data/transazioni.txt"

def avvia_transazione():
	if not utils.domanda("Vuoi iniziare una nuova transazione? s/n: "):
		return
	if not io_utils.check_file("./data/tipi_pane.txt"):
		utils.errore("ERRORE: file tipi_pane.txt assente")
		return
	
	#inserimento tipo pane e quantità
	lista_prodotti = list()
	totale = 0
	while True: #loop immissione prodotti
		codice = input_codice()
		if codice == None:
			break
		quantita = utils.input_quantita("inserisci la quantita di pane "+ codice +": ")
		subtotale = round(pane.tipi_pane[codice]["prezzo"] * quantita, 2)
		totale += subtotale
		lista_prodotti.append((codice,quantita,subtotale))
		print("lascia il campo vuoto e premi INVIO per terminare l'inserimento")
	if len(lista_prodotti) < 1:
		return
	print()
	timestamp = datetime.datetime.now()
	timestamp = timestamp.strftime("%d-%m-%Y %H:%M:%S")	
	salva_transazione(lista_prodotti, totale, timestamp)
	cassa.aggiorna_saldo(totale)
	stampa_scontrino(lista_prodotti, totale, timestamp)
	
	
	
#return: codice prodotto o None per terminare l'immissione
def input_codice():
	while True: #loop immissione codice
			codice = input("inserisci il codice del pane: ").strip().upper()
			if codice == "":
				return None
			if codice == "?":
				for tipo_pane in pane.tipi_pane:
					print(tipo_pane)
				print()
				continue
			if not pane.cerca_codice(codice):
				print("codice non trovato, inserisci '?' per lista codici")
				continue
			return codice
#salva la transazione su file con formato:
#	>timestamp , totale_transazione
#		codice_pane, quantità, subtotale
#		...
def salva_transazione(lista_prodotti, totale, timestamp):
	data = list()
	data.append(">" + timestamp +","+ str(totale))
	#elemento[0] = codice
	#elemento[1] = quantita
	#elemento[2] = subtotale
	for elemento in lista_prodotti:
		data.append(elemento[0] +","+ str(elemento[1]) +","+ str(elemento[2]))
	io_utils.append_file(trans_file, data)
	
def stampa_scontrino(lista_prodotti, totale, timestamp):
	scontrino = (
		"--------------------------------\n"
		"       SCONTRINO FISCALE\n"
		"--------------------------------\n"
		)
	#elemento[0] = codice
	#elemento[1] = quantita
	#elemento[2] = subtotale
	for elemento in lista_prodotti:
		descrizione = pane.tipi_pane[elemento[0]]["descrizione"]
		scontrino += (elemento[0] + " - " + descrizione + "   x" 
			+ str(elemento[1]) + " = " + str(elemento[2]) + "€\n")
	scontrino += (
		"--------------------------------\n"
		"TOTALE: " + str(totale) + "€\n"
		"--------------------------------\n"
		)
	print(scontrino)