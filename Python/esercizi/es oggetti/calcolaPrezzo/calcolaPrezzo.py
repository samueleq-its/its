class CalcolaPrezzo():
    def __init__(self):
        self.prezzo = 0
        self.unita = 0
    
    def incrementa_unita(self, n):
        self.unita += n
    
    def set_prezzo(self, prezzo):
        self.prezzo = prezzo
    
    def calcola_totale(self):
        return self.prezzo * self.unita
    
    def stampa_totale(self):
        print(self.calcola_totale())

