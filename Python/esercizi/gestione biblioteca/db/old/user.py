import sqlite3

class User():

    def __init__(self, id:int, name:str, surname:str) -> None:
        self.id = id
        self.name = name
        self.surname = surname
    
    @staticmethod
    def search_user(conn:sqlite3.Connection, id:int) -> User|None: #|None  = None, name:str|None = None, surname:str|None = None):
        cur = conn.cursor()
        cur.execute("SELECT id,name,surname FROM users WHERE id = 1")
        result = cur.fetchone()
        print(result)
        return User(result[0],result[1],result[2]) if result else None

    @staticmethod
    def get_users(conn:sqlite3.Connection) -> list[User]:
        cur = conn.cursor()
        cur.execute("SELECT id,name,surname FROM users")
        results = cur.fetchall()
        users = list()
        for result in results:
            user = User(result[1],result[2],result[3])
            users.append(user)
        return users

    @staticmethod
    def save_user(conn:sqlite3.Connection, name:str, surname:str):
        cur = conn.cursor()
        cur.execute("INSERT INTO users (name,surname) VALUES (?,?)", (name, surname))
        conn.commit()


if __name__ == "__main__":
    conn = sqlite3.connect("library.sqlite")
    print(User.search_user(conn, 1))