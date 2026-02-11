fhand = open('fail.txt')
for line in fhand:
    line = line.rstrip()
    words = line.split()
    if len(words) > 2 and words[0] == 'From':
        print(words[2])