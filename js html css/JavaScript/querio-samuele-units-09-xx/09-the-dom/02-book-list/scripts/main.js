/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * Purpose of file
 *
 * Detailed explanation of what the file does
 * on multiple lines
 */

let books = [
	{
		title: "The Great Gatsby",
		author: "F. Scott Fitzgerald",
		alreadyRead: true,
		url: "./assets/img/gatsby.jpg"
	},
	{
		title: "To Kill a Mockingbird",
		author: "Harper Lee",
		alreadyRead: false,
		url: "./assets/img/mockingbird.jpg"
	},
	{
		title: "1984",
		author: "George Orwell",
		alreadyRead: true,
		url: "./assets/img/1984.jpg"
	},
	{
		title: "The Catcher in the Rye",
		author: "J.D. Salinger",
		alreadyRead: false,
		url: "./assets/img/rye.jpg"
	}
];

let bookList = document.createElement("ul");
for (let book of books) {
	let bookElement = document.createElement("li");
	bookElement.append(book.title + " - " + book.author);
	bookElement.className = book.alreadyRead ? "read" : "unread";
	bookElement.style.backgroundColor = book.alreadyRead ? "green" : "red";
	//img

	let img = document.createElement("img");
	img.src = book.url;
	bookElement.append(img);
	bookList.append(bookElement);
}
document.body.append(bookList);

setTimeout(
	() => {
		let delayedStyle = document.createElement("link");
		delayedStyle.rel = "stylesheet";
		delayedStyle.href = "./styles/delayed.css";
		document.head.append(delayedStyle);
	}, 5000
);