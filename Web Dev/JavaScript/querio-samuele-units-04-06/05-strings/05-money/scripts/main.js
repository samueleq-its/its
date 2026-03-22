/**
 * @file: main.js
 * @author: Samuele
 * prints to console a value in dollars with its conversion in euros
 */

/**
 * convert an amount of dollars in euros and prints it to console
 * handles singular and plural
 * easter egg at 1000000
 * 
 * @param {number} amount - value to print and convert
 * @returns {string} '<$> dollars are <€> euros'
 */
function money(amount){
    const easterEgg = 1000000; // value at which ';)' is printed
    let conversionRate = 0.84; // dollar to euro
    let amountEuro = (amount*conversionRate).toFixed(2);

    let output = `${amount} dollar${amount != 1 ? "s are" : " is"}`;
    output += ` ${amountEuro} euro${amountEuro != 1 ? "s" : ""}`;
    output += `${amount == easterEgg ? " ;)" : ""}`;
    return output; 
}

console.log(money(0.5));
console.log(money(1));
console.log(money(1000000));
console.log(money(1.19)); 