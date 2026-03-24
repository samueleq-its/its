/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * defines a function to check if a string contains another
 */

/**
 * checks if a string contains another
 * @param {string} strA a string
 * @param {string} strB string to check if contained by strA
 * @returns {boolean} true if strA contains strB, otherwise false
 */
function aContainsb(strA, strB) {
    return strA.indexOf(strB) != -1 ;
}

console.log(aContainsb("Another hello world", "hell"));
console.log(aContainsb("Another hello world", "banana"));
console.log(aContainsb("Another", "not"));