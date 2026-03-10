class PostoAuto:
    def __init__(self, codice, id_dipendente):
        self.codice = codice
        self.id_dipendente = id_dipendente

    def __str__(self):
        return f"Posto Auto: {self.codice}, Dipendente: {self.id_dipendente}"