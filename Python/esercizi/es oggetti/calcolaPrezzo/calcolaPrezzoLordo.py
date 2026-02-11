import calcolaPrezzo

class CalcolaPrezzoLordo(calcolaPrezzo.CalcolaPrezzo):
    def calcola_totale(self):
        subtotale = super().calcola_totale()
        iva = float(input("inserisci l'IVA applicabile: ")) / 100
        return subtotale + subtotale * iva

