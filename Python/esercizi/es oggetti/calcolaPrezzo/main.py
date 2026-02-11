import calcolaPrezzoLordo

if __name__ == "__main__":
    cpl = calcolaPrezzoLordo.CalcolaPrezzoLordo()
    cpl.set_prezzo(1.5)
    cpl.incrementa_unita(5)
    cpl.stampa_totale()