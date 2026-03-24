/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * decipher a cipher by sorting the characters based on their rank, with even ranks before odd ones
 * then ordered by rank, and then concatenating the characters in the new order to form the deciphered string.
 */

const cipher = [
	{ char: "t", rank: 6 }, { char: "f", rank: 7 }, { char: "t", rank: 19 },
	{ char: "c", rank: 2 }, { char: "n", rank: 25 }, { char: "h", rank: 14 },
	{ char: "a", rank: 17 }, { char: "a", rank: 0 }, { char: "e", rank: 24 },
	{ char: " ", rank: 1 }, { char: "i", rank: 3 }, { char: "s", rank: 12 },
	{ char: "o", rank: 23 }, { char: "e", rank: 8 }, { char: "u", rank: 18 },
	{ char: " ", rank: 10 }, { char: "l", rank: 20 }, { char: "l", rank: 9 },
	{ char: "r", rank: 26 }, { char: "a", rank: 11 }, { char: "m", rank: 15 },
	{ char: "n", rank: 5 }, { char: "d", rank: 22 }, { char: "i", rank: 21 },
	{ char: "m", rank: 13 }, { char: "u", rank: 4 }, { char: "o", rank: 16 }
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
	return ordered.map((x) => x.char).join("");
}

console.log(decipher(cipher));