#1 - instantiate the list
numlist = list()
while (True):
  inp = input('Enter a number: ')
  if inp == 'done': break
  value = float(inp) # try except
  #2 - adds the number to the list
  numlist.append(value)

#3 - average as sum of the numbers / length of the array
if(len(numlist) > 0) :
    average = sum(numlist) / len(numlist)
    print('Average:', average)
    print("max:", max(numlist))
    print("min:", min(numlist))