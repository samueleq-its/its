from hashlib import md5

# file_path = "C:\\Users\\samuele.querio\\Desktop\\prova2.txt"
# res = md5(open(file_path,'rb').read()).hexdigest()
# print(res)


print(
	md5("ciao".encode())
	.hexdigest()
	)