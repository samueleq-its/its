# leggi righe "From" ed estrai indirizzo
# conta numero mail ricevute per ogni indirizzo
# visualizza chi ha mandato più email

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

email_by_number = list()
for email, frequency in list(sender_dict.items()) :
    email_by_number.append((frequency,email))
email_by_number.sort(reverse=True)
number,email = email_by_number[0]
print("il numero maggiore di email è stato mandato da %s: %d" % (email, number))