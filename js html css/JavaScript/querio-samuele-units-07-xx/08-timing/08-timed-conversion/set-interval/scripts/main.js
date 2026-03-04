/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * prints to console the conversion of temperatures from 0 to 100 °C into °F, one per second
 * using setInterval
 */

// C => F : C * (9/5) +32
// F => C : (F - 32) * (5/9)

/**
 * converts a celsius temperature into fahrenheit
 * @param {number} tempC - temperature in celsius
 */
function celsiusToFahrenheit(tempC) {
    let tempF = (tempC * (9 / 5) + 32).toFixed(0);
    console.log(`${tempC}°C is ${tempF}°F`);
}

/**
 * converts a fahrenheit temperature into celsius
 * @param {number} tempf - temperature in fahrenheit
 */
function fahrenheitToCelsius(tempF) {
    let tempC = ((tempF - 32) * (5 / 9)).toFixed(1);
    console.log(`${tempF}°F is ${tempC}°C`);
}

// setInterval
const STEP = 1000;
let t = 0;
let intervalId = setInterval(
    () => {
        celsiusToFahrenheit(t);
        t++;
        if (t > 100) {
            clearInterval(intervalId);
        }
    },
    STEP
);