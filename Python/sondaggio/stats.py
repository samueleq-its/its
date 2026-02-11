# lettura dei dati dal file generato da sondaggio.py
# generazione di statistiche
	# numero persone registrate (numero righe)
	# elenco e frequenza dei nomi
	# eta media
	# altezza media
	# percentuale sposato e percentuale non sposato
	# elenco e frequenza materie

import os

def main():
	data = read_from_file("survey.txt")
	stats = calc_stats(data)
	print_stats(stats)

#legge il file e converte le righe nei rispettivi dati
#restituisce una lista di dizionari contenenti le risposte al questionario
# data = [ riga 1 del file = {"name" ,"age", "height", "is_married", "subjects"}, riga 2 del file...]
def read_from_file(file_name):
	data = list()
	if os.path.exists(file_name):
		with open(file_name) as file:
			for line in file:
				entry = string_to_list(line.strip())
				data.append({
				 	"name": entry[0],
					"age": int(entry[1]),
					"height":float(entry[2]),
					"is_married": True if entry[3] == "1" else False,
					"subjects":entry[4]
					})
	return data

#NB: funzione ricorsiva (che chiama se stessa)
#dovrebbe poter leggere una lista contenente sotto-liste ma si rompe se la sottolista contiene a sua volta altre sottoliste
#restituisce una lista contenente stringe e liste
def string_to_list(line):
	result = list()
	i,j = (1,1) if line[0] == "[" else (0,0)
	while i < len(line):
		if line[i] == "," or line[i] == "]": # divisore tra i vari elementi della lista
			result.append(line[j:i].strip("\"\'"))
			j = i + 2 # salta al primo carattere dopo la virgola e lo spazio seguente
		if line[i] == "[": # inizio di una sottolista
			j = i
			i = line.find("]", j) #si rompe se ci sono sotto-liste, bisognerebbe controllare quante '[' ci sono prima di trovare ']'
			result.append(string_to_list(line[j:i+1]))
			i += 3 # salta al primo carattere dopo "], "	
			j = i
		i += 1
	return result		

#calcola e restituisce le statistiche richieste
#'data' è la una lista di dizionari contenenti le risposte al questionario
def calc_stats(data):
	total_partecipants = 0
	partecipants = dict()
	average_age = 0
	average_height = 0
	married_perc = 0
	subjects = dict()	
	
	
	for entry in data:
		total_partecipants += 1
		partecipants[entry["name"]] = partecipants.get(entry["name"], 0) + 1
		average_age += entry["age"]
		average_height += entry["height"]
		if entry["is_married"]:			
			married_perc += 1
		for subject in entry["subjects"]:
			subjects[subject] = subjects.get(subject, 0) + 1
		
	average_age /= total_partecipants
	average_height /= total_partecipants
	married_perc /= total_partecipants
	
	stats = {
		"total_partecipants": total_partecipants,
		"partecipants": partecipants,
		"average_age": average_age,
		"average_height": average_height,
		"married_perc": married_perc,
		"subjects": subjects
		}
	
	return stats


def print_stats(stats):
	print("Totale partecipanti:", stats["total_partecipants"])
	print("Elenco partecipanti:")
	for partecipante in  stats["partecipants"]:
		print("> " + partecipante + ":" + str(stats["partecipants"][partecipante]))
	print("Età media inserita dai partecipanti: %0.1f" % stats["average_age"])
	print("Altezza media inserita dai partecipanti: %0.2f m" % stats["average_height"])
	print("Percentuale di partecipanti che crede il prof sia spostato: " + str(stats["married_perc"] * 100) + " %")
	print("Percentuale di partecipanti che crede il prof non sia spostato: " + str(100 - stats["married_perc"] * 100) + " %")
	print("elenco delle materie inserite dai partecipanti:")
	for subject in  stats["subjects"]:
		print("> " + subject + ":" + str(stats["subjects"][subject]))

#se lo script viene eseguito direttamente il valore di __name__ è "__main__"
if __name__ == "__main__":
	main()