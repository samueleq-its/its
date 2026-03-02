import utils
import gest_clienti
import gest_stanze
import gest_prenotazioni
#from db_handler import DB_Handler


def main():
	while True:
		# stampa tutte le voci
		menu = (
			"\n**************************\n"
			"1. Aggiungi nuovo cliente\n"
			"2. Mostra clienti\n"
			"3. Cerca/modifica cliente\n"
			"4. Aggiungi nuova stanza\n"
			"5. Mostra stanze\n"
			"6. Cerca/modifica stanza\n"
			"7. Nuova prenotazione\n"
			"8. Mostra prenotazioni\n"
			"9. Cerca/cancella prenotazione\n"
			"0. Esci\n"
			"**************************\n"
			)
		print(menu)
		try:
			choice = int(input("inserisci il numero corrispondente alla funzione scelta: "))
		except:
			print("inserisci un numero")
			continue
		match choice:
			case 1:
				gest_clienti.nuovo()
			case 2:
				clienti = gest_clienti.leggi()
				if clienti == None:
					print("non ci sono clienti")
					continue
				gest_clienti.stampa(clienti)
			case 3:
				gest_clienti.cerca()
			case 4:
				gest_stanze.nuovo()
			case 5:
				stanze = gest_stanze.leggi()
				if stanze == None:
					print("non ci sono stanze")
					continue
				gest_stanze.stampa(stanze)
			case 6:
				gest_stanze.cerca()
			case 7:
				gest_prenotazioni.nuovo()
			case 8:
				gest_prenotazioni.leggi()
			case 9:
				gest_prenotazioni.cerca()
			case 0:
				return
			case _:
				print("opzione errata")
				continue

	

main()