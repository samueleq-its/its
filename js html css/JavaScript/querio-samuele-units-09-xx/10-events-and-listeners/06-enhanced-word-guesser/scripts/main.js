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
const outputDiv = document.getElementById("output");
const detailsDiv = document.getElementById("details");

let wordsList = [
	"planet",
	"library",
	"javascript",
	"computer",
	"mountain",
	"adventure",
	"elephant",
	"notebook",
	"triangle",
	"waterfall"
];
let targetLetters;
let discoveredLetters;
let guessedLetters = [];

function setUpGame() {
	let i = Math.ceil(Math.random() * wordsList.length);
	let targetWord = wordsList[i];
	targetLetters = targetWord.split("");
	discoveredLetters = targetWord.replaceAll(/./g, "_").split("");
}

/**
 * 
 * @param {string} letter 
 * @returns 
 */
function guessLetter(letter) {
	let guessed = false;
	// loop over the letter of the word to find a match with the parameter
	for (let i = 0; i < targetLetters.length; i++) {
		//if the paramenter matches with a letter in the target word, add score, reveal the letter in guessedLetters, and set the flag guessed to true
		if (targetLetters[i] == letter) {
			discoveredLetters[i] = letter;
			score += BONUS;
			guessed = true;
		}
	}
	// if the letter wasn't found, reduce the score and lives
	if (!guessed) {
		lives--;
		score += MALUS;
	}

	if (!discoveredLetters.includes("_")) { // win
		gameOver = true;
		return "You've Won!";

	} else if (lives <= 0) { // loss
		gameOver = true;
		return "You've Lost!";
	}
	return guessed ? "Correct!" : "Wrong!";
}

/**
 * 
 */
function displayDetails() {

	detailsDiv.innerHTML = "";
	[
		`Discovered Letters: ${discoveredLetters}`,
		`Guessed Letters: ${guessedLetters}`,
		`Score: ${score}`
	].forEach(
		line => {
			let p = document.createElement("p");
			p.append(line);
			detailsDiv.append(p);
		}
	);
}

/**
 * 
 * @param {string} inputLetter 
 * @returns 
 */
function wordGuesser(inputLetter) {
	if (gameOver) {
		outputDiv.textContent = "GAME OVER";
		return;
	}
	//input validation
	if (inputLetter.length != 1) { // wrong input
		outputDiv.textContent = "Please insert a single character";
		return;
	}
	if (guessedLetters.includes(inputLetter)) { // already guessed
		outputDiv.textContent = `'${inputLetter}' was already guessed`;
		return;
	}
	guessedLetters.push(inputLetter); // update guessed letters

	outputDiv.textContent = guessLetter(inputLetter); //progress game and display result

	// update detail text
	displayDetails();

}

setUpGame();
displayDetails();

document.getElementById("guess-btn").addEventListener("click",
	event => {
		let letterInput = document.getElementById("letter-input");
		wordGuesser(letterInput.value);
		letterInput.value = "";
	}
);

/* TODO:
- prevent input of numbers
- 'enter' without selecting button
- display full word on game loss
*/