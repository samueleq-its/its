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

let lives = 6;
let word = "hangman";
let wordLetters = word.split("");
let guessed = word.replaceAll(/./g, "_").split("");

function guessLetter(letter) {
    lives--;
    for (let i = 0; i < word.length; i++) {
        if (word[i] == letter){
            // WIP
        }
    }

}