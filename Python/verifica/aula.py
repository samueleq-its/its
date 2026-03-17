class Aula:

    def __init__(self, codice, posti_disponibili) -> None:
        self.codice = codice
        self.posti_disponibili = posti_disponibili


    def __str__(self) -> str:
        posti_disponibili = self.posti_disponibili - 5 if self.codice == "DUMMY" else self.posti_disponibili
        return f"aula: {self.codice} - posti disponibili: {posti_disponibili}"