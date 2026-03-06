/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * Purpose of file
 *
 * Detailed explanation of what the file does
 * on multiple lines
 */

/**
 * function description
 * @param {type} paramName description
 * @returns {type} description
 */
setInterval(
    function () {
        let time = new Date();
        console.log(`${time.getHours().toString().padStart(2, '0')}:`
            `${time.getMinutes().toString().padStart(2, '0')}:` +
            `${time.getSeconds().toString().padStart(2, '0')}`
        );},
        
);