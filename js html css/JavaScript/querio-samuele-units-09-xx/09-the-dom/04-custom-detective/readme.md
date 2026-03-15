# 4.Custom Detective
## Author
samuele.querio@edu-its.it

## Requirements
- Choose a news website that you like
- Use the devtools to view the DOM and write Javascript in the console
- Use the DOM access methods to find:
    - At least 10 different elements or collections of elements in the page
    - Choose interesting elements that require complex selectors to reach
- Produce a readme.md file with
    - A link to the website that you chose
    - snippets of your Javascript code
    - explanations of what which elements they select

## Approach to solution

chosen website: [aljazeera.com](https://www.aljazeera.com/)  

```javascript
// a collection of the titles of the latest videos on the homepage, which are in a carousel
document.querySelectorAll("#swiper-wrapper-1f1559bee147e5bf a h3");

// the first anchor element of each column in the footer 
document.querySelectorAll("footer .footer-menu li ul li:first-child a");

// the main navigation links inside the website header
document.querySelectorAll("header nav a");

// social media links in the footer utility area
document.querySelectorAll("footer a[href*='twitter'], footer a[href*='facebook'], footer a[href*='instagram'], footer a[href*='youtube']");

// all footer links that point to policy and legal pages
document.querySelectorAll("footer a[href*='privacy'], footer a[href*='terms'], footer a[href*='cookie']");

// a collection of all the small used as list markers for the live updates
document.querySelectorAll("ul.liveblog-timeline svg.icon circle:nth-child(2)");

// all the article links in the main area that point to /news/ pages
document.querySelectorAll("main article a[href*='/news/']");

// all images that are inside article cards in the central content feed
document.querySelectorAll("main article picture img, main article img");

// the aljazeera logo in the footer
document.querySelector(".site-footer img");

// every link to a /news/ page not related to Trump
document.querySelectorAll("a:not([href*='trump'])[href*='/news/']");

```