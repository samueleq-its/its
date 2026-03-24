SELECT 
    *
FROM
    prodotti;

-- Selezionare nome e prezzo dei prodotti con prezzo superiore a 100€.
SELECT 
    nome, prezzo_unitario
FROM
    prodotti
WHERE
    prezzo_unitario > 100
;
-- Elencare i fornitori di Milano.
SELECT 
    *
FROM
    fornitori
WHERE
    citta = 'Milano'
;
-- Trovare i prodotti con quantità in stock pari a 0 (esauriti).
SELECT 
    *
FROM
    prodotti
WHERE
    quantita_stock = 0
;
-- Selezionare i prodotti che contengono la parola 'Laptop' nel nome.
SELECT 
    *
FROM
    prodotti
WHERE
    nome LIKE '%Laptop%';

-- Elencare le categorie in ordine alfabetico.
SELECT 
    *
FROM
    categorie
ORDER BY nome;

-- Trovare i prodotti con prezzo compreso tra 50€ e 500€.
select * from prodotti
where prezzo_unitario BETWEEN 50 and 500;

-- Mostrare i fornitori che non hanno un'email specificata (se fosse NULL).
select * from fornitori
WHERE email is NUll;

-- Selezionare i primi 3 prodotti più costosi.
SELECT * FROM prodotti
ORDER BY prezzo_unitario desc
limit 3;

-- Calcolare il valore totale della merce (prezzo * quantità) per ogni prodotto
SELECT 
    nome, (quantita_stock * prezzo_unitario) AS 'valore totale'
FROM
    prodotti;


# Query con Join (Relazioni tra tabelle)

-- Visualizzare nome prodotto e nome della relativa categoria.
SELECT 
    prodotti.nome, categorie.nome
FROM
    prodotti
        JOIN
    categorie ON prodotti.id_categoria = categorie.id_categoria;

-- Elencare i prodotti insieme alla ragione sociale del loro fornitore.
SELECT 
    prodotti.nome, fornitori.ragione_sociale
FROM
    prodotti,
    fornitori
WHERE
    prodotti.id_fornitore = fornitori.id_fornitore
;

-- Trovare tutti i prodotti della categoria 'Elettronica'.
SELECT 
    p.id_prodotto, p.nome, c.nome
FROM
    prodotti AS p
        JOIN
    categorie AS c ON p.id_categoria = c.id_categoria
        AND c.nome = 'Elettronica'
;

-- Mostrare i prodotti forniti da 'TechSpA'.
SELECT 
    p.*, f.ragione_sociale
FROM
    prodotti AS p
        JOIN
    fornitori AS f ON p.id_fornitore = f.id_fornitore
        AND f.ragione_sociale = 'TechSpA'
;

-- Elencare i nomi dei prodotti e le città dei loro fornitori.
SELECT 
    p.nome, f.citta
FROM
    prodotti AS p
        JOIN
    fornitori AS f ON p.id_fornitore = f.id_fornitore
;

-- Visualizzare i prodotti della categoria 'Arredamento' con stock > 0.
SELECT 
    *
FROM
    prodotti AS p
        JOIN
    categorie AS c ON p.id_categoria = c.id_categoria
        AND p.quantita_stock > 0
;

-- Mostrare le categorie che hanno almeno un prodotto fornito da un fornitore di 'Torino'.

SELECT 
    c.nome
FROM
    categorie AS c
        JOIN
    prodotti AS p ON p.id_categoria = c.id_categoria
        JOIN
    fornitori AS f ON f.id_fornitore = p.id_fornitore
WHERE
    f.citta = 'Torino'
GROUP BY c.nome
;



-- Visualizzare i prodotti (nome) e il fornitore, ma solo se il prezzo è > 200€.
SELECT prodotti.nome, fornitori.ragione_sociale
FROM prodotti
JOIN fornitori
ON prodotti.id_fornitore = fornitori.id_fornitore
WHERE prezzo_unitario > 200
;

-- Lista completa: Nome Prodotto, Categoria, Fornitore.
SELECT p.nome, c.nome, f.ragione_sociale 
FROM prodotti as p
JOIN categorie as c
ON c.id_categoria = p.id_categoria
JOIN fornitori as f
ON f.id_fornitore = p.id_fornitore
;

-- Trovare i nomi dei fornitori che forniscono prodotti nella categoria 'Elettronica'.
SELECT f.ragione_sociale
FROM fornitori as f
JOIN prodotti as p
ON p.id_fornitore = f.id_fornitore
JOIN categorie as c
ON c.id_categoria = p.id_categoria
WHERE c.nome = "Elettronica"
GROUP BY f.ragione_sociale
;

-- Contare quanti prodotti ci sono in totale nel database.
SELECT  count(id_prodotto)
FROM prodotti
;

-- Calcolare il prezzo medio dei prodotti.
SELECT avg(prezzo_unitario)
FROM prodotti
;

-- Calcolare la somma totale degli articoli in magazzino.
SELECT  sum(quantita_stock)
FROM prodotti
;

-- Trovare il prezzo massimo per ogni categoria.
SELECT c.nome, max(p.prezzo_unitario) as "prezzo massimo"
FROM prodotti as p
JOIN categorie as c
ON c.id_categoria = p.id_categoria
GROUP BY c.nome
;

-- Contare quanti prodotti fornisce ogni fornitore.
SELECT f.ragione_sociale, count(p.id_prodotto)
FROM fornitori as f
JOIN prodotti as p
ON f.id_fornitore = p.id_fornitore
GROUP BY f.ragione_sociale
;

-- Calcolare il valore totale economico del magazzino intero.
SELECT SUM(quantita_stock * prezzo_unitario) as Totale from prodotti;

-- Mostrare le categorie che hanno più di 2 prodotti.
SELECT 
    c.nome, COUNT(p.id_prodotto) AS 'numero prodotti'
FROM
    categorie AS c
        JOIN
    prodotti AS p ON p.id_categoria = c.id_categoria
GROUP BY c.nome
HAVING COUNT(p.id_prodotto) > 2
; 

-- Trovare il fornitore che ha il prodotto più economico.
SELECT 
    f.ragione_sociale
FROM
    prodotti AS p
        JOIN
    fornitori AS f ON f.id_fornitore = p.id_fornitore
GROUP BY f.ragione_sociale
ORDER BY MIN(p.prezzo_unitario)
LIMIT 1
;

-- Calcolare la media dei prezzi dei prodotti per il fornitore 'TechSpA'.
SELECT 
    f.ragione_sociale, AVG(p.prezzo_unitario)
FROM
    fornitori AS f
        JOIN
    prodotti AS p ON p.id_fornitore = f.id_fornitore
GROUP BY f.id_fornitore
HAVING f.ragione_sociale = 'TechSpa'
;

-- Visualizzare le categorie e il numero di pezzi totali (somma stock) per ognuna.
SELECT 
    c.nome, SUM(p.quantita_stock)
FROM
    categorie AS c
        JOIN
    prodotti AS p ON p.id_categoria = c.id_categoria
GROUP BY c.nome
;
