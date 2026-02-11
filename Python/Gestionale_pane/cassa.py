import io_utils
import utils

#TODO: match case invece di elif
#TODO: non leggere il valore della cassa ogni volta, aggiornarne il valore dopo la prima lettura
#TODO? alterare / azzerare valore cassa

file_cassa = "./data/cassa.txt"

#menu principale gestion cassa
#scelta funzione con numero da tastiera
def gestione_cassa():
	while True:
		menu = (
			"\n=========================\n"
			"Gestione cassa\n"
			"1. Lettura saldo\n"
			"2. Aggiorna saldo\n"
			"0. Indietro\n"
		)
		print(menu)
		try:
			user_input = int(input("inserisci il numero corrispondente alla funzione scelta: "))
		except:
			errore("valore errato")
			continue
		print()
		if user_input == 0: # ritorna al menu principale
			return
		elif user_input == 1:
			saldo = lettura_saldo()
			print("il saldo attuale è: %0.2f€" % saldo)
		elif user_input == 2:			
			aggiorna_saldo(utils.input_prezzo("inserisci l'importo da aggiungere al saldo: "))
		else:
			errore("opzione non disponibile")

#legge il file cassa.txt è ne stampa il valore
#TODO: gestire file non scritto correttamente
def lettura_saldo():
	cassa = io_utils.read_file(file_cassa)
	if cassa == None:
		io_utils.write_file(file_cassa, ["0.00"])
		return 0.00
	return float(cassa[0])

# aggiorna il file cassa.txt aggiungendo l'importo
def aggiorna_saldo(importo):
	nuova_cassa = lettura_saldo() + importo
	io_utils.write_file(file_cassa, [nuova_cassa])
	
	
	
	