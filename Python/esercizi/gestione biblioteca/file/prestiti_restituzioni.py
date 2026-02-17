'''
Docstring for prestiti_restituzioni
'''

#TODO: non prestare un libro ad una persona che ha già quel libro

import utils
import io_utils
import libri
import users

FILE_PRESTITI = "DB_prestiti.txt"

def menu_scelta():
    while True:
        menu = (
            "1. Prestiti\n"
            "2. Restituzioni\n"
            "0. indietro"
            )
        print(menu)
        try:
            user_input = int(input("inserisci il numero corrispondente alla funzione scelta: "))
        except:
            utils.errore("valore errato")
            continue
        print()
        #avvia funzione richiesta
        match user_input:
            case 1:
                prestiti()
            case 2:
                restituzioni()
            case 0:
                return
            case _:
                utils.errore("opzione non disponibile")

def prestiti():
    dict_libri = libri.read_DB()
    nuovi_prestiti = list()
    id_utente = input_user_id()
    while True:
        isbn = input_isbn(dict_libri)
        if isbn == "EXIT":
            break
        if dict_libri[isbn]["n_copie"] < 1:
            utils.errore("libro non disponibile")
            continue
        dict_libri[isbn]["n_copie"] -= 1
        nuovi_prestiti.append(utils.list_to_string([id_utente,isbn]))
    #aggiornamento file prestiti
    io_utils.append_file(FILE_PRESTITI, nuovi_prestiti)
    #aggiornamento file libri
    nuovi_libri = list() #lista di stringhe da salvare su file
    for libro in dict_libri:
        line = utils.list_to_string([
            libro,
            dict_libri[libro]["titolo"],
            dict_libri[libro]["autore"],
            dict_libri[libro]["n_copie"]
            ])
        nuovi_libri.append(line)
    io_utils.write_file(libri.FILE_LIBRI, nuovi_libri)


def restituzioni():
    elenco_prestiti = readDB()
    dict_libri = libri.read_DB()
    id_utente = input_user_id()
    while True:
        isbn = input_isbn(dict_libri)
        if isbn == "EXIT":
            break
        try:
            i = elenco_prestiti.index((id_utente,isbn))
        except:
            utils.errore("non risulta un prestito di ISBN:"+ str(isbn) +" a id utente: "+ str(id_utente))
            continue
        del elenco_prestiti[i]
        dict_libri[isbn]["n_copie"] += 1
    #aggiornamento file prestiti
    nuovi_prestiti = list()
    for id,isbn in elenco_prestiti:
        nuovi_prestiti.append(utils.list_to_string([id,isbn]))
    io_utils.write_file(FILE_PRESTITI, nuovi_prestiti)
    #aggiornamento file libri
    nuovi_libri = list() #lista di stringhe da salvare su file
    for libro in dict_libri:
        line = utils.list_to_string([
            libro,
            dict_libri[libro]["titolo"],
            dict_libri[libro]["autore"],
            dict_libri[libro]["n_copie"]
            ])
        nuovi_libri.append(line)
    io_utils.write_file(libri.FILE_LIBRI, nuovi_libri)

def input_user_id():
    dict_utenti = users.read_DB()
    while True:
        id_utente = utils.input_quantita("inserisci l'ID utente: ")
        #verifica ID
        if not id_utente in dict_utenti:
            utils.errore("ID utente errato")
            continue
        #TODO:ricerca ID
        return id_utente

def input_isbn(dict_libri:dict):
    '''
    richiede di immettere da tastiera un ISBN e ne verifica la validità
    
    :param dict_libri: dizionario dei libri come ottenuto da libri.read_DB()
    :type dict_libri: dict
    :return ISBN:
    '''
    while True:
        isbn = input("inserisci l'ISBN, '?' per elenco libri o 'EXIT' per terminare: ").strip()
        if isbn == "EXIT":
            return "EXIT"
        #TODO:ricerca ISBN
        if isbn == "?":
            print("NON IMPLEMENTATO")
        try:
            isbn = int(isbn.strip())
        except:
            utils.errore("formato errato: inserisci un numero intero")
            continue
        #verifica ISBN
        if not isbn in dict_libri:
            utils.errore("ISBN errato")
            continue
        return isbn

def readDB():
    '''
    :returns [(user_id,isbn),...] :
    '''
    file_data = io_utils.read_file(FILE_PRESTITI)
    elenco_prestiti = list()
    if file_data == None:
        utils.errore("ERRORE: file "+ FILE_PRESTITI +" assente")
        exit()
    for line in file_data:
        entry = line.strip().split(",")
        #entry[0] = id utente
        #entry[1] = isbn
        elenco_prestiti.append((int(entry[0]),int(entry[1])))
    return elenco_prestiti

if __name__ == "__main__":
    menu_scelta()