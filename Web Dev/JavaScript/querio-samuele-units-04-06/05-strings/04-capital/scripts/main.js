/**
 * @file: main.js
 * @author: Samuele
 * prints a string with the first letter capitalized
 */

/**
 * return a string with the first letter capitalized
 * @param {string} str - string to capitalize
 * @returns {type} string capitalized
 */
capital = str => str.charAt(0).toUpperCase() + str.slice(1);

console.log(capital("hello world"));
console.log(capital("jello World"));