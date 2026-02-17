import sqlite3

connection = sqlite3.connect("library.sqlite")
cursor = connection.cursor()

# CREATES CLEAN TABLES

cursor.execute('DROP TABLE IF EXISTS Users')
cursor.execute('''
    CREATE TABLE Users (
    id integer primary key autoincrement,
    name text
    )''')

cursor.execute('DROP TABLE IF EXISTS Authors')
cursor.execute('''
    CREATE TABLE Authors (
    id integer primary key autoincrement,
    name text
    )''')

cursor.execute('DROP TABLE IF EXISTS Books')
cursor.execute('''CREATE TABLE Books (
    isbn integer primary key,
    title text,
    author_id integer,
    foreign key (author_id) references Authors(id)
    )''')

cursor.close()


class Database() :
    def __init__(self, name, ) -> None:
        pass