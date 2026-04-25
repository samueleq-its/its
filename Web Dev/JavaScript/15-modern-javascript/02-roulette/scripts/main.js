/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * @description: Example of a simple roulette game using promises, where each round has a 50% chance
 * of winning or losing. if all rounds are won, the results are printed,
 * otherwise the error is caught and printed. The rounds are executed in parallel using Promise.all.
 */

/**
 * Returns a promise that resolves or rejects after a delay,
 * simulating a round of a roulette game with a 50/50 chance of winning or losing.
 * @param {string} label label for the round (default "round")
 * @param {number} delay delay after which to resolve the promise (default 500)
 * @returns {Promise} a promise that resolves with a win message or rejects with a lose message
 */
async function round(label = "round", delay = 500) {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            Math.random() > 0.5 ? resolve(label + ":won!") : reject(label + ":lost!");
        },
            delay
        );
    }
    );

}

// Execute 3 rounds of the roulette game in parallel
let promises = [];
for (let i = 0; i < 3; i++) {
    promises.push(round("round " + i));
}

// Wait for all rounds to complete and print the results, or catch any errors if a round is lost
Promise.all(promises)
    .then(results => { results.forEach(x => console.log(x)); })
    .catch(error => console.log(error));