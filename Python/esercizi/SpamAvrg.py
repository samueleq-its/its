#legge un file, estrai il float dopo "X-DSPAM-Confidence:", visualizza la media
while True :
    fname = input("insert file name: ")
    if (fname == "na na boo boo") :
        print("NA NA BOO BOO TO YOU - You have been punk'd!")
        exit()
    try :
        fhand = open(fname)
        break
    except :
        print("file not found")
        continue

count = 0
total = 0
for line in fhand :    
    index = line.find("X-DSPAM-Confidence:")
    offset = 20

    if index != -1 :
        count += 1
        total += float((line[index+offset:]))
print("average spam confidence is: %f" % (total/count))
