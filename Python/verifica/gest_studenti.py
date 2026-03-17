from db_handler import DB_Handler
from studente import Studente
import utils

def add():
    ''' aggiunge un  nuovo studente al DB'''
    #inserimento dati studente
    nome = input("inserisci il nome: ")
    if nome == "":
        print("il nome non può essere vuoto")
        return
    cognome = input("inserisci il cognome: ")
    if cognome == "":
        print("il cognome non può essere vuoto")
        return
    #salvataggio studente su DB
    crs = DB_Handler.get_cursor()
    crs.execute("insert into studenti (nome, cognome) values (?, ?);", (nome, cognome))
    DB_Handler.commit()
    crs.close()
    print("nuovo studente salvato")

def get_all():
    '''restituisce una elenco di tutti gli studenti presenti nel DB'''
    crs = DB_Handler.get_cursor()
    crs.execute("SELECT * from studenti;")
    results = crs.fetchall()
    crs.close()
    if results == []:
        return None
    studenti = list()
    for id, nome, cognome in results:
        studenti.append(Studente(id, nome, cognome))
    return studenti

def find(id):
    '''restituisce un studente dato il suo id, None se non trovato'''
    crs = DB_Handler.get_cursor()
    crs.execute("SELECT * from studenti WHERE id = ?;", (id,))
    result = crs.fetchone()
    crs.close()
    if result == None:
        return None
    id, nome, cognome = result
    return Studente(id, nome, cognome)

def find_helper():
    '''cerca un studente per id, stampa i suoi dati'''
    id = utils.input_positive("inserisci l'id dello studente da cercare: ")
    studente = find(id)
    if studente == None:
        print("studente non trovato")
        return
    print(studente)