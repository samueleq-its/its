while True : 
    fname = input('Enter the file name: ')
    try:
      fhand = open(fname)
      break
    except:
      print('File cannot be opened:', fname)
      continue
count = 0
for line in fhand:
  if line.startswith('Subject:'):
    count = count + 1
print('There were', count, 'subject lines in', fname)