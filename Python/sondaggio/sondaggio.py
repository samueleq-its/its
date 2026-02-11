#raccolta di nome partecipante, anni, se spostato, materie
	# verifica che i dati siano corretti
	# verificare che i dati non contengano caratteri proibiti?
#salvataggio dei dati in un file in append

def main():
	
	answers = ask_survey()
	save_to_file(answers, "survey.txt")
	

def ask_survey():
	answers = [
		ask_name(),
		ask_age(),
		ask_height(),
		ask_married(),
		ask_subjects()
		]
	return answers

def ask_name():
	return input("inserisci il tuo nome: ").strip().capitalize()
	
def ask_age():
	while True:
		try:
			age = int(input("inserisci quale credi sia l'età del prof: "))
		except:
			print("inserisci l'eta come numero intero")
			continue
		if age <= 0:
			print("inserisci un numero positivo valido")
			continue
		break
	return age
	
def ask_height()
	while True:
		height = input("inserisci quale credi sia l'altezza del prof in metri: ")
		height = height.replace(",",".")
		try:
			height = float(height)
		except:
			print("inserisci l'altezza come numero decimale es: 1.75")
			continue
		if height <= 0 or height > 5:
			print("inserisci un numero valido")
			continue
		break
	return height
	
def ask_married():
	while not "is_married" in locals():
		married = input("pensi che il prof sia sposato? s/n:").strip().lower()
		if married == "s":
			is_married = 1
		elif married == "n":
			is_married = 0
		else:
			print("inserisci s per \"si\" o n per \"no\"")
	return is_married
	
def ask_subjects():
	# TODO: controllare che non ci sia la stessa materia inserita più volte
	subjects_raw = input("inserisci quali materie pensi che il prof insegni separate da virgola: ").strip().lower()
	subjects = list()
	for subject in subjects_raw.split(","):
		if subject != "":
			subjects.append(subject.strip())
	return subjects

def save_to_file(data, file_name):
	with open(file_name, "a") as file:
		file.write(str(data) + "\n")

if __name__ == "__main__":
	main()