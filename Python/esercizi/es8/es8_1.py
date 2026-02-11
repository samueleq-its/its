# chop removes first and last element from list, returns None
# middle return new list with list without first and last element

def chop(t):
    del t[0]
    del t[-1]

def middle(t):
    return t[1:-1]

elenco = [1,2,3,4,5,6,7,8,9,10]
print("elenco:", elenco)
chop(elenco)
print("elenco dopo chop:", elenco)
print("middle:", middle(elenco))
print("elenco dopo middle:", elenco)
