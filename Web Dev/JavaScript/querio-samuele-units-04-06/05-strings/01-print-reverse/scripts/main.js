/**
 * @file: main.js
 * @author: Samuele
 * inverts a string and prints it to console
 */

/**
 * inverts the string passed as parameter and prints it to console
 * @param {string} string - string to invert
 */
function printReverse(string){
    let reverse = "";
    for (let i = string.length - 1; i >= 0 ; i--){
        reverse += string.charAt(i);
    }
    console.log(reverse);
}

printReverse("ciao");
printReverse("foobar");
