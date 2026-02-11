# legge file riga per riga, split riga, crea elenco con tutte le parole,
# stampa elenco in ordine alfabetico
try :
    fhand = open("romeo.txt")
except :
    print("file non trovato")
    exit()
words_list = list()
for line in fhand:
    split_line = line.split()
    for word in split_line:
        if not word in words_list:
            words_list.append(word)
words_list.sort()
print(words_list)