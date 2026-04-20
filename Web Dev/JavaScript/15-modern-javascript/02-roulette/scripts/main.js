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

/**
 * 
 * @param {string} label label for the round (default "round")
 * @param {number} delay delay after which to resolve the promise (default 500)
 * @returns 
 */
async function round(label = "round", delay = 500) {
    return new Promise(
        (resolve, reject) => {
            setTimeout(
                () => {
                    Math.random() > 0.5 ? resolve(label + ":won!") : reject(label + ":lost!")
                },
                delay
            )
        }
    );
}
