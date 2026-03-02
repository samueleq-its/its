'''
initialize the DB with empty tables
'''

import sqlite3

conn = sqlite3.connect("sala_musicale.sqlite")
cur = conn.cursor()

#cur.execute('DROP TABLE IF EXISTS clients')
#cur.execute('''CREATE TABLE clients (
#    id integer primary key autoincrement,
#    group_name text not null,
#    contact_name text not null,
#    phone text not null,
#    email text not null
#    )''')

#cur.execute('DROP TABLE IF EXISTS rooms')
#cur.execute('''CREATE TABLE rooms (
#    code str primary key,
#    description text
#    )''')

cur.execute('DROP TABLE IF EXISTS reservations')
cur.execute('''CREATE TABLE reservations (
    id integer primary key autoincrement,
    id_client integer not null,
    code_room text not null,
    date text not null,
    time text not null,
    foreign key (id_client) references clients(id),
    foreign key (code_room) references rooms(code)
    )''')

conn.commit()
conn.close()