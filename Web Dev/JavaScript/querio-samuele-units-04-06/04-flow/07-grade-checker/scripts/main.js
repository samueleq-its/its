/**
 * @file: main.js
 * @author: Samuele
 * logs to console every grade for a score from 60 to 100
 */

/**
 * returns the grade associated with given score
 * @param {number} score a score between 0 and 100
 * @returns {string} the grade associated with the passed score
 */
function assignGrade(score) {
    if (score > 80) {       // A
        return "A";
    } else if (score > 60) { // B
       return "B";
    } else if (score > 40) { // C
        return "C";
    } else if (score > 20) { // D
        return "D";
    } else {                // F
        return "F";
    }
}

for(let score = 60; score <= 100; score++) {
    console.log(`For ${score}, you got a ${assignGrade(score)}`);
}

