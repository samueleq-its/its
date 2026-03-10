'''
initialize the DB with empty tables
'''

import sqlite3

conn = sqlite3.connect("parcheggio.sqlite")
cur = conn.cursor()

cur.execute('DROP TABLE IF EXISTS dipendenti')
cur.execute('''CREATE TABLE dipendenti (
    id integer primary key autoincrement,
    nome text not null,
    cognome text not null
    )''')

cur.execute('DROP TABLE IF EXISTS posti_auto')
cur.execute('''CREATE TABLE posti_auto (
    codice text primary key,
    id_dipendente int,
    FOREIGN KEY(id_dipendente) REFERENCES dipendenti(id)
    )''')

conn.commit()
conn.close()