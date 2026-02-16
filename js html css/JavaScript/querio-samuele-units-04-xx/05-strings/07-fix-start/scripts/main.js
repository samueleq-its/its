/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * prints to console a string with every character equal to the first
 * (except the first itself) is replaced with '*'
 */

/**
 * returns string with every character equal to the first
 * (except the first itself) is replaced with '*'
 * @param {string} string string to alter
 * @returns {string} param. string with every character equal to the first
 * (except the first) is replaced with '*'
 */
function fixStart(string){
    let firstChar = string.charAt(0);
    return firstChar + string.slice(1).replaceAll(firstChar, '*');
}

console.log(fixStart("babble"));
console.log(fixStart("return"));
console.log(fixStart("supercalifragilisticexpialidocious"));