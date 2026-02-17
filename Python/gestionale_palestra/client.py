from db_handler import DB_Handler

# IF Client.id == 0 : client not found

class Client():

    def __init__(self, id:int, name:str, surname:str, subscribed:bool) -> None:
        self.id = id
        self.name = name
        self.surname = surname
        self.subscribed = subscribed

    #TODO: better names
    @classmethod
    def db_to_obj(cls, select:list) -> Client:
        return Client(
            select[0],
            select[1],
            select[2],
            select[3] == 1
            )


    @classmethod
    def add(cls, name:str, surname:str) -> Client:
        crs = DB_Handler.get_cursor()
        crs.execute ("INSERT INTO clients(name, surname, subscribed) VALUES(?, ?, ?)", (name, surname, True)) 
        added = cls.find(crs.lastrowid)
        DB_Handler.commit()
        crs.close()
        return added

    @classmethod
    def read(cls) -> list[Client]:
        crs = DB_Handler.get_cursor()
        crs.execute("SELECT id, name, surname, subscribed FROM clients;")
        results = crs.fetchall()
        crs.close()
        if results == None:
            return []
        clients = list()
        for result in results:
            clients.append(cls.db_to_obj(result))
        return clients

    @classmethod
    def find(cls,id:int) -> Client:
        crs = DB_Handler.get_cursor()
        crs.execute("SELECT id, name, surname, subscribed FROM clients WHERE id = ?;", (id,))
        result = crs.fetchone()
        crs.close()
        if result == None:
            return Client(0,"","",False)
        return cls.db_to_obj(result)

    def set_subscription(self, subscription_status:bool):
        crs = DB_Handler.get_cursor()
        crs.execute("UPDATE clients SET subscribed = ? WHERE id = ?;", (subscription_status, self.id))
        self.subscribed = subscription_status
        DB_Handler.commit()
        crs.close()

    def delete(self):
        crs = DB_Handler.get_cursor()
        crs.execute("DELETE FROM clients WHERE id = ?;", (self.id,))
        DB_Handler.commit()
        crs.close()

    def to_string(self):
        return f"{self.id}, {self.name}, {self.surname}, {self.subscribed}"