from tinydb import TinyDB, Query

db = TinyDB('magazzino.json')

# db.insert({"nome_prodotto": "PC", "prezzo": 1200})

for prodotto in db.all():
    print(prodotto["nome_prodotto"])