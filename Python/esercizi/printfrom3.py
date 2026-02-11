fhand = open('mbox-short.txt')

str_to_search = input("insert string: ")

for line in fhand:
    line = line.rstrip()
    if line.find(str_to_search) == -1: #@uct.ac.za
        continue
    print(line)