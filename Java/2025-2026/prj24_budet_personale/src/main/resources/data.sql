INSERT INTO users(name,email,password)
VALUES
('Giovanni Rossi','giovanni@example.com','$2a$10$abc123...'),
('Maria Bianchi','maria@example.com','$2a$10$def456...'),
('Luca Verdi','luca@example.com','$2a$10$ghi789...');

INSERT INTO transactions(user_id,description,date,amount,type,category,receipt)
VALUES
(1,'Affitto Settembre','2025-09-01',850.00,'USCITA','Affitto','uploads/affitto.jpg'),
(2,'Stipendio','2025-09-05',1500.00,'ENTRATA','Stipendio',NULL),
(3,'Supermercato','2025-09-10',80.50,'USCITA','Spese
Generali','uploads/scontrino.jpg');