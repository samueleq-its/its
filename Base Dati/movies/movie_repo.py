from db import DB
from movie import Movie

class MovieRepo:
    def __init__(self):
        self.movies = []
        self.database = DB()

    def add_movie(self, movie):
        self.movies.append(movie)

    def reset_movies(self):
        self.movies.clear()

    def get_all_movies(self):
        for movie_data in self.database.getMovies():
            movie = Movie(
                title=movie_data.get("Movie Name"),
                director=movie_data.get("Director"),
                year=movie_data.get("Release Year"),
                genre=movie_data.get("Genre"),
                rating=movie_data.get("IMDB Rating")
            )
            self.add_movie(movie)
        return self.movies
