# # dizionari per contare numero mail mandate da ciascun dominio

fhand = open("mbox.txt")
domain_dict = dict()

for line in fhand :
    line  = line.rstrip()
    if line.startswith("From ") :
        words = line.split()
        # Error se non c'è seconda parola
        index = words[1].find("@") +1 #alternativa split("@")
        domain = words[1][index:]
        domain_dict[domain] = domain_dict.get(domain, 0) + 1
print(domain_dict)