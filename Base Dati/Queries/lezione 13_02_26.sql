/* comment */ -- comment # comment
-- ctrl + enter : esegui riga 
-- ctrl + shift + enter : esegui tutto / selezione

/*
potrebbe averli caricati sulla FAD

https://github.com/maboglia
Database/ 
	04_DB_Progettazione/02_data_engineering.md
	02_SQL_Fondamenti/
		DDL, DML, DCL
	02_SQL_Fondamenti/14_QueryLanguage.md
	03_SQL_QueryLanguage
		CREATE, SELECT, UPDATE, DELETE, WHERE
*/

/*
USER: root
*/

# DCL
-- creato nuovo utente
CREATE USER biblioteca_admin IDENTIFIED by '123456';
-- creato nuovo database
CREATE database biblioteca;
-- permessi all'utente sul db
grant all on biblioteca.* to biblioteca_admin;

/*
USER : biblioteca_admin
*/

-- indicare quale DB utilizzare (senza doverlo specificare ogni volta)
use biblioteca;

show tables; -- tutto vuoto

-- table editori
create table editori(
	editore_id int primary key auto_increment, -- primary key = not null + unique
    nome varchar(30) not null unique,
    contatto varchar(100)    
);

-- table libri: un libro deve essere collegato ad un editore
create table libri(
	libro_id int primary key auto_increment,
    titolo varchar(100) not null,
    prezzo decimal(5,2) default 0, -- 123,45
    pagine int default 0,
    editore_id int not null 
    /* non è specificato che 'editore_id' è una foreign key,
    il DB non verificherà se è effettivamente presente quell'id */
);


insert into editori (nome, contatto) values ('Mondadori','info@mondadori.it');
select * from editori;
delete from editori where editore_id = 1;
select * from editori;

insert into editori (nome, contatto) values ('Mondadori','info@mondadori.it');
update editori set contatto = 'commerciale@mondadori.it' where editore_id = 1;
select * from editori; -- l'id è ora 2
truncate editori; -- ricostruisce la tabella, svuota il contenuto e azzera i contatori
insert into editori (nome, contatto) values ('Mondadori','info@mondadori.it');

insert into libri (titolo, editore_id) values ('Zanna bianca', 1);
insert into libri (titolo, editore_id) values ('Zanna verde', 1);
insert into libri (titolo, editore_id) values ('Zanna gialla', 2);
select * from libri; -- inserito 'editore_id' 2 anche se non esisten

select libri.titolo, editori.nome
from libri, editori
where libri.editore_id = editori.editore_id;
-- non mostra il terzo libro perchè non c'è un editore associato

-- elimina la tabella
drop table if exists libri;
create table if not exists libri(
	libro_id int primary key auto_increment,
    titolo varchar(100) not null,
    prezzo decimal(5,2) default 0, -- 123,45
    pagine int default 0,
    editore_id int not null,
    foreign key (editore_id) references editori (editore_id) -- i nomi possono essere diversi
);

insert into libri (titolo, editore_id) values ('Zanna bianca', 1);
insert into libri (titolo, editore_id) values ('Zanna verde', 1);
insert into editori (nome, contatto) values ('De Agostini','info@deagostini.com');
insert into libri (titolo, editore_id) values ('Zanna gialla', 2);


drop table editori; -- non viene eseguito perchè ha una chiave esterna in un altra tabella
insert into libri (titolo, editore_id) values ('Zanna gialla', 2); -- fallisce perchè id 2 non esiste

/*
03_SQL_QueryLanguage/0080_Constraints.md

ON DELETE CASCADE: 
elimina tutti gli elementi associati (eliminando un editore vengono eliminati tutti i libri associati)

02_SQL_FONDAMENTI/16_Alter_Table.md
*/

create table libri_rari like libri;
insert into libri_rari select * from libri;
select * from libri_rari;

create table autori(
	autore_id int primary key auto_increment,
	nome varchar(30) not null,
	cognome varchar(30) default null,
	nazionalita char(2) default null
);

-- relazione molti a molti per associare libri ed autori (più autori per stesso libro, più libri per stesso autore)

drop table if exists autori_libri;
create table autori_libri(
	libro_id int not null,
	autore_id int not null,
	primary key (libro_id, autore_id), -- la chiave primaria è composta dall' unione di entrambi i campi, e la combinazione non può ripetersi
	foreign key (libro_id) references libri (libro_id),
    foreign key (autore_id) references autori (autore_id)
);

-- resettiamo le tabelle prima di caricare i dati
-- mostra il comando completo per la creazione della tabella (le istruzioni date durante il create più altre aggiunte in automatico)
show create table autori_libri; 
-- rimozione constraint, pulizia tabella, reinserimento constraint
alter table libri drop foreign key libri_ibfk_1;
truncate table libri;
truncate table editori;
alter table libri add constraint libri_ibfk_1 foreign key (editore_id) references editori (editore_id);

