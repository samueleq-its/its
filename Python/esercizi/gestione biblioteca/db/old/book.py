import sqlite3

class Book():
    def __init__(self, isbn, title, author, availability) -> None:
        self.isbn = isbn
        self.title = title
        self.author = author
        self.availability = availability

    # def load_books():
    #     books = list()
    #     conn = sqlite3.connect("library.sqlite")
    #     cur = conn.cursor()
    #     cur.execute("SELECT isbn, title, author, availability FROM books")
    #     rows = cur.fetchall()
    #     for row in rows:
    #         book = Book(row[0],row[1],row[2],row[3])
    #         books.append(book)

    def save_books(self):
        conn = sqlite3.connect("library.sqlite")
        cur = conn.cursor()

        try:
            cur.execute(
                "INSERT INTO books(isbn,title,author, availability) "
                " VALUES(?,?,?,?)", (
                self.isbn, self.title, self.author, self.availability)
            )
            conn.commit()
            conn.close()
        except:
            print("ERRORE: impossibile salvare il libro, verifica ISBN")

    def get_books(self):
        books = list()
        conn = sqlite3.connect("library.sqlite")
        cur = conn.cursor()

        query = "SELECT isbn, title, author, availability FROM books"
        if self.isbn:
            query += "WHERE isbn = ?"
            cur.execute(query, self.isbn)
            book_data = cur.fetchone()
            books.append(book_data)
        else:
            cur.execute(query)
            book_data = cur.fetchall()
            for book in book_data:
                books.append(book)

        conn.close()

        if len(books) > 0:
            return books
        else:
            print("ERRORE: libro non trovato")
            return None