/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * Custom implementation of setInterval, writes the number of iterations in the console every second,
 * for a total of 15 times.
 */

/**
 * Custom implementation of setInterval, it will fire the function **fn** every **repeatTime** milliseconds, 
 * for **repetitions** times (indefinitely if null).
 * @param {Function} fn function to be executed every iteration
 * @param {number} repeatTime time in milliseconds between each execution
 * @param {null} [repetitions=null] how many times to repeat the execution, if null repeats indefinetly
 * @param  {...any} args arguments to be passed to fn
 */
function mySetInterval(fn, repeatTime = 1000, repetitions = null, ...args) {
    if (repetitions == null || repetitions > 0) {
        fn(...args);
        setTimeout(
            mySetInterval,
            repeatTime,
            fn, repeatTime, (repetitions == null ? null : repetitions - 1), ...args
        );
    }
}

let i = 0;
mySetInterval(
    () => { console.log(i); i++; }, 1000, 15
)


