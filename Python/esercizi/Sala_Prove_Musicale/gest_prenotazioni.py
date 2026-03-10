from db_handler import DB_Handler
from prenotazione import Prenotazione
import gest_clienti
import gest_stanze
import utils

def nuovo():
    while True:
        try:
            id_cliente = int(input("inserisci l'id del cliente: "))
        except:
            print("Errore: inserire un numero valido.")
            continue
        cliente = gest_clienti.get(id_cliente)
        if cliente == None:
            print("Cliente non trovato")
            continue
        break
    while True:
        codice_stanza = input("inserisci il codice della stanza: ").upper()
        stanza = gest_stanze.get(codice_stanza)
        if stanza == None:
            print("Stanza non trovata")
            continue
        break
    data = input("inserisci la data: ") #nessun controllo sul formato
    while True:
        try:
            ora = int(input("inserisci l'ora: ")) #nessun controllo sul formato
        except:
            print("inserisci l'ora in formato valido es: 9")
            continue
        if ora < 9 or ora > 17:
            print("la sala è aperta tra le 9 e le 18")
        break
    crs = DB_Handler.get_cursor()
    crs.execute("SELECT * FROM reservations WHERE id_client = ? AND date = ? AND time = ?;", (id_cliente, data, ora))
    if crs.fetchone() != None:
        print("Errore: il cliente ha già una prenotazione per quella data e ora")
        return
    crs.execute("SELECT * FROM reservations WHERE code_room = ? AND date = ? AND time = ?;", (codice_stanza, data, ora))
    if crs.fetchone() != None:
        print("Errore: la stanza è già prenotata per quella data e ora")
        return
    
    crs.execute("INSERT INTO reservations (id_client, code_room, `date`, `time`) VALUES (?, ?, ?, ?);", (id_cliente, codice_stanza, data, ora))
    DB_Handler.commit()
    crs.close()

def leggi():
    crs = DB_Handler.get_cursor()
    crs.execute("SELECT r.id, r.code_room, r.id_client, clients.group_name, r.date, r.time from reservations AS r JOIN clients On r.id_client = clients.id;")
    risultati = crs.fetchall()
    if risultati == []:
        print("Nessuna prenotazione presente")
    for id, codice_stanza,id_cliente, nome_gruppo, data, ora in risultati:
        print(f"{id} - {codice_stanza} - {id_cliente} - {nome_gruppo} - {data} - {ora}" )
    crs.close()

#TODO: la query viene eseguita due volte, una per cercare la prenotazione e una per stamparla
def cerca():
    while True:
        try:
            id = int(input("inserisci l'id della prenotazione da cercare: "))
        except:
            print("Errore: inserire un numero valido.")
            continue
        break
    prenotazione = get(id)
    if prenotazione == None:
        print("Prenotazione non trovata")
        return
    stampa_prenotazione(prenotazione)
    if utils.domanda("cancellare la prenotazione? s/n: "):
        cancella(prenotazione)
        print("prenotazione cancellata")

def get(id):
    crs = DB_Handler.get_cursor()
    crs.execute("SELECT r.id, r.code_room, r.id_client, r.date, r.time from reservations AS r WHERE id = ?;", (id,))
    result = crs.fetchone()
    crs.close()
    if result == None:
        return None
    id, codice_stanza, id_cliente,  data, ora = result
    return Prenotazione(id, codice_stanza, id_cliente, data, ora)

def stampa_prenotazione(prenotazione:Prenotazione):
    crs = DB_Handler.get_cursor()
    crs.execute("SELECT r.id, r.code_room, r.id_client, clients.group_name, r.date, r.time from reservations AS r JOIN clients On r.id_client = clients.id WHERE r.id = ?;", (prenotazione.id,))
    result = crs.fetchone()
    if result == None:
        print("Prenotazione non trovata")
        return
    id, codice_stanza, id_cliente, nome_gruppo, data, ora = result
    print(f"{id} - {codice_stanza} - {id_cliente} - {nome_gruppo} - {data} - {ora}" )
    crs.close()

def cancella(prenotazione:Prenotazione):
    crs = DB_Handler.get_cursor()
    crs.execute("DELETE FROM reservations WHERE id = ?;", (prenotazione.id,))
    DB_Handler.commit()

