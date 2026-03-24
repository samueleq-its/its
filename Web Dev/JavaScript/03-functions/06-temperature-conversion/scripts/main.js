/**
 * @file: main.js
 * @author: Samuele
 * 
 * declares two functions to convert temperetature from celsius to fahrenheit 
 * and from fahrenheit to celsius
 */

// C => F : C * (9/5) +32
// F => C : (F - 32) * (5/9)

/**
 * converts a celsius temperature into fahrenheit
 * @param {number} tempC - temperature in celsius
 */
function celsiusToFahrenheit(tempC){
    let tempF = (tempC * (9 / 5) + 32).toFixed(0);
    console.log(`${tempC}°C is ${tempF}°F`);
}

/**
 * converts a fahrenheit temperature into celsius
 * @param {number} tempf - temperature in fahrenheit
 */
function fahrenheitToCelsius(tempF){
    let tempC = ((tempF - 32) * (5/9)).toFixed(1);
    console.log(`${tempF}°F is ${tempC}°C`);
}

celsiusToFahrenheit(0);
celsiusToFahrenheit(100);
celsiusToFahrenheit(37);

fahrenheitToCelsius(0);
fahrenheitToCelsius(100);
fahrenheitToCelsius(-40);
