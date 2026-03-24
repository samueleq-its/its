# 2.Book list
Use an array of books like this  
You should have at least 4 books
```
let books = [
{
title: 'The Design of EveryDay Things',
author: 'Don Norman',
alreadyRead: false
}, {
title: 'The Most Human Human',
author: 'Brian Christian',
alreadyRead: true
}
];
```
- Create a complete webpage with a title, description and all other HTML tags
- In the body add an h1 title of "My Book List"
- In javascript, iterate through the array of books.
    - For each book, create HTML element with the book title and author and append it to the
page
    - Use a ul and li to display the books
    - Add a url property to each book object that contains the cover image of the book
    - Add the image to the HTML using Javascript
    - Using javascript change the style of the book depending on whether you have read it or not
- Add an external css file that applies after 5 seconds
    - Now change the style of the book depending on whether you have read it or not using both
css and javascript (the CSS should use a different color for read books)