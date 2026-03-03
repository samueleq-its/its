import json

studenti =[
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
]

with open('studenti.json', 'w', encoding='utf-8') as f:
    json.dump(studenti, f, indent=4)

print(f"INSERT INTO studenti (nome, cognome) VALUES")
for studente in studenti:
    print(f"('{studente[0]}','{studente[1]}'),")