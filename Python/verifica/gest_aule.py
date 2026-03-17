from sqlite3 import IntegrityError
from db_handler import DB_Handler
from aula import Aula
from gest_prenotazioni import delete_all_by_aula as delete_prenotazioni_aula
import utils

def add():
    codice = input("inserisci il codice dell'aula: ").upper()
    posti_disponibili = utils.input_int("inserisci il numero di posti disponibili: ")
    crs = DB_Handler.get_cursor()
    try:
        crs.execute("insert into aule (codice, posti_disponibili) values (?, ?);", (codice, posti_disponibili))
    except IntegrityError:
        print("Errore: codice aula già presente")
        return
    DB_Handler.commit()
    crs.close()
    print("nuova aula salvata")

def get_all():
    crs = DB_Handler.get_cursor()
    crs.execute("SELECT * from aule;")
    results = crs.fetchall()
    crs.close()
    if results == []:
        return None
    stanze = list()
    for codice, posti_disponibili in results:
        stanze.append(Aula(codice, posti_disponibili))
    return stanze

def find_helper():
    codice = input("inserisci il codice dell'aula da cercare: ").upper()
    aula = find(codice)
    if aula == None:
        print("aula non trovata")
        return
    print(aula)
    if utils.domanda("modificare il numero di posti disponibili dell'aula? s/n: "):
        change_available_seats_helper(aula)
    elif utils.domanda("cancellare l'aula? s/n: "):
        delete(aula)
        print("aula cancellata")
        

def find(codice):
    crs = DB_Handler.get_cursor()
    crs.execute("SELECT * from aule WHERE codice = ?;", (codice,))
    result = crs.fetchone()
    crs.close()
    if result == None:
        return None
    codice, posti_disponibili = result
    return Aula(codice, posti_disponibili)
    
def change_available_seats_helper(aula):
    while True:
        try:
            posti_disponibili = int(input("inserisci il nuovo numero di posti disponibili: ").strip())
        except ValueError:
            print("formato errato: inserisci un numero intero")
            continue
        if posti_disponibili < 0:
            print("non è possibile avere un numero negativo di posti disponibili")
            continue
        break
    aula.posti_disponibili = posti_disponibili
    
    print("aula aggiornata")
    print(aula)

def change_available_seats(aula, nuovi_posti_disponibili):
    crs = DB_Handler.get_cursor()
    crs.execute(
        "UPDATE aule SET posti_disponibili=? WHERE codice = ?;",
        (nuovi_posti_disponibili, aula.codice)
        )
    DB_Handler.commit()
    crs.close()

def delete(aula):
    crs = DB_Handler.get_cursor()
    crs.execute("DELETE FROM aule WHERE codice = ?;", (aula.codice,))
    DB_Handler.commit()
    crs.close()
    delete_prenotazioni_aula(aula.codice)
    