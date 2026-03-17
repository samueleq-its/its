from db_handler import DB_Handler
from os import system
import gest_studenti
import gest_aule
import gest_prenotazioni

def main():
	while True:
		# stampa tutte le voci
		menu = (
			"\n**************************\n"
			"1. Aggiungi studente\n"
			"2. Mostra tutti gli studenti\n"
			"3. Cerca studente per id\n"
			"4. Aggiunti un aula\n"
			"5. Mostra tutte le aule\n"
			"6. Cerca/modifica aula\n"
			"7. Aggiungi prenotazione\n"
			"8. Mostra tutte le prenotazioni\n"
			"9. Cerca prenotazione\n"
			"0. Esci\n"
			"**************************\n"
			)
		print(menu)
		try:
			choice = int(input("inserisci il numero corrispondente alla funzione scelta: "))
		except ValueError:
			print("inserisci un numero")
			continue
		match choice:
			case 1: #aggiungi studente
				gest_studenti.add()
			case 2: #mostra tutti gli studenti
				elenco_studenti = gest_studenti.get_all()
				if elenco_studenti == None:
					print("non ci sono studenti")
					continue
				for studente in elenco_studenti:
					print(studente)
				system("pause")
			case 3: #cerca studente per id
				gest_studenti.find_helper()
				system("pause")
			case 4: #aggiungi aula
				gest_aule.add()
			case 5: #mostra tutte le aule
				elenco_aule = gest_aule.get_all()
				if elenco_aule == None:
					print("non ci sono aule")
					continue
				for aula in elenco_aule:
					print(aula)
				system("pause")
			case 6: #cerca/modifica aula
				gest_aule.find_helper()
				system("pause")
			case 7: #aggiungi prenotazione
				gest_prenotazioni.add()
			case 8: #mostra tutte le prenotazioni
				prenotazioni = gest_prenotazioni.get_all()
				for prenotazione in prenotazioni:
					print(prenotazione)
				system("pause")
			case 9: #cerca prenotazione
				gest_prenotazioni.find_helper()
				system("pause")
			case 0:
				DB_Handler.close()
				return
			case _:
				print("opzione errata")
				continue	

main()