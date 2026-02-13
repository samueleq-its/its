'''
prende ogni riga da libri.csv e crea un html
'''

libri = list()

with open('libri.csv') as f:
    for row in f:
        row = row.replace("\n","")
        row = row.replace("\"","")
        titolo, autore, editore = row.split(",")
        libri.append((titolo, autore, editore))
        #print(titolo, autore, editore)

with open('libreria.html', 'w') as f:
    f.write("<html>\n")
    #manca link a stylesheet preso online
    f.write("<head>\n")
    f.write("\n</head>\n")

    f.write("<body>\n")
    f.write("<table>\n")


    for i,libro in enumerate(libri):
        f.write("<tr>\n")
        if i ==0:
            f.write("<th>")
            f.write(libro[0])
            f.write("</th>\n")
            f.write("<th>")
            f.write(libro[1])
            f.write("</th>\n")
            f.write("<th>")
            f.write(libro[2])
            f.write("</th>\n")
        else:
            f.write("<td>")
            f.write(libro[0])
            f.write("</td>\n")
            f.write("<td>")
            f.write(libro[1])
            f.write("</td>\n")
            f.write("<td>")
            f.write(libro[2])
            f.write("</td>\n")
            f.write("</th>\n")


    f.write("\n</table>\n")
    f.write("\n</body>\n")

    f.write("\n</html>\n")