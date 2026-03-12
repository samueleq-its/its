/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * Purpose of file
 *
 * Detailed explanation of what the file does
 * on multiple lines
 */

/**
 * function description
 * @param {type} paramName description
 * @returns {type} description
 */

const arraySize = Math.floor(Math.random() * 40) + 10;

let dirtyDishes = Array(arraySize).fill('dish');

let cleanDishes = Array();





function washDish() {
    cleanDishes.push(dirtyDishes.pop())
}

function displayStacks() {
    console.log("dirty dishes stack:", dirtyDishes);
    console.log("clean dishes stack:", cleanDishes);
}

function runSimulation() {
    //wash dish
    washDish();
    //display stacks
    displayStacks();
    //repeat afte random time if there's still dishes
    if (dirtyDishes.length > 0) {
        setTimeout(
            runSimulation,
            1000 + Math.random() * 2000
        );
    }
}

runSimulation();