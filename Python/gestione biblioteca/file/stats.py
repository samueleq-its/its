import users
import utils
import libri
import prestiti_restituzioni

#Report: libri più prestati, utenti con più prestiti

def stats():
    funzioni_menu = [
    {"descrizione": "Visualizza libri più prestati", "funzione":piu_prestati},
    {"descrizione": "Visualizza utenti con più prestiti", "funzione":utenti_piu_prestiti}
    ]
    while True:
        fn = utils.crea_menu(funzioni_menu)
        if fn == None:
            break
        fn()


def piu_prestati():
    libri_dict = libri.read_DB()
    prestiti_dict = prestiti_restituzioni.readDB()
    #crea dict = {isbn: copie_prestate}
    libri_prestati = dict()
    for _,isbn in prestiti_dict:
        libri_prestati[isbn] = libri_prestati.get(isbn, 0) + 1
    #ordina in [(isbn, copie_prestate),...]
    libri_prestati = sorted(libri_prestati.items(), key=lambda x:x[1], reverse=True)
    #stampa nome_libro - copie_prestate
    print()
    for isbn,copie_prestate in libri_prestati:
        print(f"{libri_dict[isbn]["titolo"]} - {copie_prestate} copie prestate")
    print()
    #TODO? stamparne solo una parte?

def utenti_piu_prestiti():
    utenti_dict = users.read_DB()
    prestiti_dict = prestiti_restituzioni.readDB()
    #crea dict id:n_libri_in_prestito
    utenti_prestiti = dict()
    for id,isbn in prestiti_dict:
        utenti_prestiti[id] = utenti_prestiti.get(id,0) + 1
    #ordina utenti_prestiti per n. libri
    utenti_prestiti = sorted(utenti_prestiti.items(),key= lambda x:x[1],reverse=True)
    #stampa elenco utenti_prestiti con nome e cognome
    print()
    for user_id,n_prestiti in utenti_prestiti:
        print(f"{utenti_dict[user_id][0]} {utenti_dict[user_id][1]} - {n_prestiti} libri richiesti")
    print()
    #TODO? stamparne solo una parte?




if __name__ == "__main__" :
    stats()