/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * Prints to console the original string and the modified string with the 4th character replaced by 'X'
 */

/**
 * Replaces the character at a given zero-based index in a string with 'X'.
 * @param {string} original The input string.
 * @param {number} index The zero-based index of the character to replace.
 * @returns {string} A new string with the character at `index` replaced by 'X'.
 */
// Solution 1 - use slice
let string = "Abracadabra";
let i = 3; // 4th character (zero-based index)
let replaced = string.slice(0, i) + 'X' + string.slice(i + 1);
console.log('Solution 1 - slice:    ', string, '=', replaced);

