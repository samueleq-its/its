class Loan():
    def __init__(self,id,user_id,book_id,loan_date,return_date) -> None:
        self.id = id,
        self.user_id = user_id,
        self.book_id = book_id,
        self.loan_date = loan_date,
        self.return_date = return_date

    @classmethod
    def get_loans(cls):
        pass

    @classmethod
    def search_loan(cls, id:int):
        pass

    @classmethod
    def add_loan(cls, user_id:int, book_id:int, loan_date:str):
        pass

    @classmethod
    def return_loan(cls, id:int, return_date:str):
        pass

