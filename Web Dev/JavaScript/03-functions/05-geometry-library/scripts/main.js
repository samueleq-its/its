/**
 * @file: main.js
 * @author: Samuele
 * exercise
 * calculate a circle area and circumference
 */

/**
 * calculares and prints to console a circle circumference
 * @param {number} radius the circle radius
 */
function calcCircumference(radius) {
    console.log(`the circumference is ${(2 * Math.PI * radius).toFixed(0)}`);
}

/**
 * calculares and prints to console a circle area
 * @param {number} radius the circle radius
 */
function calcArea(radius) {
    console.log(`the area is ${(Math.PI * radius ** 2).toFixed(0)}`);
}

calcCircumference(5);
calcArea(5);