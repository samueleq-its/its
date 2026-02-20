/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * prints to console a string, the string gets appended 'ing' or 'ly' appended if it's longher than 2 
 */

/**
 * appends 'ing' to the end of the string or 'ly' if the string already ends with 'ing'
 * leaves the string unchanged if the string isn't at least 3 characters long
 * @param {string} string string to alter
 * @returns {string} string with appended 'ing', 'ly' or nothing
 */
function verbing(string) {
    if (string.length < 3) {
        return string;
    }
    return string + (string.endsWith("ing") ? "ly" : "ing");
}

console.log(verbing("swim"));
console.log(verbing("swimming"));
console.log(verbing("go"));