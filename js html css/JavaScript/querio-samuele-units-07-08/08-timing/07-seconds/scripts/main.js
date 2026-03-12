/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * prints to console the seconds passed today and the seconds until tomorrow
 */


/**
 * @returns {number} seconds passed today 
 */
function getSecondsToday() {
    let date = new Date();
    return date.getHours() * 3600 + date.getMinutes() * 60 + date.getSeconds();
}

/**
 * @returns {number} seconds until tomorrow
 */
function getSecondsToTomorrow() {
    return 86400 - getSecondsToday();
}

console.log("Seconds passed today:", getSecondsToday());
console.log("Seconds until tomorrow:", getSecondsToTomorrow());