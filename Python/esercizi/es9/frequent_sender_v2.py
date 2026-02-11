# dizionari per contare numero mail mandate da ciascun indirizzo

fhand = open("mbox.txt")
sender_dict = dict()

for line in fhand :
    line  = line.rstrip()
    if line.startswith("From ") :
        words = line.split()
        # Error se non c'è seconda parola
        sender_dict[words[1]] = sender_dict.get(words[1], 0) + 1

# loop sulla lista di mittenti
# per ognuno controlla se il numero di invii è superiore al massimo trovato fin'ora
# svuota la lista se superiore, aggiungi alla lista se uguale (o superiore)
max_sent = 0
max_list = list()
for sender in sender_dict :
    if sender_dict[sender] < max_sent :
        continue
    if sender_dict[sender] > max_sent :
        max_sent = sender_dict[sender]
        max_list = list()
    max_list.append(sender)
print("numero massimo mail mandate:", max_sent)
print(max_list)