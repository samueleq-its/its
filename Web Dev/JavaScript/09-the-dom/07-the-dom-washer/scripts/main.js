/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * simulation of a dishwasher using DOM manipulation
 * displays two stacks of dishes, one dirty and one clean
 * moves dishes from the dirty stack to the clean stack at random intervals
 */

const arraySize = Math.floor(Math.random() * 40) + 10;

let dirtyDishes = Array(arraySize).fill('dish');

let cleanDishes = Array();

/**
 * moves one dish from the dirty stack to the clean stack
 */
function washDish() {
    cleanDishes.push(dirtyDishes.pop())
}

/**
 * updates the DOM to display the current state of the dirty and clean stacks
 */
function displayStacks() {
    let newDirtyStack = Array();
    for (dish in dirtyDishes) {
        let dish = document.createElement("div");
        dish.className = "dirty-plate";
        newDirtyStack.push(dish);
    }
    dirtyContainer.replaceChildren(...newDirtyStack);
    let newCleanStack = Array();
    for (dish in cleanDishes) {
        let dish = document.createElement("div");
        dish.className = "clean-plate";
        newCleanStack.push(dish);
    }
    cleanContainer.replaceChildren(...newCleanStack);
}

/**
 * runs the dishwasher simulation until all dishes are clean
 */
function runSimulation() {
    //wash dish
    washDish();
    //display stacks
    displayStacks();
    //repeat after random time if there's still dishes
    if (dirtyDishes.length > 0) {
        setTimeout(
            runSimulation,
            1000 + Math.random() * 2000
        );
    }
}

let dirtyContainer = document.getElementById("dirty-container");
let cleanContainer = document.getElementById("clean-container");
runSimulation();