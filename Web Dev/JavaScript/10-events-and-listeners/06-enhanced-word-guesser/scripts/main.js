/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * Game of Hangman
 *
 * displays a game of hangman, picking from a list of words
 * allowing the user to guess letters until they win or lose
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
	"waterfall",
	"programming",
	"constellation",
	"playground",
	"butterfly",
	"honeycomb",
	"encyclopedia",
	"skateboard",
	"friendship",
	"imagination",
	"photography"
];
let targetLetters; // array of the letters of the word to guess
// array of the letters discovered by the user, initialized with "_" and updated with the correct guesses
let discoveredLetters;
// array of the letters guessed by the user, used to prevent repeated guesses and for display purposes
let guessedLetters = [];

/**
 * Sets up a new game by selecting a random word and initializing the game state.
 */
function setUpGame() {
	let i = Math.ceil(Math.random() * wordsList.length);
	let targetWord = wordsList[i];
	targetLetters = targetWord.split("");
	discoveredLetters = targetWord.replaceAll(/./g, "_").split("");
}

/**
 * Checks if the guessed letter is in the target word, updates the game state accordingly
 * returns a message indicating the result of the guess.
 * @param {string} letter letter guessed by the user
 * @returns {string} a string indicating the result of the guess 
 * ("Correct!", "Wrong!", "You've Won!", "You've Lost!")
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
 * updates the details section of the page with the current game state
 * (discovered letters, guessed letters, and score)
 */
function displayDetails() {

	detailsDiv.innerHTML = "";
	[
		`Word: ${discoveredLetters.join(" ")}`,
		`Guessed Letters: ${guessedLetters}`,
		`Remaining Lives: ${lives}`,
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
 * Progresses the game state based on the user's input letter
 * @param {string} inputLetter letter guessed by the user, taken from the input field
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

// add event listener to the button, to trigger the game progression when clicked
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
	- event when a letter is typed in the input field
- display full word on game loss
- restart button
*/