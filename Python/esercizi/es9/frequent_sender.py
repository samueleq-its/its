# dizionari per contare numero mail mandate da ciascun indirizzo

fhand = open("mbox.txt")
sender_dict = dict()

for line in fhand :
    line  = line.rstrip()
    if line.startswith("From ") :
        words = line.split()
        # Error se non c'è seconda parola
        sender_dict[words[1]] = sender_dict.get(words[1], 0) + 1

most_sender = ""
max_sent = max(sender_dict.values())
for sender in sender_dict :
    if sender_dict[sender] == max_sent :
        print(sender, sender_dict[sender])