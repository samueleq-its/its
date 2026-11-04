import json, random, unicodedata
from datetime import datetime, timedelta

random.seed(42)
N_STUDENTI, N_CORSI, N_ISCRIZIONI = 2000, 20, 5000

nomi = ["Marco","Giulia","Luca","Sofia","Matteo","Chiara","Alessandro","Martina","Andrea","Sara",
        "Davide","Elena","Simone","Francesca","Federico","Alice","Lorenzo","Giorgia","Riccardo","Anna",
        "Gabriele","Valentina","Tommaso","Elisa","Edoardo","Beatrice","Nicolò","Aurora","Mattia","Greta",
        "Michele","Noemi","Stefano","Ilaria","Paolo","Silvia","Daniele","Laura","Fabio","Marta"]
cognomi = ["Rossi","Russo","Ferrari","Esposito","Bianchi","Romano","Colombo","Ricci","Marino","Greco",
           "Bruno","Gallo","Conti","De Luca","Mancini","Costa","Giordano","Rizzo","Lombardi","Moretti",
           "Barbieri","Fontana","Santoro","Mariani","Rinaldi","Caruso","Ferrara","Galli","Martini","Leone",
           "Longo","Gentile","Martinelli","Vitale","Lombardo","Serra","Coppola","De Santis","D'Angelo","Marchetti"]
vie = ["Via Roma","Via Garibaldi","Corso Francia","Via Verdi","Via Dante","Via Mazzini","Corso Vittorio Emanuele",
       "Via Cavour","Via Po","Via Torino","Via Milano","Via San Francesco","Via Marconi","Piazza Castello","Via Pellico"]
citta = [("Torino","10100"),("Asti","14100"),("Cuneo","12100"),("Novara","28100"),("Alessandria","15121"),
         ("Biella","13900"),("Vercelli","13100"),("Alba","12051"),("Moncalieri","10024"),("Chieri","10023")]
classi = ["1A","1B","2A","2B","3A","3B","4A","4B","5A","5B"]
materie = ["Matematica","Italiano","Inglese","Informatica","Storia","Fisica","Sistemi","Basi di dati"]

def slug(s):
    s = unicodedata.normalize("NFD", s).encode("ascii","ignore").decode()
    return s.lower().replace(" ","").replace("'","")

studenti = []
for i in range(1, N_STUDENTI+1):
    nome, cognome = random.choice(nomi), random.choice(cognomi)
    classe = random.choice(classi)
    eta = 13 + int(classe[0]) + random.randint(0, 1)
    c, cap = random.choice(citta)
    voti = [{"materia": m, "valore": max(3, min(10, round(random.gauss(6.8, 1.5))))}
            for m in random.sample(materie, random.randint(3, 6))]
    studenti.append({
        "studenteId": f"S{i:04d}", "nome": nome, "cognome": cognome, "eta": eta, "classe": classe,
        "email": f"{slug(nome)}.{slug(cognome)}{i}@studenti.example.it",
        "indirizzo": {"via": f"{random.choice(vie)} {random.randint(1,150)}", "citta": c, "cap": cap},
        "voti": voti})

corsi_def = [("Programmazione Python",6,"Prof. Bianchi"),("Basi di dati relazionali",6,"Prof. Ferrari"),
 ("NoSQL e MongoDB",6,"Prof. Ferrari"),("Reti di calcolatori",9,"Prof. Moretti"),
 ("Sistemi operativi",9,"Prof. Moretti"),("Sviluppo Web Frontend",6,"Prof.ssa Conti"),
 ("Sviluppo Web Backend",6,"Prof.ssa Conti"),("Cybersecurity",6,"Prof. Greco"),
 ("Cloud Computing",6,"Prof. Greco"),("Machine Learning",9,"Prof.ssa Ricci"),
 ("Data Analysis",6,"Prof.ssa Ricci"),("Project Management",3,"Prof. Romano"),
 ("Inglese tecnico",3,"Prof.ssa Marino"),("Matematica discreta",9,"Prof. Colombo"),
 ("Algoritmi e strutture dati",9,"Prof. Bianchi"),("DevOps e CI/CD",6,"Prof. Gallo"),
 ("Sviluppo App Mobile",6,"Prof.ssa Costa"),("Ingegneria del software",9,"Prof. Colombo"),
 ("Internet of Things",6,"Prof. Gallo"),("Business Intelligence",6,"Prof.ssa Marino")]
corsi = [{"corsoId": f"C{i:02d}", "nomeCorso": n, "docente": d, "crediti": cr}
         for i,(n,cr,d) in enumerate(corsi_def, 1)]

pesi = [random.uniform(0.4, 2.0) for _ in corsi]
coppie = set()
while len(coppie) < N_ISCRIZIONI:
    s = random.choice(studenti)["studenteId"]
    c = random.choices(corsi, weights=pesi)[0]["corsoId"]
    coppie.add((s, c))

def iso(d): return {"$date": d.strftime("%Y-%m-%dT%H:%M:%SZ")}
base, oggi = datetime(2024,9,1), datetime(2026,10,1)
iscrizioni = []
for s, c in sorted(coppie):
    d_isc = base + timedelta(days=random.randint(0, 420))
    d_esame = d_isc + timedelta(days=random.randint(30, 400))
    if random.random() < 0.12 or d_esame > oggi:      # esame non ancora sostenuto
        voto, d_esame = None, None
    else:
        voto = max(18, min(30, round(random.gauss(24.5, 3.5))))
    iscrizioni.append({"studenteId": s, "corsoId": c, "votoFinale": voto,
                       "dataIscrizione": iso(d_isc), "dataEsame": iso(d_esame) if d_esame else None})
random.shuffle(iscrizioni)

for nome, dati in [("studenti",studenti),("corsi",corsi),("iscrizioni",iscrizioni)]:
    with open(f"{nome}.json","w",encoding="utf-8") as f:
        json.dump(dati, f, ensure_ascii=False, indent=1)
    print(nome, len(dati))
