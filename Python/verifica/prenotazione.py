from gest_studenti import find as find_studente

class Prenotazione:
    def __init__(self, id, codice_aula, id_studente):
        self.id = id
        self.codice_aula = codice_aula
        self.id_studente = id_studente

    def __str__(self):
        return f"id: {self.id} - aula: {self.codice_aula} - studente: {find_studente(self.id_studente)}"