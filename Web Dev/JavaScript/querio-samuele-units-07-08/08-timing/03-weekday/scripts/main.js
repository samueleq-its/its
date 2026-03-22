/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * print date and weekday of today and of two other dates in english and italian
 */

/**
 * returns the weekday of the date passed as parameter in the language specified as parameter
 * invokes getWeekDayEN or getWeekDayIT depending on the value of the language parameter
 * @param {Date} date date for which to get the weekday
 * @param {string} language language code, either 'en' for english or 'it' for italian
 * @returns {string} weekday in the specified language
 */

function getWeekDay(date, language){
    return language === "en" ? getWeekDayEN(date) : getWeekDayIT(date);
}


/**
 * returns the weekday of the date passed as parameter in english
 * @param {Date} date date for which to get the weekday
 * @returns {string} weekday in english, either "MO", "TU", "WE", "TH", "FR", "SA" or "SU"
 */

function getWeekDayEN(date) {
    let day = "";
    switch (date.getDay()) {
        case 0:
            day = "SU";
            break;
        case 1:
            day = "MO";
            break;
        case 2:
            day = "TU";
            break;
        case 3:
            day = "WE";
            break;
        case 4:
            day = "TH";
            break;
        case 5:
            day = "FR";
            break;
        case 6:
            day = "SA";
            break;
        default:
            break;
    }
    return day;
}

/**
 * returns the weekday of the date passed as parameter in italian
 * @param {Date} date date for which to get the weekday
 * @returns {string} weekday in italian, either "LU", "MA", "ME", "GI", "VE", "SA" or "DO"
 */

function getWeekDayIT(date) {
    let day = "";
    switch (date.getDay()) {
        case 0:
            day = "DO";
            break;
        case 1:
            day = "LU";
            break;
        case 2:
            day = "MA";
            break;
        case 3:
            day = "ME";
            break;
        case 4:
            day = "GI";
            break;
        case 5:
            day = "VE";
            break;
        case 6:
            day = "SA";
            break;
        default:
            break;
    }
    return day;
}


let today = new Date();
console.log(today.getDay());
console.log(getWeekDay(today, "en"));
console.log(getWeekDay(today, "it"));
let date = new Date("2024-06-10");
console.log(date.getDay());
console.log(getWeekDay(date, "en"));
console.log(getWeekDay(date, "it"));
let date2 = new Date("2026-06-27");
console.log(date2.getDay());
console.log(getWeekDay(date2, "en"));
console.log(getWeekDay(date2, "it"));