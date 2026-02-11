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
	read_from_file("test.txt")

	
def read_from_file(file_name):
	data = list()
	if os.path.exists(file_name):
		with open(file_name) as file:
			for line in file:
				entry = string_to_list_v2(line.strip())
				print(line)
				for element in entry:
					print(element)
					
# funziona solo se c'è le sotto-liste non hanno a loro volta sotto-liste
def string_to_list(line):
	result = list()
	i,j = (1,1) if line[0] == "[" else (0,0)
	while i < len(line):
		if line[i] == "," or line[i] == "]": # divisore tra i vari elementi della lista
			result.append(line[j:i].strip("\"\'"))
			j = i + 2 # salta al primo carattere dopo la virgola e lo spazio seguente
		if line[i] == "[": # inizio di una sottolista
			j = i
			i = line.find("]", j) # se non c'è il file è corrotto
			result.append(string_to_list(line[j:i+1]))
			i += 3 # salta al primo carattere dopo "], "	
			j = i
		i += 1
	return result

def string_to_list_v2(line):
	result = list()
	i,j = (1,1) if line[0] == "[" else (0,0)
	while i < len(line):
		if line[i] == "," or line[i] == "]": # divisore tra i vari elementi della lista
			result.append(line[j:i].strip("\"\'"))
			j = i + 2 # salta al primo carattere dopo la virgola e lo spazio seguente
		if line[i] == "[": # inizio di una sottolista
			j = i
		#trovo la ']' corrispondente (saltando eventuali ']' di sotto-liste)
		#loop infinito se non trova ']'
			sub_list = 1
			while not sub_list > 0:
				i =+ 1
				if line[i] == "[":
					sub_list += 1
				elif line[i] == "]":
					sub_list -= 1				
			result.append(string_to_list_v2(line[j:i+1]))
			#i += 3 # salta al primo carattere dopo "], "	
			j = i
		i += 1
	return result



	

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
		print("\t" + partecipante + ":" + str(stats["partecipants"][partecipante]))
	print("Età media inserita dai partecipanti: %0.1f" % stats["average_age"])
	print("Altezza media inserita dai partecipanti: %0.2f" % stats["average_height"])
	print("Percentuale di partecipanti che crede il prof sia spostato: " + str(stats["married_perc"] * 100) + " %")
	print("Percentuale di partecipanti che crede il prof non sia spostato: " + str(100 - stats["married_perc"] * 100) + " %")
	print("elenco delle materie inserite dai partecipanti:")
	for subject in  stats["subjects"]:
		print("\t" + subject + ":" + str(stats["subjects"][subject]))
	
if __name__ == "__main__":
	main()