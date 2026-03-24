/**
 * @file: main.js
 * @author: Samuele
 * 
 * convert one temperetature from celsius to fahrenheit 
 * and another from fahrenheit to celsius
 */

// C => F : C * (9/5) +32
// F => C : (F - 32) * (5/9)

let tempC1 = 37.5;
let tempF1 = (tempC1 * (9 / 5) + 32).toFixed(0);
console.log(tempC1 + "°C is " + tempF1 + "°F");

let tempF2 = 98;
let tempC2 = ((tempF2 - 32) * (5/9)).toFixed(1);
console.log(tempF2 + "°F is " + tempC2 + "°C");
