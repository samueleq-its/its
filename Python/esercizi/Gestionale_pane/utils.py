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