import re
import os

file_name  = input("Enter file:")
count = 0
if not os.path.exists(file_name):
    print("file not found")
    exit()

reg_ex = "rev=([0-9]+)"
sum = 0
count = 0
with open(file_name) as file:
    for line in file:
        rev = re.findall(reg_ex, line)
        if len(rev) > 0:
            sum += int(rev[0])
            count += 1

print(sum/count)