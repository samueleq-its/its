/**
 * @file: main.js
 * @author: Samuele
 * 
 * declares a function to sum or concatenate
 */

/**
 * if both parameters are number it sums them, if both are string it concatenates them
 * otherwise return null
 * @param {any} param1 - a number or a string
 * @param {any} param2 - a number or a string
 * @returns sum, concat or null
 */
function merger(param1, param2) {
    if (typeof param1 == typeof param2 && 
        (typeof param1 == "string" || typeof param1 == "number")){
        return param1 + param2;
    }
    return null;
}

console.log(merger(2,3));
console.log(merger("2","3"));
console.log(merger("ci","ao"));