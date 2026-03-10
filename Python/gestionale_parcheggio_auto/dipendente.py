class Dipendente:

    def __init__(self, id, nome, cognome) -> None:
        self.id = id
        self.nome = nome
        self.cognome = cognome

    def __str__(self) -> str:
        return f"{self.id} - {self.nome} {self.cognome}"