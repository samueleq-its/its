# leggi file, visualizza lettere per frequenza decrescente
# converti ogni lettera in minuscolo, conta solo "a" a "z", ignora altri caratteri

import string

fdefault = "romeo-full.txt"
fname = input("inserisci il nome del file, invio per %s: " % fdefault)
try :
    fhand = open("..\\" + fname)    
except :
    print("file non trovato")
    exit()

letters_dict = dict()
for line in fhand :
    line = line.translate(str.maketrans(string.ascii_uppercase, string.ascii_lowercase, (string.punctuation + string.digits + "\n" + " "))) # converte lettere maiuscole a minuscole e rimuove tutti gli altri caratteri
    for char in line :
        letters_dict[char] = letters_dict.get(char, 0) + 1

letters_list = list()
for letter, frequency in list(letters_dict.items()) :
    letters_list.append((frequency,letter))
    
letters_list.sort(reverse=True)
for frequency, letter in letters_list :
    print(letter, frequency)
