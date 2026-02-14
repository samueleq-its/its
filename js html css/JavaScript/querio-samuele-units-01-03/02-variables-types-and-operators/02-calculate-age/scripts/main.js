/**
 * @file: main.js
 * @author: Samuele
 * calculates your age in a given year and prints it to console
 */

let dateOfBirth = 1996;
let futureYear = 2030;

let futureAge = futureYear - dateOfBirth;
let output = "I will be either "+ futureAge +" or "+ (futureAge + 1) +" in "+ futureYear;

console.log(output);