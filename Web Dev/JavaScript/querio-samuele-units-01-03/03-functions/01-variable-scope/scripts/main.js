/**
 * @file: main.js
 * @author: Samuele
 * exercise 1 of unit 3
 *
 * testing local and global variables
 */

/**
 * Sums 2 numbers and prints the result
 * @param {number} num1 - fist number
 * @param {number} num2 - second number
 */
function addNumbers(num1, num2) {
    let localResult = num1 + num2;
    console.log("The local result is: " + localResult)
}

addNumbers(5,7); // prints "The local result is: 12"
let localResult //added to prevent ReferenceError
console.log(localResult) // localResult doesn't exist here

let globalResult;

/**
 * Sums 2 numbers and prints the result, the result is also saved in global variable "globalResult"
 * @param {number} num1 - fist number
 * @param {number} num2 - second number
 */
function addNumbersGlobal(num1, num2) {
    globalResult = num1 + num2;
    console.log("The global result is: " + globalResult)
}

addNumbersGlobal(5,7) // prints "The global result is: 12"
console.log(globalResult); // prints "12"