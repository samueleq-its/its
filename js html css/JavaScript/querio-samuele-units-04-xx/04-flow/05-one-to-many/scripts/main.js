/**
 * @file: main.js
 * @author: Samuele
 * defines a function to return a string with the plural of a noun
 * 
 */

/**
 * returns a string with the number + the plural of the singolar noun
 * @param {string} singular a singolar noun
 * @param {number} number 
 * @returns {string} number + plural of the noun
 */
function oneToMany(singular, number) {
    let plural = "";
    if (number != 1) {
        switch (singular) {
            case "goose": //irregular
                plural = "geese";
                break;
            case "sheep": //plural equal to singular
                plural = singular;
                break;
            default:
                plural = singular + "s";
        }
    } else {
        plural = singular;
    }
    return number + " " + plural;
}

console.log(oneToMany("dog", 1));
console.log(oneToMany("dog", 3));
console.log(oneToMany("goose", 1));
console.log(oneToMany("goose", 5));
console.log(oneToMany("sheep", 2));