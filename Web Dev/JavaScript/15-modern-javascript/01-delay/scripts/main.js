/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * Purpose of file
 *
 * Detailed explanation of what the file does
 * on multiple lines
 */


/**
 * creates a promise that resolves after a specified delay
 * useful for creating inline delays with `delay(amount).then(...)`
 * @param {number} amount time in ms to wait
 * @returns {Promise} a promise that resolves after the specified delay
 */
async function delay(amount) {
    return new Promise(
        (resolve, reject) => {
            setTimeout(
                () => {
                    resolve();
                }, amount
            );
        }
    );
}

function fn() {
    console.log("second");
}

delay(1000).then(() => { console.log("first") });
delay(2000).then(fn);