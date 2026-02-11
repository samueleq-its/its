# legge un file e ne stampa il contenuto (riga per riga) in maiuscolo
while True :
    fname = input("insert file name: ")
    try :
        fhand = open(fname)
        break
    except :
        print("file not found")
        continue
for line in fhand :
    print(line.strip().upper())