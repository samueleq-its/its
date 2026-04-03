import mysql.connector

magazzino = mysql.connector.connect(
    host="localhost",
    user="root",
    password="root",
    database="magazzino"
)

cursore = magazzino.cursor(dictionary=True)

query = """
SELECT
    p.nome AS "nome prodotto",
    p.prezzo_unitario AS prezzo,
    p.quantita_stock AS stock,
    c.nome AS "categoria",
    f.ragione_sociale AS "Fornitore"
FROM prodotti p
JOIN fornitori f USING (id_fornitore)
JOIN categorie c USING (id_categoria)
ORDER BY categoria, fornitore
;
"""

cursore.execute(query)

prodotti = cursore.fetchall()

cursore.close()
magazzino.close()