# legge file, se riga inizia con "From" fare split, print indirizzo, conta
# numero di righe "From"
fhand = open("mbox-short.txt")
count = 0
for line in fhand:
    #if line.startswith("From:"):
    #    continue
    #if line.startswith("From"):
    
    #if line.startswith("From") and line[4] != ":" :
    if line.startswith("From ") :
        split_line = line.split()
        print(split_line[1])
        count += 1
print("n. linee From:", count)