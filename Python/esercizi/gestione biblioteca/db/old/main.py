import utils
import users
import prestiti_restituzioni
import stats

funzioni_menu = [
    {"descrizione": "Aggiungi nuovo utente", "funzione":users.inserimento_utente},
    {"descrizione": "Prestiti e restituzioni", "funzione":prestiti_restituzioni.menu_scelta},
    {"descrizione": "Visualizza statistiche", "funzione":stats.stats}
]
while True:
    fun = utils.crea_menu(funzioni_menu)
    if fun == None:
        break
    fun()