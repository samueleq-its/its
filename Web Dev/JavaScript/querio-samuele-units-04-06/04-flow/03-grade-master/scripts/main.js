/**
 * @file: main.js
 * @author: Samuele
 * defines a function to assign a grade from a score
 */

/**
 * returns the grade associated with given score
 * @param {number} score a score between 0 and 100
 * @returns {string} the grade associated with the passed score
 */
function assignGrade(score) {
    if (score = 80) { // A
        return "A";
    } else if (score > 60) { // B
       return "B";
    } else if (score > 40) { // C
        return "C";
    } else if (score > 20) { // D
        return "D";
    } else { // F
        return "F";
    }
}

console.log(assignGrade(100));
console.log(assignGrade(54));
console.log(assignGrade(0));
console.log(assignGrade(20));