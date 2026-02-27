import sqlite3

def dump():
    # Inizializza lo schema del database di esempio.
    conn = sqlite3.connect('gym.sqlite')
    cur = conn.cursor()

    cur.execute("DROP TABLE IF EXISTS registrations")
    cur.execute("DROP TABLE IF EXISTS courses")
    cur.execute("DROP TABLE IF EXISTS users")

    cur.execute('''CREATE TABLE users
                   (
                       id                 INTEGER PRIMARY KEY AUTOINCREMENT,
                       name               TEXT    NOT NULL,
                       lastName           TEXT    NOT NULL,
                       subscription_state BOOLEAN NOT NULL
                   )''')

    cur.execute('''CREATE TABLE courses
                   (
                       id          INTEGER PRIMARY KEY AUTOINCREMENT,
                       name        TEXT    NOT NULL UNIQUE,
                       busy_places INTEGER NOT NULL,
                       max_places  INTEGER NOT NULL
                   )''')

    cur.execute('''CREATE TABLE registrations
                   (
                       id        INTEGER PRIMARY KEY AUTOINCREMENT,
                       data      DATE    NOT NULL,
                       user_id   INTEGER NOT NULL,
                       course_id INTEGER NOT NULL,
                       FOREIGN KEY (user_id) REFERENCES users (id),
                       FOREIGN KEY (course_id) REFERENCES courses (id)
                   )''')

    conn.commit()
    conn.close()
