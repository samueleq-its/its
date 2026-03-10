from sqlite3 import IntegrityError
from db_handler import DB_Handler
from stanza import Stanza
import utils

def nuovo():
    codice = input("inserisci il codice della stanza: ").upper()
    descrizione = input("inserisci la descrizione della stanza: ")
    crs = DB_Handler.get_cursor()
    try:
        crs.execute("insert into rooms (code, description) values (?, ?);", (codice, descrizione))
    except IntegrityError:
        print("Errore: codice stanza già presente")
        return
    DB_Handler.commit()
    crs.close()
    print("nuova stanza salvata")

def leggi():
    crs = DB_Handler.get_cursor()
    crs.execute("SELECT * from rooms;")
    results = crs.fetchall()
    crs.close()
    if results == []:
        return None
    stanze = list()
    for codice, descrizione in results:
        stanze.append(Stanza(codice, descrizione))
    return stanze

def cerca():
    codice = input("inserisci il codice della stanza da cercare: ").upper()
    stanza = get(codice)
    if stanza == None:
        print("stanza non trovata")
        return
    print(stanza)
    if utils.domanda("modificare la stanza? s/n: "):
        modifica(stanza)

def get(codice):
    crs = DB_Handler.get_cursor()
    crs.execute("SELECT * from rooms WHERE code = ?;", (codice,))
    result = crs.fetchone()
    crs.close()
    if result == None:
        return None
    codice, descrizione = result
    return Stanza(codice, descrizione)

def modifica(stanza:Stanza):
    print("inserisci il nuovo valore, lasciare vuoto per passare al successivo senza modificare")
    user_input = input("modifica la descrizione: ")
    if user_input != "":
        stanza.descrizione = user_input
    salva(stanza)
    print("stanza aggiornata")
    print(stanza)

def salva(stanza:Stanza):
    crs = DB_Handler.get_cursor()
    crs.execute(
        "UPDATE rooms SET description=? WHERE code = ?;",
        (stanza.descrizione, stanza.codice)
        )
    DB_Handler.commit()
    crs.close()

def stampa(stanze):
    for stanza in stanze:
        print(stanza)