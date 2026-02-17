from db_handler import DB_Handler

class Book():

    def __init__(self,isbn:int,title:str,author:str,availability:int) -> None:
        self.isbn = isbn
        self.title = title
        self.author = author
        self.availability = availability

    @staticmethod
    def get_books() -> list[Book]|None:
        crs = DB_Handler.get_cursor()
        crs.execute("SELECT isbn, title, author, availability FROM books")
        results = crs.fetchall()
        if results == None:
            return None
        books = list()
        for result in results:
            books.append(
                Book(result[0],
                    result[1],
                    result[2],
                    result[3]))
        return books

    @staticmethod
    def search_book(isbn:int) -> Book|None:
        crs = DB_Handler.get_cursor()
        crs.execute(
            "SELECT isbn, title, author, availability FROM books WHERE isbn = ?", (isbn,))
        result = crs.fetchone()
        if result == None:
            return None
        return Book(result[0],
                    result[1],
                    result[2],
                    result[3])

    @staticmethod
    def add_book(isbn:int, title:str, author:str, availability:int) -> bool:
        book = Book(isbn,title,author,availability)
        return book.save()

    @staticmethod
    def update_availability(isbn, change):
        #TODO
        pass

    def save(self) -> bool:
        #check if ISBN already present
        if self.search_book(self.isbn):
            return False
        #insert into DB
        crs = DB_Handler.get_cursor()
        crs.execute(
                "INSERT INTO books(isbn,title,author, availability) "
                " VALUES(?,?,?,?)", (
                self.isbn, self.title, self.author, self.availability)
            )
        DB_Handler.commit()
        return True

    def to_list(self):
        return [self.isbn,self.title,self.title,self.availability]

    def to_string(self):
        book_string = (
            f"ISBN:{self.isbn}, TITOLO:{self.title}, "
            f"AUTORE:{self.author}, DISPONIBILTA':{self.availability}"
            )
        return book_string
    