/* 
caricare i dati nelle tabelle
*/
INSERT INTO `editori` VALUES (1,'Mondadori','info-mondadori@gmail.com'),(3,'Einaudi','amm-einaudi@gmail.com'),(4,'Salani','salani-info@gmail.com'),(5,'Edizioni Clandestine','clandestine-info@gmail.com'),(6,'Bao Publishing','bao_editore@gmail.com'),(7,'Sellerio','amm-sellerio@gmail.com'),(8,'BUR','bur_editore@gmail.com'),(9,'Sperling & Kupfer','sperling-info@gmail.com'),(10,'Bompiani','contact-bompiani@gmail.com'),(11,'Adelphi','adelphi-info@gmail.com');

INSERT INTO `libri` VALUES (1,'Alchimista (L\')',12.00,10,1),(2,'Cinquanta sfumature di grigio',10.20,560,1),(3,'Dieci piccoli indiani',10.20,208,1),(4,'Don Chisciotte della Mancha',20.40,123,3),(5,'Harry Potter e la Pietra Filosofale',8.50,302,4),(6,'Il Codice da Vinci',11.00,512,1),(7,'Il giovane Holden',10.20,251,3),(8,'Il leone, la strega e l\'armadio',7.65,182,1),(9,'Il libretto rosso',7.22,160,5),(10,'Il Piccolo Principe',4.25,95,1),(11,'Il Signore degli Anelli: La compagnia dell\'anello. Le due torri. Il ritorno del re',25.00,1255,10),(12,'Il sogno della camera rossa. Romanzo cinese del XVIII secolo',15.30,721,3),(13,'La colonna di fuoco',27.00,912,1),(14,'La donna della domenica',12.00,434,1),(15,'Lo Hobbit',9.35,417,10),(16,'Macerie prime',14.45,192,6),(17,'Origin',21.25,564,1),(18,'Quel che resta del giorno',12.00,276,3),(19,'Un mese con Montalbano',12.75,512,7),(20,'Una storia tra due città',9.77,600,10),(21,'Marcovaldo',10.00,120,7),(22,'IT',25.00,550,9),(23,'gomorra',12.59,345,1);

INSERT INTO `autori` VALUES (1,'John Ronald Reuel','Tolkien','za'),(2,'Dan','Brown','us'),(3,'Paulo','Coelho','br'),(4,'J. D.','Salinger','us'),(5,'Agatha','Christie','en'),(6,'J. K.','Rowling','en'),(7,'Tsao','Chan','cn'),(8,'E. L.','James','en'),(9,'Antoine','de Saint-Exup?ry','fr'),(10,'Charles','Dickens','en'),(11,'Miguel','de Cervantes','es'),(12,'Clive Staples','Lewis','en'),(13,'Tse-tung','Mao','cn'),(14,'Michele','Rech, Zerocalcare','it'),(15,'Andrea','Camilleri','it'),(16,'Ken','Follett','en'),(17,'Kazuo','Ishiguro','jp'),(18,'Carlo','Fruttero','it'),(19,'Franco','Lucentini','it'),(20,'Italo','Calvino','it'),(21,'Stephen','King','us'),(22,'Isabel','Allende','cl');

INSERT INTO `autori_libri` VALUES (1,3),(2,8),(3,5),(4,11),(5,6),(6,2),(7,4),(8,12),(9,13),(10,9),(11,1),(12,7),(13,16),(14,18),(14,19),(15,1),(16,14),(17,2),(18,17),(19,15),(20,10),(21,20),(22,21);

/*
06_Esercitazioni/testo/09_Libreria.md
*/

select
	l.titolo,
	e.nome as 'Casa editrice',
    (l.prezzo * 1.22) as 'prezzo iva inclusa'
from 
	libri l, -- 'libri l' = 'libri as l': rinomina all'interno del comando
    editori e
where l.editore_id = e.editore_id
order by l.prezzo; -- non serve a nulla, solo per mostrare ordinamento per un campo non mostrato

alter table libri add column prezzo_ivato decimal (5,2);
update libri set prezzo_ivato = prezzo * 1.22;

select
	l.titolo,
    concat (a.nome,"",a.cognome) as autore,
    e.nome as editore
from
	autori_libri al,
    libri l,
    autori a,
    editori e
where
	al.libro_id = l.libro_id
and al.autore_id = a.autore_id
and l.editore_id = e.editore_id
order by e.nome, l.titolo -- ordina prima per editore poi per titolo
;
/*
esportare il risultato del comando sopra in CSV
continua in libreria.py
*/


-- 14. Contare il numero di libri per ogni editore