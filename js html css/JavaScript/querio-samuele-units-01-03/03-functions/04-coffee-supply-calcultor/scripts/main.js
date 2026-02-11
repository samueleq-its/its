/**
 * @file: main.js
 * @author: Samuele
 * exercise over functions
 * calculates the amount of coffee consumed over a person lifespan
 */

/**
 * calculates the amount consumed for rest of the life (based on a constant max age)
 * @param {number} currentAge - current age
 * @param {number} amountPerDay - the amount of coffee taken each day
 * @returns {type} description
 */
function calculateSupply(currentAge, amountPerDay){
    let maxAge = 80;
    let coffeeSupply = amountPerDay * 365 * (maxAge - currentAge);
    console.log(`You will need ${coffeeSupply} cups of coffee to last you until the age of ${maxAge}`);
}

calculateSupply(30, 1);
calculateSupply(18, 2);
calculateSupply(40, 3);