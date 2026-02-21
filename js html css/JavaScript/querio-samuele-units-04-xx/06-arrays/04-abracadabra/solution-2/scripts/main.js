/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * Prints to console the original string and the modified string with the 4th character replaced by 'X'
 */

// Solution 2 - convert to array, modify, then join
let string = "Abracadabra";
let charArray = string.split('');
charArray[3] = 'X'; // replace 4th char
let replaced = charArray.join('');
console.log('Solution 2 - array:    ', string, '=', replaced);

