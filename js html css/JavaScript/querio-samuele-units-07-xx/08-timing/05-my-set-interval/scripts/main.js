/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * Custom implementation of setInterval, writes the number of iterations in the console every second,
 * for a total of 15 times.
 */

/**
 * Custom implementation of setInterval, it will fire the function fn every repeatTime milliseconds, 
 * for a total of 15 times.
 * @param {Function} fn function to be executed every iteration
 * @param {number} repeatTime time in milliseconds between each execution
 * @param  {...any} args arguments to be passed to fn
 */
function mySetInterval(fn, repeatTime=1000, ...args) {
    /**
     * Recursive function that will execute fn and then call itself after repeatTime milliseconds, until repetitions reaches 0
     * @param {Function} fn 
     * @param {number} repeatTime 
     * @param {number} repetitions 
     * @param  {...any} args 
     */
    function repeater(fn, repeatTime, repetitions = 15, ...args) {
        fn(...args);
        if (repetitions > 0){
            setTimeout(
                repeater,
                repeatTime,
                fn, repeatTime, repetitions-1, ...args
            );
        }
    }

    setTimeout(
        repeater(fn, repeatTime, ...args)
    );
}


let i = 0;
mySetInterval(
    (n) => {console.log(i);i++;},1000
)


