/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * creates a responsive menu that changes to a button when the screen is too narrow, and shows the menu when the button is clicked
 */

/**
 * adds and removes the "menu-open" class to the nav element when the menu button is clicked, which shows or hides the menu
 */
function displayMenu() {
    let menu = document.querySelector("nav");
    if (menu.className.includes("menu-open")) {
    menu.className = menu.className.replace("menu-open", "");
    } else {
    menu.className += " menu-open";
    }
}

