/**
 * @file: main.js
 * @author: Samuele
 * Prints to console the original string and the modified string with the 4th character replaced by 'X'
 */

// Solution 3 - use regex to replace the 4th character
const string = "Abracadabra";
// ^(.{3}). matches first 3 chars then the 4th char; replace with first group + 'X'
const replacedWithRegex = string.replace(/^(.{3})./, '$1X');
console.log('Solution 3 - regex:    ', string, '=', replacedWithRegex);

