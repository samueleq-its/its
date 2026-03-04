/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * decipher a cipher by sorting the characters based on their rank, with even ranks before odd ones
 * then ordered by rank, and then concatenating the characters in the new order to form the deciphered string.
 */

const cipher = [
	{ char: "e", rank: 8 }, { char: " ", rank: 10 }, { char: "s", rank: 12 },
	{ char: "o", rank: 14 }, { char: "l", rank: 16 }, { char: "e", rank: 18 },
	{ char: " ", rank: 20 }, { char: "f", rank: 22 }, { char: "a", rank: 24 },
	{ char: "m", rank: 26 }, { char: "i", rank: 1 }, { char: "u", rank: 2 },
	{ char: "t", rank: 3 }, { char: "t", rank: 4 }, { char: "l", rank: 5 },
	{ char: "a", rank: 7 }, { char: "n", rank: 9 }, { char: "m", rank: 11 },
	{ char: "a", rank: 13 }, { char: "t", rank: 15 }, { char: "i", rank: 17 },
	{ char: "o", rank: 19 }, { char: "n", rank: 21 }, { char: "a", rank: 0 },
	{ char: "c", rank: 6 }, { char: "h", rank: 23 }, { char: "i", rank: 25 },
	{ char: "d", rank: 27 }, { char: "r", rank: 29 }
];

/**
 * decipher the an array of objects by sorting the characters based on their rank, with even ranks before odd ones
 * and then ordered by rank, and then concatenating the characters
 * in the new order to form the deciphered string.
 * @param {Object[]} cipher array of objects with char and rank properties
 * @returns {string} the deciphered string
 */
function decipher(cipher) {
	let ordered = cipher.toSorted(
		(previous, next) => {
			let order = previous.rank % 2 - next.rank % 2;
			/* if both are even or odd = 0
			 * if previous is even = 1
			 * if next is even = -1 */
			if (order != 0) {
				return order;
			}
			return previous.rank - next.rank;
		}
	);
	let deciphered = "";
	for (let item of ordered) {
		deciphered += item.char;
	}
	return deciphered;
}

console.log(decipher(cipher));