/**
 * @file: main.js
 * @author: Samuele
 * function exercise
 */

/**
 * converts the dog age in "human years" in the corresponding age in dog years
 * @param {number} humanYears - the age of the dog in normal years
 */
function calculateDogAge(humanYears) {
    dogYears = humanYears * 7;
    console.log("Your dog is " + dogYears + " years old in dog years!");
}

calculateDogAge(9);
calculateDogAge(5);
calculateDogAge(13);
