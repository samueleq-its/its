use papflix;
desc games;
SELECT * FROM games;

create table gamescopy like games;

insert into gamescopy
select * from games;

alter table games
add column game_id int primary key auto_increment first;

select distinct genre as genere from games order by genere;

/* '_' cerca 0 o 1 carattere, '%' cerca  0 o infiniti caratteri */
select * from games where genre like "%Ac_ion_";



select 
	genre as genere,
    count(game) as giochi
from games 
group by genere
order by giochi desc -- ordine discendente
limit 10; -- top ten

create table studenti(
	id int primary key auto_increment,
    nome varchar(30),
    cognome varchar(30)
);

INSERT INTO studenti (nome, cognome) VALUES
	('Simone','Albanese'),
	('Mondir','Badaoui'),
	('Alessia','Cantelli'),
	('Matteo','Charrier'),
	('Andrea','Chiampo'),
	('Ale','Cistaro'),
	('Antonino','Consolato'),
	('Nicolas','Currà'),
	('Tommaso','Fatticcioni'),
	('Manuel','Frola'),
	('Nicole','Girardi'),
	('Federico','Grimaldi'),
	('Luca Daniel','Iosipescu'),
	('Alessandro','Maone'),
	('Maikol','Mombelli'),
	('Alessandro','Nardo'),
	('Cristian','Pappalardo'),
	('ismail','perta'),
	('Samuele','Querio'),
	('Marco','Rizzone'),
	('Daniel','Salamone'),
	('Gianluca','Salzarulo'),
	('andrea','savoia'),
	('Caterina','Seccia'),
	('Gabriele','Serrain'),
	('Mattia','Viada'),
	('Anqi','Xu'),
	('Rui Min Marco','Zhu'),
	('Benedetto','Brancato')
;

select * from studenti
order by rand()
limit 1;


