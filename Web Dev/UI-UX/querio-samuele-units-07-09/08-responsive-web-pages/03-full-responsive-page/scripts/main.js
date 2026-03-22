/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * Purpose of file
 *
 * Detailed explanation of what the file does
 * on multiple lines
 */

/**
 * adds and removes the "menu-open" class to the nav element when the menu button is clicked, which shows or hides the menu
 */
function displayMenu() {
    let menu = document.querySelector("#top-menu");
    if (menu.className.includes("menu-open")) {
    menu.className = menu.className.replace("menu-open", "");
    } else {
    menu.className += " menu-open";
    }
}