/**
 * @file: main.js
 * @author: Samuele
 * inverts a string and prints it to console
 */

/**
 * returns the string inverted
 * @param {string} string - string to invert
 * @returns {string} - inverted string 
 */
function Reverse(string){
    let reverse = "";
    for (let i = string.length - 1; i >= 0 ; i--){
        reverse += string.charAt(i);
    }
    return reverse;
}

console.log(printReverse("ciao"));
console.log(printReverse("foobar"));
