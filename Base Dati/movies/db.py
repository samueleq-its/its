import requests

class DB:
    def getMovies(self):
        response = requests.get("https://raw.githubusercontent.com/maboglia/ProgrammingResources/refs/heads/master/tabelle/film/imdb_top_2000_movies.json")
        if response.status_code == 200:
            return response.json()
        else:
            print("Failed to retrieve movies from the database.")
            return []