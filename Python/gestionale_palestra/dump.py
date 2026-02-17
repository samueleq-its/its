'''
initialize the DB with empty tables
'''

import sqlite3

conn = sqlite3.connect("palestra.sqlite")
cur = conn.cursor()

cur.execute('DROP TABLE IF EXISTS clients')
cur.execute('''CREATE TABLE clients (
    id integer primary key autoincrement,
    name text,
    surname text,
    subscribed boolean
    )''')

cur.execute('DROP TABLE IF EXISTS courses')
cur.execute('''CREATE TABLE courses (
    id integer primary key autoincrement,
    name text,
    available integer
    )''')

cur.execute('DROP TABLE IF EXISTS subscriptions')
cur.execute('''CREATE TABLE subscriptions (
    id_course integer,
    id_client integer,
    foreign key (id_client) references clients(id),
    foreign key (id_course) references courses(id),
    primary key (id_course, id_client)
    )''')

conn.commit()
conn.close()