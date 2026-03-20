class Movie:
    def __init__(self, title, director, year, genre, rating):
        self.title = title
        self.director = director
        self.year = year
        self.genre = genre
        self.rating = rating

    def __str__(self):
        return f"{self.title} ({self.year}), directed by {self.director}, Genre: {self.genre}, Rating: {self.rating}/10"
    
    def __repr__(self):
        return self.__str__()