# memorizza parole di words.txt in un dizionario
# il testo contiene punteggiatura da rimuovere
import string

word_to_seek = input("inserisci la parola da cercare: ")

fhand = open ("words.txt")
word_dict = dict()
for line in fhand :
    line = line.rstrip()
    line = line.translate(line.maketrans("","",string.punctuation))
    words = line.split()
    for word in words :
        if word not in word_dict :
            word_dict[word] = ""

if word_to_seek in word_dict : 
    print(word_to_seek, "è presente nel testo")
else :
    print(word_to_seek, "NON è presente nel testo")
    print(word_dict)