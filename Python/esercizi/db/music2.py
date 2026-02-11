import sqlite3

conn = sqlite3.connect('music.sqlite')
cur = conn.cursor()

#cur.execute('INSERT INTO Tracks (title, plays) VALUES (?, ?)', ('Thunderstruck', 20))
#cur.execute('INSERT INTO Tracks (title, plays) VALUES (?, ?)', ('My Way', 15))
#conn.commit()

#print('Tracks:')
#cur.execute('SELECT title, plays FROM Tracks')
#for row in cur:
#  print(row)

#cur.execute('DELETE FROM Tracks WHERE plays < 100')
#conn.commit()

# Inserimento di un artista
cur.execute('INSERT INTO Artists (name) VALUES (?)', ('AC/DC',))
artist_id = cur.lastrowid

# Inserimento di un album
cur.execute('INSERT INTO Albums (artist_id, title) VALUES (?, ?)', (artist_id, 'Back in Black'))
album_id = cur.lastrowid

# Inserimento di tracce
cur.execute('INSERT INTO Tracks (album_id, title, plays) VALUES (?, ?, ?)', (album_id, 'Hells Bells', 30))
cur.execute('INSERT INTO Tracks (album_id, title, plays) VALUES (?, ?, ?)', (album_id, 'Shoot to Thrill', 25))
conn.commit()

cur.close()