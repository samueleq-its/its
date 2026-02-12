'''
initialize the DB with empty tables
'''

import sqlite3

conn = sqlite3.connect("./db/library.sqlite")
cur = conn.cursor()

cur.execute('DROP TABLE IF EXISTS users')
cur.execute('''CREATE TABLE users (
    id integer primary key autoincrement,
    name text,
    surname text
    )''')

cur.execute('DROP TABLE IF EXISTS books')
cur.execute('''CREATE TABLE books (
    isbn text primary key,
    title text,
    author text,
    availability integer
    )''')

cur.execute('DROP TABLE IF EXISTS loans')
cur.execute('''CREATE TABLE loans (
    id integer primary key autoincrement,
    user_id integer,
    book_isbn text,
    loan_date date,
    return_date date,
    foreign key (user_id) references users(id),
    foreign key (book_isbn) references books(isbn)
    )''')

conn.commit()
conn.close()

