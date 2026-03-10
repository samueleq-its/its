class Cliente:

    def __init__(self, id, nome_gruppo, nome_contatto, tell, email) -> None:
        self.id = id
        self.nome_gruppo = nome_gruppo
        self.nome_contatto = nome_contatto
        self.tell = tell
        self.email = email

    def __str__(self) -> str:
        return f"{self.id} - {self.nome_gruppo} - {self.nome_contatto} - {self.tell} - {self.email}"