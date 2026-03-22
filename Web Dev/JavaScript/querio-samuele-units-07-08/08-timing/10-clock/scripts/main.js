/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * prints to the console the current time every second in the format HH:MM:SS
 */

setInterval(
    function () {
        let time = new Date();
        console.log(
            `${time.getHours().toString().padStart(2, '0')}:` +
            `${time.getMinutes().toString().padStart(2, '0')}:` +
            `${time.getSeconds().toString().padStart(2, '0')}`
        );},
        1000
);