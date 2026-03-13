
class Libro:

    def __init__(self, id, codice, autore, titolo, editore, classificazione) -> None:
        self.id = id
        self.codice = codice
        self.autore = autore
        self.titolo = titolo
        self.editore = editore
        self.classificazione = classificazione

    def __str__(self) -> str:
        return f"""
        Titolo : {self.titolo}
        Autore : {self.autore}
        Classificazione : {self.classificazione}
        """