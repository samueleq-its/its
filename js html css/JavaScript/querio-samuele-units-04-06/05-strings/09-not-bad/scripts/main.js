/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * prints to console a string with 'not' + ... + 'bad' replaced with 'good' if present
 */

/**
 * replaces 'not' + ... + 'bad' with 'good' if present
 * @param {string} string string to alter
 * @returns {type} string with 'not' + ... + 'bad' replaced with 'good'
 */
function notBad(string) {
    let notIndex = string.indexOf("not");
    let badIndex = string.indexOf("bad");
    // check if 'bad' comes after 'not' (and 'not' must be present)
    if (notIndex != -1 && badIndex > notIndex) {
        return (string.slice(0,notIndex) + "good" + string.slice(badIndex + 3));
    }
    return string;
}

console.log(notBad('This dinner is not that bad!'));
console.log(notBad('This movie is not so good!'));
console.log(notBad('This dinner is bad!'));
console.log(notBad('not bad'));