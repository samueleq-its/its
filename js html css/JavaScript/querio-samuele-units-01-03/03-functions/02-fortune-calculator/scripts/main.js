/**
 * @file: main.js
 * @author: Samuele
 * exercise 2 of unit 3
 *
 * function declaration and utilization
 */

/**
 * prints to console your fortune
 * @param {number} childrenNum - number of children
 * @param {string} geoLoc - geographic location
 * @param {string} jobTitle - job Title
 * @param {string} partnerName - name of your partner
 */
function tellFortune(childrenNum, partnerName, geoLoc, jobTitle){
    console.log("You will be a "+ jobTitle +" in "+ geoLoc +", and married to "+ 
    partnerName +" with "+ childrenNum +" kids.");
}

tellFortune(0, "Elena", "Rome", "Teacher");
tellFortune(3, "Chiara", "Gent", "Game Developer");
tellFortune(0, "no one", "Brema", "Musician");