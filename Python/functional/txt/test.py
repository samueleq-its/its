file_name = "romeo-full.txt"

def cr_count_chars():
	chars = dict()
	chars["total"] = 0
	response = None
	while True:
		cmd = (yield response).lower()
		response = None
		if  cmd.startswith("-"):
			match cmd:
				case "-result":
					response = chars
				case "-reset":
					chars.clear()
					chars["total"] = 0
				case _:
					pass
			continue
		else:
			chars[cmd] = chars.get(cmd, 0) + 1
			chars["total"] += 1

def file_to_lines(file_name):
	with open(file_name) as f:
		for line in f:
			yield line.strip()

def line_to_chars(line):
	for char in line:
		if char.isalpha():  # Consider only alphabetic characters
			yield char

char_counter = cr_count_chars()
next(char_counter)  # Initialize the generator

for line in file_to_lines(file_name):
	for char in line_to_chars(line):
		char_counter.send(char)
chars = char_counter.send("-result")  # Get the final character counts
if chars is not None:
	rel_chars = {char: count / chars["total"] for char, count in chars.items() if char != "total"}

sorted_chars = sorted(rel_chars.items(), key=lambda item: item[1], reverse=True)
for char, count in sorted_chars:
	print(f"{char}: {count:.1%}")
