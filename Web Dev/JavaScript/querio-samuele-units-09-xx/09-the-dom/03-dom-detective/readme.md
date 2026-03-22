# 3.DOM Detective
## Author
samuele.querio@edu-its.it

## Requirements
- Go to www.gog.com
- Use the devtools to view the DOM and write Javascript in the console
- Use the DOM access methods to find the following:
    - Every image on the page
    - The main menu at the top of the page
    - All the news items under "News"
    - The footer
    - All the social media links at the bottom of the page
- Produce a readme.md file with
    - snippets of your Javascript code
    - explanations of which elements they select

## Approach to solution

``` javascript
//Find every image on the page
let imglist = document.getElementsByTagName("img"); // returns a collection of HTML elements of type img
for (let img of imglist) { // prints to console the value of every src and srcset attribute
	if (img.src != "") {
	    console.log(img.src);
	}
	if (img.srcset != "") {
	    console.log(img.srcset);
	}
}

//Find the main menu at the top of the page
document.getElementsByTagName("nav"); 
//returns a collection of HTML elements of type nav with the only element in the collection is the bar at the top of the page

//Find all the news items under "News"
document.getElementsByTagName("news-tile"); //returns a collection of every tile in the News sections

let titles = document.querySelectorAll("news-tile b"); //prints to console the title of every game in the news section
for (let title of titles) {
    console.log(title.innerText);
}

//Find the footer
document.getElementsByTagName("footer");
//returns a collection of HTML elements of type footer with the only element bein the footer at the bottom of the page

//Find all the social media links at the bottom of the page
let links = document.querySelectorAll(".footer-microservice-socials a");
for (let link of links) { //prints to console the URL of every social media link in the footer
  console.log(link.href);
}

```


