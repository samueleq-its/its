import sqlite3

class DB_Handler():
    DB_NAME:str = "./db/library.sqlite"
    _connection_ = sqlite3.connect(DB_NAME)

    @classmethod
    def get_cursor(cls):
        if cls._connection_ == None:
            cls._connection_ = sqlite3.connect(cls.DB_NAME)
        return cls._connection_.cursor()
    
    '''
    @classmethod
    def query(cls, sql, param=())->list|None:
        crs = cls.get_cursor()
        crs.execute(sql,param)
        cls.commit()
        return crs.fetchall()
    '''

    @classmethod
    def commit(cls) -> None:
        if cls._connection_ == None:
            print("ERRORE: connessione chiusa")
            return
        cls._connection_.commit()

    @classmethod
    def close(cls) -> None:
        if cls._connection_ == None:
            print("ERRORE: connessione chiusa")
            return
        cls._connection_.close()
        cls._connection_ = None
