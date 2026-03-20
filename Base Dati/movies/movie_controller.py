from flask import Flask, jsonify, render_template
from movie_repo import MovieRepo

app = Flask(__name__)

@app.route('/')
def home():
    return "Welcome to the Movie Database!"

@app.route('/movies')
def movies():
    return render_template('movies.html', pagetitle="List of Movies", movies=MovieRepo().get_all_movies())


app.run(debug=True)