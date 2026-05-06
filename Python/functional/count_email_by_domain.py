from functools import reduce

def frequencyDict(acc, item):
	acc[item] = acc.get(item, 0) + 1
	return acc

file_path = "./txt/mbox.txt"
file = open(file_path)

from_lines = filter(lambda line : line.startswith("From"), file)
emails = map(lambda mail : mail.split()[1], from_lines)
domains = map(lambda line : line.split("@")[1], emails)
stats = reduce(frequencyDict ,domains, {}).items()
stats = sorted(stats, key= lambda item : item[1], reverse= True)

file.close()

for a,b in stats:
	print(a,b)