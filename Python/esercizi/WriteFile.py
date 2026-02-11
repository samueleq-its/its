fout = open ('output.txt', 'w')
line1 = "test \n "
print(repr(line1)) # repr() restituisce l'argomento sotto forma di stringa con i caratteri speciali (\n) visibili
fout.write (line1)
fout.write ("test")
fout.write ("test2")
fout.close()