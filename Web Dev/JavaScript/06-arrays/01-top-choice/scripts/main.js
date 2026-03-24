/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * prints to console the list of favourites
 */
let favourites = ["blue", "dogs", "le terre del Mondo Emerso", "swords"];
for (let i = 0; i < favourites.length; i++) {
	let suffix;
	switch (i%10) {
		case 1:
			suffix = "st";
			break;
		case 2:
			suffix = "nd";
			break;
		case 3:
			suffix = "rd";
			break;
		default:
			suffix = "th";
			break;
	}
	console.log(`My #${i} choice is ${favourites[i]}`);
}