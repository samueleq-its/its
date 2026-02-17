import cassa
import pane
import transazioni
import utils
import stats

#TODO: stampa_menu() come funzione?
#TODO: match case invece di elif

#crea menu principale, selezione opzioni con immissione numero da tastiera
def main_menu():
	while True:
		#stampa menu
		menu = (
			"\n=========================\n"
			"Menu principale\n"
			"1. Transazioni\n"
			"2. Gestione tipi pane\n"
			"3. Gestione cassa\n"
			"4. Mostra statistiche\n"
			"0 Esci\n"
		)
		print(menu)
		#legge scelta utente
		try:
			user_input = int(input("inserisci il numero corrispondente alla funzione scelta: "))
		except:
			utils.errore("valore errato")
			continue
		print()
		#avvia funzione richiesta
		if user_input == 0: # esce dal programma
			return
		elif user_input == 1:
			transazioni.avvia_transazione()
		elif user_input == 2:
			pane.gestione_pane()
		elif user_input == 3:
			cassa.gestione_cassa()
		elif user_input == 4:
			print(stats.crea_report())
		else:
			utils.errore("opzione non disponibile")

	
main_menu()