/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * performs various calculations on a given number, waits 3 seconds between each operation
 * prints the results to console
 */


/**
 * squares a number
 * @param {number} n - number to square
 * @returns {number} square of n
 */
function squareNumber(n) {
    let squared = (n ** 2).toFixed(2);
    console.log(`The result of squaring the number ${n} is ${squared}.`);
    return squared;
}
/**
 * halves a number
 * @param {number} n - number to be halved
 * @returns {number} half of n
 */
function halfNumber(n) {
    let halved = n / 2;
    console.log(`Half of ${n} is ${halved}.`);
    return halved;
}

/**
 * calculates what percentage of num2 is num1
 * @param {number} num1 - dividend of the percentage
 * @param {number} num2 - divisor of the percentage
 * @returns {number} percentage of num1 over num2
 */
function percentOf(num1, num2) {
    let result = (num1 / num2 * 100).toFixed(2);
    console.log(`${num1} is ${result}% of ${num2}.`);
    return result;
}

/**
 * calculates the area of a circle
 * @param {number} radius - radius of a circle
 * @returns {number} area of a circle of given radius
 */
function areaOfCircle(radius) {
    let result = (Math.PI * radius ** 2).toFixed(2);
    console.log(`The area for a circle with radius ${radius} is ${result}.`);
    return result;
}

const timing = 3000;

// set of functions to have a delay of 3 second between the operations
function halfNumDelay(n) {
    let half = halfNumber(n);
    setTimeout(sqrNumDelay, timing, half);
}
function sqrNumDelay(n) {
    let squared = squareNumber(n);
    setTimeout(areaCircleDelay, timing, squared);
}
function areaCircleDelay(n) {
    let area = areaOfCircle(n);
    setTimeout(percentOf, timing, area, n);
}

/**
 * performs various calcultions on a given number, waits 3 seconds between each operation
 * prints the results to console
 * @param {number} num 
 */
function calculator(num) {
    halfNumDelay(num);
}

calculator(1);

