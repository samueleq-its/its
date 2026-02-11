import os

def errore(messaggio):
	print(messaggio)
	#input("premi invio per continuare...")
	os.system("pause")
	
def domanda(messaggio):
	while True:
		scelta = input(messaggio).lower()
		match scelta:
			case "n":
				return False
			case "s":
				return True
			case _:
				errore("valore errato, inserisci 's' o 'n'")

#estensione di input(), verifica inserimento corretto del prezzo da tastiera
#return: prezzo
def input_prezzo(messaggio):
	while True:
		try:
			prezzo = float(input(messaggio).strip())
		except:
			errore("formato errato: inserisci l'importo nel formato '12.34'")
			continue
		if prezzo <= 0:
			errore("inserisci un numero valido maggiore di 0")
			continue
		return prezzo
		
def input_quantita(messaggio):
	while True:
		try:
			quantita = int(input(messaggio).strip())
		except:
			errore("formato errato: inserisci un numero intero")
			continue
		if quantita <= 0:
			errore("inserisci un numero valido maggiore di 0")
			continue
		return quantita
		
#verifica l'inserimento di testo senza caratteri proibiti ( ,)
def input_text(messaggio):
	proibiti = [","]
	is_proibito = True
	while is_proibito:
		text = input(messaggio)
		is_proibito = False
		for carattere in proibiti:
			if carattere in text:
				is_proibito = True
				errore("input errato, '"+ carattere +"' non è un carattere ammesso")
				break
	return text

#restituisce gli elementi della lista come stringa con ',' come separatore
def list_to_string(l):
	line = ""
	for item in l:
		line += str(item) + ","
	line = line.rstrip(",")
	return line

def crea_menu(funzioni_menu):
	for n in range(len(funzioni_menu)):
		print(str(n+1) + ". " + funzioni_menu[n]["descrizione"])
	print("0. Esci")
	while True:
		try:
				choice = int(input("inserisci il numero corrispondente alla funzione scelta: "))
		except:
			errore("valore errato")
			continue
		if choice == 0:
			return None
		if choice <= len(funzioni_menu):
			return funzioni_menu[choice-1]["funzione"]
		errore("opzione non disponibile")