/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * Purpose of file
 *
 * Detailed explanation of what the file does
 * on multiple lines
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

/**
 * displays the result in the solution div
 * @param {string} result - result to be displayed in the solution div
 */
function displayResult(result) {
    let solutionDiv = document.getElementById("solution");
    if (!solutionDiv) {
        console.log("div solution is missing");
        return;
    }
    solutionDiv.textContent = result;
}

// event handlers

/**
 * event handler for the square button
 * gets the input value, calculates the square and calls displayResult
 */
function squareEvent() {
    let squareInput = document.getElementById("square-input");
    if (!squareInput) {
        console.log("square-input is missing");
        return
    }
    if (!squareInput.value) {
        displayResult("insert a number");
        return
    }
    let result = squareNumber(squareInput.value);
    //display result
    displayResult(`Square of ${squareInput.value} is ${result}.`);
}

/**
 * event handler for the half button
 * gets the input value, calculates the half and calls displayResult
 */
function halfEvent() {
    let halfInput = document.getElementById("half-input");
    if (!halfInput) {
        console.log("half-input is missing");
        return
    }
    if (!halfInput.value) {
        displayResult("insert a number");
        return
    }
    let result = halfNumber(halfInput.value);
    //display result
    displayResult(`Half of ${halfInput.value} is ${result}.`);
}

/**
 * event handler for the percentage button
 * gets the input values, calculates the percentage and calls displayResult
 */
function percentageEvent() {
    let percentInput = document.getElementById("percentage-input");
    let percentOfInput = document.getElementById("percentage-of-input");
    if (!percentInput || !percentOfInput) {
        console.log("One or both percentage inputs are missing");
        return
    }
    if (!percentInput.value || !percentOfInput.value) {
        displayResult("insert both numbers");
        return
    }
    let result = percentOf(percentInput.value, percentOfInput.value);
    //display result
    displayResult(`${percentInput.value} is ${result}% of ${percentOfInput.value}.`);
}

/**
 * event handler for the circle button
 * gets the input value, calculates the area and calls displayResult
 */
function circleEvent() {
    let circleInput = document.getElementById("circle-input");
    if (!circleInput) {
        console.log("circle-input is missing");
        return
    }
    if (!circleInput.value) {
        displayResult("insert a number");
        return
    }
    let result = areaOfCircle(circleInput.value);
    //display result
    displayResult(`Area of circle of radius ${circleInput.value} is ${result}.`);
}

// listeners
// square
let squareButton = document.getElementById("square-button");
    if (squareButton) {
        squareButton.addEventListener("click", squareEvent);
    }

// half
let halfButton = document.getElementById("half-button");
if (halfButton) {
    halfButton.addEventListener("click", halfEvent);
}

// percentage
let percentageButton = document.getElementById("percentage-button");
if (percentageButton) {
    percentageButton.addEventListener("click", percentageEvent);
}

// area of circle
let circleButton = document.getElementById("circle-button");
if (circleButton) {
    circleButton.addEventListener("click", circleEvent);
}

// key listeners
document.addEventListener("keydown", function(event) {
    switch (event.key) {
        case "s":
            squareEvent();
            break;
        case "h":
            halfEvent();
            break;
        case "p":
            percentageEvent();
            break;
        case "c":
            circleEvent();
            break;
        default:
            break;
    }
});
