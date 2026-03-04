/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * prints to console the day of the month for a date that is 'n' days ago from the current date
 * (or in the future if 'n' is negative)
 */

/**
 * returns the day of the month 'n' days ago from the given date
 * @param {Date} date the date from which to calculate the past date
 * @param {number} days how many days ago (negative for future dates)
 * @return {number} the day of the month for the calculated date
 */
function getDateAgo(date, days) {
    const DAY_TO_MS = 86400000; 
    return new Date(date.getTime() - days * DAY_TO_MS).getDate();
}

console.log(getDateAgo(new Date(), 0));
console.log(getDateAgo(new Date(), 1));
console.log(getDateAgo(new Date(), 2));
console.log(getDateAgo(new Date(), 30));
console.log(getDateAgo(new Date(), -1));
console.log(getDateAgo(new Date(), -45));
