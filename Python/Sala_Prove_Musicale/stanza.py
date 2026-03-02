class Stanza:

    def __init__(self, codice, descrizione) -> None:
        self.codice = codice
        self.descrizione = descrizione


    def __str__(self) -> str:
        return f"{self.codice} - {self.descrizione}"