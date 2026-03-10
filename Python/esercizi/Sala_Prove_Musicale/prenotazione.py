class Prenotazione:
    def __init__(self, id, id_cliente,codice_stanza,data, ora) -> None:
        self.id = id
        self.id_cliente = id_cliente
        self.codice_stanza = codice_stanza
        self.data = data
        self.ora = ora