import os

#legge un file
#return: contenuto del file, None se non esiste		
def read_file(nome_file):
	if not os.path.exists(nome_file):
		return None
	with open(nome_file, "r") as file:
		data = file.readlines()
	return data
	
#data: lista di linee da scriver su file
def write_file(nome_file, data):
	with open(nome_file, "w") as file:
		for line in data:
			file.write((line if type(line) == str else str(line)) + "\n")

#data: lista di linee da scriver su file
def append_file(nome_file, data):
	with open(nome_file, "a") as file:
		for line in data:
			line = str(line) + "\n"
			file.write(line)
			
def check_file(nome_file):
	return os.path.exists(nome_file)


def yield_read_file(nome_file:str):
	if not os.path.exists(nome_file):
		return None
	with open(nome_file, "r") as file:
		for line in file:
			yield line