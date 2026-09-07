from msvcrt import getch
import os

clear = lambda: os.system('cls')


def gen_frame() -> list[list[str]]:
	frame : list[list[str]] = list()

	for y in range(width):
		frame.append(list())
		for x in range(height):
			frame[y].append(map[(x, y)])

	#display player
	x = player["position"]["x"]
	y = player["position"]["y"]
	frame[y][x] = player["sprite"]

	return frame

def display_frame(frame: list[list[str]]) -> None:
	clear()
	for row in frame:
		print(str.join("",row))


map = dict()
width: int = 10
height: int = 10

player: dict = {
	"sprite": "@",
	"position" : {"x":width//2,"y":height//2}
	}

for x in range(width):
	for y in range(height):
		map[(x, y)] = "."

frame = gen_frame()
display_frame(frame)

while True:

	char = getch()
	print(char)

	match char:
		case b"w":
			player["position"]["y"] -= 1
		case b"s":
			player["position"]["y"] += 1
		case b"d":
			player["position"]["x"] += 1
		case b"a":
			player["position"]["x"] -= 1
		case _:
			exit()

	frame = gen_frame()
	display_frame(frame)

