/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * defines an array movies as objects and prints their properties to console
 */

/**
 * prints the properties of a movie to console
 * @param {Object} movie the movie object to be printed
 */
function printMovie(movie) {
    console.log(`${movie.title} lasts for ${movie.duration} mintutes. Stars:${movie.stars}`);
}

let movies = [
    {
        title: "Dune",
        duration: 155,
        stars: ["Timothée Chalamet", "Zendaya", "Oscar Isaac", "Rebecca Ferguson"]
    },
    {
        title: "Inception",
        duration: 148,
        stars: ["Leonardo DiCaprio", "Marion Cotillard", "Ellen Page", "Joseph Gordon-Levitt"]
    },
    {
        title: "The Matrix",
        duration: 136,
        stars: ["Keanu Reeves", "Laurence Fishburne", "Carrie-Anne Moss", "Hugo Weaving"]
    },
    {
        title: "Interstellar",
        duration: 169,
        stars: ["Matthew McConaughey", "Anne Hathaway", "Jessica Chastain", "Michael Caine"]
    }
];

for (let i = 0; i < movies.length; i++) {
    printMovie(movies[i]);
}