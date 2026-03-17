'''
initialize the DB with empty tables
'''

import sqlite3

conn = sqlite3.connect("prenotazioni_aule.sqlite")
cur = conn.cursor()

cur.execute('DROP TABLE IF EXISTS studenti')
cur.execute('''CREATE TABLE studenti (
    id integer primary key autoincrement,
    nome text NOT NULL,
    cognome text NOT NULL
    )''')

cur.execute('DROP TABLE IF EXISTS aule')
cur.execute('''CREATE TABLE aule (
    codice text primary key,
    posti_disponibili int
    )''')

cur.execute('DROP TABLE IF EXISTS prenotazioni')
cur.execute('''CREATE TABLE prenotazioni (
    id integer primary key autoincrement,
    codice_aula text NOT NULL,
    id_studente integer NOT NULL,
    FOREIGN KEY(codice_aula) REFERENCES aule(codice),
    FOREIGN KEY(id_studente) REFERENCES studenti(id)
    )''')

#creazione aula "dummy", ha 5 posti in meno di quelli dichiarati
cur.execute("INSERT INTO aule (codice, posti_disponibili) VALUES ('DUMMY', 10);")

conn.commit()
conn.close()