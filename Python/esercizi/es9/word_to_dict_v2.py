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
        word_dict[word] = "la parola è presente nel testo"

print(word_dict.get(word_to_seek, "la parola NON è presente nel testo"))
