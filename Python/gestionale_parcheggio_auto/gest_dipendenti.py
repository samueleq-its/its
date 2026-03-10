from db_handler import DB_Handler
from dipendente import Dipendente
import utils

def nuovo():
    ''' aggiunge un  nuovo dipendente al DB'''
    #inserimento dati dipendente
    nome = input("inserisci il nome: ")
    if nome == "":
        print("il nome non può essere vuoto")
        return
    cognome = input("inserisci il cognome: ")
    if cognome == "":
        print("il cognome non può essere vuoto")
        return
    #salvataggio dipendente su DB
    crs = DB_Handler.get_cursor()
    crs.execute("insert into dipendenti (nome, cognome) values (?, ?);", (nome, cognome))
    DB_Handler.commit()
    crs.close()
    print("nuovo dipendente salvato")

def elenco():
    '''restituisce una elenco di tutti i dipendenti presenti nel DB'''
    crs = DB_Handler.get_cursor()
    crs.execute("SELECT * from dipendenti;")
    results = crs.fetchall()
    crs.close()
    if results == []:
        return None
    dipendenti = list()
    for id, nome, cognome in results:
        dipendenti.append(Dipendente(id, nome, cognome))
    return dipendenti

def trova():
    '''cerca un dipendente per id, stampa i suoi dati'''
    id = utils.input_int("inserisci l'id del dipendente da cercare: ")
    dipendente = get(id)
    if dipendente == None:
        print("dipendente non trovato")
        return
    print(dipendente)

def get(id):
    '''restituisce un dipendente dato il suo id, None se non trovato'''
    crs = DB_Handler.get_cursor()
    crs.execute("SELECT * from dipendenti WHERE id = ?;", (id,))
    result = crs.fetchone()
    crs.close()
    if result == None:
        return None
    id, nome, cognome = result
    return Dipendente(id, nome, cognome)