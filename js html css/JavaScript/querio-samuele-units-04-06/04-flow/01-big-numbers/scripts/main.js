/**
 * @file: main.js
 * @author: Samuele
 * logs to console the greater of two numbers
 */

/**
 * returns the greater of 2 numbers
 * @param {number} a first number to compare
 * @param {number} b second number to compare
 * @returns {number} bigger number between the two parameters
 */
let greaterNum = (a, b) => a > b ? a : b;

let a = 5;
let b = 10;
console.log(`The greater number of ${a} and ${b} is ${greaterNum(a, b)}`);
a = 21;
b = 9;
console.log(`The greater number of ${a} and ${b} is ${greaterNum(a, b)}`);