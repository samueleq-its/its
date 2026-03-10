from db_handler import DB_Handler
from cliente import Cliente
import utils

def nuovo():
    nome_gruppo = input("inserisci il nome del gruppo: ")
    nome_contatto = input("inserisci il nome del contatto: ")
    tell = input("inserisci il numero di telefono: ")
    email = input("inserisci l'email: ")
    crs = DB_Handler.get_cursor()
    crs.execute("insert into clients (group_name, contact_name, phone, email) values (?, ?, ?, ?);", (nome_gruppo, nome_contatto, tell, email))
    DB_Handler.commit()
    crs.close()
    print("nuovo cliente salvato")

def leggi():
    crs = DB_Handler.get_cursor()
    crs.execute("SELECT * from clients;")
    results = crs.fetchall()
    crs.close()
    if results == []:
        return None
    clienti = list()
    for id, nome_gruppo, nome_contatto, tell, email in results:
        clienti.append(Cliente(id,nome_gruppo, nome_contatto, tell, email))
    return clienti

def cerca():
    while True:
        try:
           id = int( input("inserisci l'id da cercare: "))
        except:
            print("inserisci un numero intero positivo")
            continue
        if id < 0:
            print("inserisci un numero intero positivo")
            continue
        break
    cliente = get(id)
    if cliente == None:
        print("cliente non trovato")
        return
    print(cliente)
    if utils.domanda("modificare il cliente? s/n: "):
        modifica(cliente)

def get(id):
    crs = DB_Handler.get_cursor()
    crs.execute("SELECT * from clients WHERE id = ?;", (id,))
    result = crs.fetchone()
    crs.close()
    if result == None:
        return None
    id, nome_gruppo, nome_contatto, tell, email = result
    return Cliente(id,nome_gruppo, nome_contatto, tell, email)

def modifica(cliente:Cliente):
    print("inserisci il nuovo valore, lasciare vuoto per passare al successivo senza modificare")

    user_input = input("modifica il nome del gruppo: ")
    if user_input != "":
        cliente.nome_gruppo = user_input
        
    user_input = input("modifica il nome del contatto: ")
    if user_input != "":
        cliente.nome_contatto = user_input

    user_input = input("modifica il numero di telefono: ")
    if user_input != "":
        cliente.tell = user_input
    
    user_input = input("modifica l'email: ")
    if user_input != "":
        cliente.email = user_input
    salva(cliente)
    print("cliente aggiornato")
    print(cliente)

def salva(cliente:Cliente):
    crs = DB_Handler.get_cursor()
    crs.execute(
        "UPDATE clients SET group_name=?, contact_name=?, phone=?, email=? WHERE id = ?;",
        (cliente.nome_gruppo, cliente.nome_contatto, cliente.tell, cliente.email, cliente.id)
        )
    DB_Handler.commit()
    crs.close()

def stampa(clienti):
    for cliente in clienti:
        print(cliente)