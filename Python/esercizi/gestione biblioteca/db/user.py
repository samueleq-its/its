from db_handler import DB_Handler

class User():

    def __init__(self,id:int,name:str,surname:str,) -> None:
        self.id = id
        self.name = name
        self.surname = surname

    @staticmethod
    def get_users() -> list[User]|None:
        crs = DB_Handler.get_cursor()
        crs.execute("SELECT id, name, surname FROM users")
        results = crs.fetchall()
        if results == None:
            return None
        users = list()
        for result in results:
            users.append(
                User(result[0],
                    result[1],
                    result[2]))
        return users

    @staticmethod
    def search_user(id:int) -> User|None:
        crs = DB_Handler.get_cursor()
        crs.execute(
            "SELECT id, name, surname FROM users WHERE id = ?", (id,))
        result = crs.fetchone()
        if result == None:
            return None
        return User(result[0],
                    result[1],
                    result[2])

    @staticmethod
    def add_user(name:str, surname:str):
        #insert into DB
        crs = DB_Handler.get_cursor()
        crs.execute(
                "INSERT INTO users(name, surname) "
                " VALUES(?,?)", (
                name, surname)
            )
        DB_Handler.commit()
        return True

    def to_list(self)-> list:
        return [self.id,self.name,self.surname]

    def to_string(self):
        user_string = (
            f"ID:{self.id}, NOME:{self.name}, "
            f"COGNOME:{self.surname}"
            )
        return user_string