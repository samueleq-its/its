from functools import reduce
import string

FILE = "./txt/romeo-full.txt"

fhand = open(FILE)
# TODO: file not found

tmp = map(lambda line : list(line), fhand)
tmp = reduce(lambda acc, cur : acc + cur, tmp)
tmp = filter(lambda char : char in string.ascii_letters, tmp)
tmp = sorted(tmp)

print(tmp)
for x in tmp:
	print(x)