import json
import random

# Seed per la riproducibilità dei dati
random.seed(42)

first_names = [
    "Marco", "Giulia", "Luca", "Francesca", "Alessandro", "Sofia", "Matteo", "Elena",
    "Andrea", "Chiara", "Davide", "Sara", "Lorenzo", "Alice", "Simone", "Martina",
    "Gabriele", "Giorgia", "Tommaso", "Beatrice"
]
last_names = [
    "Rossi", "Ferrari", "Russo", "Bianchi", "Romano", "Gallo", "Costa", "Fontana",
    "Conti", "Esposito", "Ricci", "Bruno", "De Luca", "Moretti", "Marino", "Greco"
]
cities = [
    ("Roma", "00100"), ("Milano", "20100"), ("Torino", "10100"), ("Napoli", "80100"),
    ("Bologna", "40100"), ("Firenze", "50100"), ("Palermo", "90100"), ("Genova", "16100")
]
streets = [
    "Via Roma", "Corso Vittorio Emanuele", "Via Milano", "Via Garibaldi",
    "Via Dante", "Corso Italia", "Via Verdi", "Via Mazzini"
]
subjects = ["Matematica", "Informatica", "Fisica", "Statistica", "Inglese", "Economia", "Basi di Dati"]

courses_data = [
    ("Basi di Dati", "Prof. Rossi", 9),
    ("Programmazione 1", "Prof. Bianchi", 12),
    ("Analisi Matematica", "Prof. Verdi", 9),
    ("Fisica Generale", "Prof. Neri", 6),
    ("Sistemi Operativi", "Prof. Ferrari", 9),
    ("Reti di Calcolatori", "Prof. Russo", 6),
    ("Algoritmi e Strutture Dati", "Prof. Costa", 12),
    ("Ingegneria del Software", "Prof. Romano", 9),
    ("Intelligenza Artificiale", "Prof. Conti", 6),
    ("Machine Learning", "Prof. Esposito", 6),
    ("Sicurezza Informatica", "Prof. Ricci", 6),
    ("Calcolo delle Probabilità", "Prof. Bruno", 6),
    ("Architettura dei Calcolatori", "Prof. Moretti", 9),
    ("Interazione Uomo-Macchina", "Prof. Marino", 6),
    ("Sviluppo Web", "Prof. Greco", 6),
    ("Sviluppo Mobile", "Prof. Barbieri", 6),
    ("Economia Aziendale", "Prof. Lombardi", 6),
    ("Lingua Inglese B2", "Prof. Giordano", 3),
    ("Data Mining", "Prof. Galli", 6),
    ("Cloud Computing", "Prof. Fontana", 6)
]

# 1. Generazione Corsi (20)
corsi = []
for i, (nome, docente, crediti) in enumerate(courses_data, 1):
    corsi.append({
        "corsoId": f"C{i:02d}",
        "nomeCorso": nome,
        "docente": docente,
        "crediti": crediti
    })

# 2. Generazione Studenti (2000)
studenti = []
classes = ["1A", "1B", "2A", "2B", "3A", "3B"]
for i in range(1, 2001):
    stu_id = f"S{i:04d}"
    nome = random.choice(first_names)
    cognome = random.choice(last_names)
    citta, cap = random.choice(cities)
    via = f"{random.choice(streets)}, {random.randint(1, 150)}"
    
    num_voti = random.randint(2, 4)
    voti = [
        {
            "materia": random.choice(subjects),
            "valore": random.randint(18, 30)
        }
        for _ in range(num_voti)
    ]
    
    studenti.append({
        "studenteId": stu_id,
        "nome": nome,
        "cognome": cognome,
        "eta": random.randint(19, 26),
        "classe": random.choice(classes),
        "email": f"{nome.lower()}.{cognome.lower()}{i}@example.com",
        "indirizzo": {
            "via": via,
            "citta": citta,
            "cap": cap
        },
        "voti": voti
    })

# 3. Generazione Iscrizioni (5000)
all_pairs = set()
iscrizioni = []
student_ids = [s["studenteId"] for s in studenti]
course_ids = [c["corsoId"] for c in corsi]

while len(iscrizioni) < 5000:
    s_id = random.choice(student_ids)
    c_id = random.choice(course_ids)
    pair = (s_id, c_id)
    if pair not in all_pairs:
        all_pairs.add(pair)
        iscrizioni.append({
            "studenteId": s_id,
            "corsoId": c_id,
            "votoFinale": random.randint(18, 30) if random.random() > 0.15 else None
        })

# Salvataggio file JSON
with open("studenti.json", "w", encoding="utf-8") as f:
    json.dump(studenti, f, ensure_ascii=False, indent=2)

with open("corsi.json", "w", encoding="utf-8") as f:
    json.dump(corsi, f, ensure_ascii=False, indent=2)

with open("iscrizioni.json", "w", encoding="utf-8") as f:
    json.dump(iscrizioni, f, ensure_ascii=False, indent=2)

print("File generati con successo: studenti.json, corsi.json, iscrizioni.json")