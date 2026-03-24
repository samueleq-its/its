/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * Toggles the responsive menu visibility on small screens.
 */

/**
 * Adds or removes the menu-open class on the nav element.
 */
function displayMenu() {
    const menu = document.querySelector("nav");

    if (menu.className.includes("menu-open")) {
        menu.className = menu.className.replace("menu-open", "").trim();
    } else {
        menu.className = (menu.className + " menu-open").trim();
    }
}
