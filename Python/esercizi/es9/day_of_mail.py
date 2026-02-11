# classifica i le mail in base al giorno della settimana in cui sono stati inviati

fname = input("inserisci il nome del file: ")
try :
    fhand = open(fname)
except :
    print("file non trovato")
    exit()

week_dict = dict()

for line in fhand :
    line  = line.rstrip()
    if line.startswith("From ") :
        words = line.split()
        # Error se non c'è terza parola
        week_dict[words[2]] = week_dict.get(words[2], 0) + 1
print(week_dict)