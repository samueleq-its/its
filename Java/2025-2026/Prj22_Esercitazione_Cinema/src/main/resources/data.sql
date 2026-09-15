INSERT INTO cinema (nome_cinema, indirizzo, telefono, posti) VALUES
('Cineplex Roma', 'Via del Corso 100, Roma', '06-123456', 250),
('Multisala Milano', 'Corso Como 50, Milano', '02-987654', 180),
('Cinema Centrale Napoli', 'Via Toledo 200, Napoli', '081-555444', 200),
('UCI Firenze', 'Piazza della Repubblica 1, Firenze', '055-222111', 220),
('Odeon Torino', 'Via Roma 30, Torino', '011-444333', 190);

INSERT INTO film (titolo, regista, genere) VALUES
('Inception', 'Christopher Nolan', 'Fantascienza'),
('Il Signore degli Anelli - La Compagnia dell''Anello', 'Peter Jackson', 'Fantasy'),
('Forrest Gump', 'Robert Zemeckis', 'Drammatico'),
('La La Land', 'Damien Chazelle', 'Romantico'),
('Interstellar', 'Christopher Nolan', 'Fantascienza');

INSERT INTO film_in_sala (id_cinema, id_film, data, prezzo, posti_rimanenti) VALUES
(1, 1, '2026-07-05 19:00:00', 9.50, 220),
(2, 2, '2026-07-05 21:30:00', 10.00, 160),
(3, 3, '2026-07-06 20:00:00', 8.50, 180),
(4, 4, '2026-07-06 22:15:00', 9.00, 200),
(5, 5, '2026-07-07 19:45:00', 10.50, 175);

INSERT INTO prenotazioni (id_filminsala, nome, posti_prenotati) VALUES
(1, 'Mario Rossi', 2),
(2, 'Giulia Bianchi', 4),
(3, 'Luca Verdi', 1),
(4, 'Anna Neri', 3),
(5, 'Paolo Gallo', 2);