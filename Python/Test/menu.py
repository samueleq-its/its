from colorama import Fore, Back, Style
from msvcrt import getch
import os

clear = lambda: os.system('cls')

menu_lines = list()

menu_lines.append("1. Opzione A ")
menu_lines.append("2. Opzione B ")
menu_lines.append("3. Opzione C ")

selected = 0

while(True):
	clear()
	for i in range(len(menu_lines)):
		line = menu_lines[i]
		if i == selected:
			line = Back.LIGHTYELLOW_EX + Fore.BLACK + line + Style.RESET_ALL
		print(line)

	# _, dir = getch(),getch()
	# print(_, dir)
	
	# b'*' + H, M, P, K
	# b'\x03'  CTRL + C
	# b'\r' ENTER

	while (True):
		dir = getch()
		match (dir):
			case b'H':
				selected = max(0,selected -1)
				break
			case b'P':
				selected = min(len(menu_lines)-1, selected + 1)
				break
			case b'\x03':
				exit()