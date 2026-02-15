/**
 * @file: main.js
 * @author: Samuele
 * prints to console two strings with their first two characters swapped
 */

/**
 * takes two strings and returns their concatenation with their first two characters swapped
 * @param {string} str1 string of at least 2 characters
 * @param {string} str2 string of at least 2 characters
 * @returns {string} ('abc' , 'def') => 'dec abf'
 */
function mixUp(str1, str2){
    return (
        str2.slice(0,2) + str1.slice(2) +
        " " +
        str1.slice(0,2) + str2.slice(2)
    );
}

console.log(mixUp("mix", "pod"));
console.log(mixUp("dog", "dinner"));