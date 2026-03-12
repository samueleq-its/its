/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * prints to console a series of books and writes wheter they have been red or not
 */

let books = [
    {
        title: "The Lord of the Ring",
        author: "J.R.R. Tolkien",
        alreadyRead: true
    },
    {
        title: "The Hobbit",
        author: "J.R.R. Tolkien",
        alreadyRead: true
    },
    {
        title: "Harry Potter and the Philosopher's Stone",
        author: "J.K. Rowling",
        alreadyRead: false
    }
];

for (let i = 0; i < books.length; i++) {
    let string = "";
    if (books[i].alreadyRead) {
        string = "You already read";
    } else {
        string = "You still need to read";
    }
    console.log(string + " \"" + books[i].title + "\" by " + books[i].author);
}