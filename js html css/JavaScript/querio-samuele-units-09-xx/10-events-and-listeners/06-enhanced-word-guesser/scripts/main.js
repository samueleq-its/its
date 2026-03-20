/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * simulates a game of hangman
 *
 * calling guessLetter() you can attempt to guess a letter until either all letters have been found or all lives are lost
 */

let lives = 6;
let score = 0;
let gameOver = false;
const BONUS = 5;
const MALUS = -3;

const targetWord = "hangman";
let targetLetters = targetWord.split("");
let guessedLetters = targetWord.replaceAll(/./g, "_").split("");

/**
 * checks if the character passed as argument is in the word to guess
 * if it is reveal the letter else reduce the number of lives
 * @param {string} letter letter to guess
 */
function guessLetter(letter) {
    if (gameOver) {
        console.log("can't play: GAME OVER");
        return;
    }
    let guessed = false;
    // loop over the letter of the word to find a match with the parameter
    for (let i = 0; i < targetLetters.length; i++) {
        //if the paramenter matches with a letter in the target word, add score, reveal the letter in guessedLetters, and set the flag guessed to true
        if (targetLetters[i] == letter){
            // prevent guessing the same letter multplie times
            if (guessedLetters[i] == letter) {
                console.log(`${letter} is already guessed`);
                return;
            }
            guessedLetters[i] = letter;
            score += BONUS;
            guessed = true;
        }
    }
    // if the letter wasn't found, reduce the score and lives
    if (!guessed) {
        lives--;
        score += MALUS;
    }
    // print report to console
    console.log(
        `LETTER: ${letter}\n` +
        `${guessed ? "‼CORRECT‼" : "‼WRONG‼"}\n` +
        `WORD: ${guessedLetters}\n` +
        `SCORE: ${score}\n` +
        `LIVES REMAINING: ${lives}\n`
    );
    if  (!guessedLetters.includes("_")) {
        gameOver = true;
        console.log("GAME OVER\nYOU'VE WON");
    } else if (lives <= 0) {
        gameOver = true;
        console.log("GAME OVER\nYOU'VE LOST");
    }
}

guessLetter("g");
guessLetter("a");
guessLetter("t");
guessLetter("o");
guessLetter("e");
guessLetter("h");
guessLetter("b");
guessLetter("z");
guessLetter("h");
guessLetter("m");
guessLetter("r");





/* TODO:
- pick a random word
- display hanged man lives
*/