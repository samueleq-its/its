/**
 * @file: main.js
 * @author: Samuele
 * prints if a string is palindrome
 */

/**
 * returns the string inverted
 * @param {string} string - string to invert
 * @returns {string} - inverted string 
 */
function reverse(string){
    let reverse = "";
    for (let i = string.length - 1; i >= 0 ; i--){
        reverse += string.charAt(i);
    }
    return reverse;
}

/**
 * checks if a string is palindrome
 * @param {string} string - string to ckeck
 * @returns {boolean} - true if palindrome, false otherwise
 */
function isPalindrome(string) {
    inverse = reverse(string);
    return string == inverse;
}

console.log(isPalindrome("madam"));
console.log(isPalindrome("madame"));