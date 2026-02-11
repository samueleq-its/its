# dizionari per contare numero mail mandate da ciascun indirizzo

fname = input("inserisci il nome del file: ")
try :
    fhand = open("..\\" + fname)
except :
    print("file non trovato")
    exit()

sender_dict = dict()

for line in fhand :
    line  = line.rstrip()
    if line.startswith("From ") :
        words = line.split()
        # Error se non c'è seconda parola
        sender_dict[words[1]] = sender_dict.get(words[1], 0) + 1
print(sender_dict)