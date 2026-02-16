/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * prints to console whether a name is part of a list of names
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

/**
 * prints to console whether a name is part of a list of names
 * @param {string} namesList list of names
 * @param {string} name name to check 
 */
function group(namesList, name) {
    //{name} {IS/is NOT} part of the group
    console.log(`${name} ${aContainsb(namesList, name)? "IS" : "is NOT"} part of the group`);
}

let namesList = "Mary, James, and John";
group(namesList, "James");
group(namesList, "Philip");