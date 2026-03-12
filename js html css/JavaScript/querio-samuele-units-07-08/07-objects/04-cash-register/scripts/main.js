/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * defines an array shoppingCart as objects and prints the total price to console
 */

/**
 * returns the total price of the shopping cart
 * @param {Object} shoppingCart the shopping cart object
 * @returns {number} the total price of all items in the cart
 */
function cashRegister(shoppingCart) {
    let total = 0;
    let items = Object.keys(shoppingCart);
    for (let i = 0; i < items.length; i++) {
        total += parseFloat(shoppingCart[items[i]]);
    }
    return total;
}

let cartForParty = {
banana: "1.25",
handkerchief: ".99",
Tshirt: "25.01",
apple: "0.60",
nalgene: "10.34",
proteinShake: "22.36"
};

console.log(cashRegister(cartForParty));