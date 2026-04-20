/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * defines a function to create a deep copy of an object and tests it with a sample object
 */

let object = {
    nullo: null,
    name: 'Green Mueller',
    email: 'Rigoberto_Muller47@yahoo.com',
    address: '575 Aiden Forks',
    bio: 'Tenetur voluptatem odit labore et voluptatem vel qui placeat sit.',
    active: false,
    salary: 37993,
    array: [1, 2, 3, "a", "b"],
    birth: new Date("1965-04-18T13:38:00+02:00"),
    bankInformation:
    {
        amount: '802.04',
        date: new Date("2012-02-02T00:00:00+01:00"),
        business: 'Bernhard, Kuhn and Stehr',
        name: 'Investment Account 8624',
        type: 'payment',
        account: '34889694'
    }
};

/**
 * creates a deep copy of an object, handling nested arrays, objects and Date objects
 * @param {Object} obj - the object to be cloned
 * @returns {Object} a deep copy of the input object
 */
function clone(obj) {
    let copy = Array.isArray(obj) ? [] : {};
    for (let key in obj) {
        //handles if object is a Date or another Object
        copy[key] = obj[key] instanceof Date ? new Date(obj[key].toISOString()) : obj[key] instanceof Object ? clone(obj[key]) : obj[key];
    }
    return copy;
}

let copy = clone(object);

console.log("original:\n", JSON.stringify(object));
console.log("copy:\n", JSON.stringify(copy));

object.birth = new Date();
object.array[2] = "ciao";
object.bankInformation.amount = "0";
object.bankInformation.date = new Date();
console.log("original modified");

console.log("original:\n", JSON.stringify(object));
console.log("copy:\n", JSON.stringify(copy));
