import re

# ricevo da input un espressione regolare
# cerco su un file (hardcoded?) e ritorno quante linee corrispondono all espressione

reg_es = input("Enter a regular expression: ")
print(reg_es)

file_name  = "mbox-short.txt"
count = 0
with open("..\\" + file_name) as file:
    for line in file:
        try:
            if re.search(reg_es, line):
                count += 1
        except:
            print("regular expression not valid")
            exit()

print(file_name, "had %d lines that matched %s" %(count, reg_es))
