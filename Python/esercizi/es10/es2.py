# leggi file, conta distribuzione email in base all'ora di invio
# stampa riga per riga coppia ora - numero email ( es: 12 01)
# FORMATO: "From stephen.marquard@uct.ac.za Sat Jan  5 09:14:16 2008"

fname = input("inserisci il nome del file: ")
try :
    fhand = open("..\\" + fname)
except :
    print("file non trovato")
    exit()
    
hours_dict = dict()
for line in fhand :
    if not line.startswith("From ") : # "From " con spazio per ignorare righe "From:"
        continue
    hour = line.split()[5].split(":")[0] # words = line.split() > word = words[5].split() > word[0] è l'ora
    hours_dict[hour] = hours_dict.get(hour, 0) + 1

for hour, amount in sorted(hours_dict.items()) : # l = hours_dict.items() > l.sort() > for h,m in l
    print(hour, amount)

    
