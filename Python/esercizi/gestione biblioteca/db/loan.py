from db_handler import DB_Handler
from book import Book

class Loan():
    def __init__(self,id,user_id,book_id,loan_date,return_date) -> None:
        self.id = id,
        self.user_id = user_id,
        self.book_id = book_id,
        self.loan_date = loan_date,
        self.return_date = return_date

    @staticmethod
    def get_loans():
        crs = DB_Handler.get_cursor()
        crs.execute("SELECT id, user_id, book_isbn, loan_date, return_date FROM loans")
        results = crs.fetchall()
        if results == None:
            return None
        loans = list()
        for result in results:
            loans.append(
                Loan(result[0],
                    result[1],
                    result[2],
                    result[3],
                    result[4]))
        return loans

    @staticmethod
    def search_loans(id=None, user_id=None, book_isbn=None, returned:bool|None=None) ->list[Loan]|None:
        if id == None and user_id == None and book_isbn == None:
            print("ERRORE: almeno un parametro di ricerca deve essere specificato")
            return        
        crs = DB_Handler.get_cursor()
        query = "SELECT id, user_id, book_isbn, loan_date, return_date FROM loans WHERE "
        query += f"id={id}" if id!=None else ""
        query += f"user_id={user_id}" if user_id!=None else ""
        query += f"book_isbn={book_isbn}" if book_isbn!=None else ""
        if returned != None:
            query += f"return_date IS {"NOT" if returned else ""} NULL"
        crs.execute(query)
        results = crs.fetchall()
        if results == None:
            return None
        loans = list()
        for result in results:
            loans.append(
                Loan(result[0],
                    result[1],
                    result[2],
                    result[3],
                    result[4]))
        return loans

    @classmethod
    def add_loan(cls, user_id:int, book_isbn:int, loan_date:str) -> bool:
        #TODO: check if book exist?
        #check if the book is available
        if Book.search_book(book_isbn).availability < 1:
            return False
        #check if user has already loaned the book without returning it
        if cls.search_loans(user_id=user_id,book_isbn=book_isbn,returned=False):
            return False
        #insert into DB
        crs = DB_Handler.get_cursor()
        crs.execute(
                "INSERT INTO loans(user_id, book_isbn, loan_date) "
                " VALUES(?,?,?)", 
                (user_id, book_isbn, loan_date,)
            )
        Book.update_availability(book_isbn,-1)

        DB_Handler.commit()
        return True

    @classmethod
    def return_loan(cls, id:int, return_date:str):
        pass


#test add_loan()
#test get_loans()
#test search_loan()
#test return_loan()