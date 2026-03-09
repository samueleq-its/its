/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * Purpose of file
 *
 * Detailed explanation of what the file does
 * on multiple lines
 */


document.body.style.fontFamily = "Arial, sans-serif";

document.getElementById("nickname").append("Samuele");
document.getElementById("favorites").append("Swords");
document.getElementById("hometown").append("Coazze");

let liElements = document.getElementsByTagName("li");

Array.from(liElements).forEach(li => li.className = "list-item");

let picture = document.createElement("img");
picture.src = "./assets/img/profile.jpg";
picture.style.height = "200px" // image is too big
document.body.append(picture);

// <link rel="stylesheet" href="style.css">
setInterval(
    () => {
        let style = document.createElement("link");
        style.rel = "stylesheet";
        style.href = "./styles/style.css";
        document.head.append(style);
    },
    4000
);
