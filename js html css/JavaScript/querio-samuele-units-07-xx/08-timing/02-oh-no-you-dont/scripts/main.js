/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * schedule a function to be executed after a certain amount of time, and then cancels it by scheduling
 * another function to be executed before the first one
 */

/**
 * usefull function 
 */
function useful(){
    console.log("very useful");
}

/**
 * stops the execution of the scheduled function 
 */
function stopTimeout(timeoutId){
    clearTimeout(timeoutId);
    console.log("function cancelled");
}

let waitTime = 10000;
let stopTime = 5000;
// schedule the useful function to be executed after waitTime milliseconds
let usefulId = setTimeout(useful, waitTime);
// schedule the stopTimeout function to be executed after stopTime milliseconds, passing the usefulId as an argument
setTimeout(stopTimeout, stopTime, usefulId);