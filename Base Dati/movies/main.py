from movie_repo import MovieRepo

database = MovieRepo()
print(database.get_all_movies())