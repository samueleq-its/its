import gest_posti_auto
import gest_dipendenti

#from db_handler import DB_Handler


def main():
	while True:
		# stampa tutte le voci
		menu = (
			"\n**************************\n"
			"1. Aggiungi dipendente\n"
			"2. Elenco dipendenti\n"
			"3. Cerca dipendente\n"
			"4. Aggiungi posto auto\n"
			"5. Elenco posti auto\n"
			"6. Assegnazione posto auto\n"
			"7. Elimina posto auto\n"
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
				gest_dipendenti.nuovo()
			case 2:
				dipendenti = gest_dipendenti.elenco()
				if dipendenti == None:
					print("dipendenti non presenti")
					continue
				for dipendente in dipendenti:
					print(dipendente)
			case 3:
				gest_dipendenti.trova()
			case 4:
				gest_posti_auto.nuovo()
			case 5:
				posti_auto = gest_posti_auto.elenco()
				if posti_auto == None:
					print("posti auto non presenti")
					continue
				for posto in posti_auto:
					gest_posti_auto.stampa(posto)
			case 6:
				gest_posti_auto.modifica()
			case 7:
				gest_posti_auto.elimina()
			case 0:
				return
			case _:
				print("opzione errata")
				continue	

main()