/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * Purpose of file
 *
 * Detailed explanation of what the file does
 * on multiple lines
 */

/**
 * custom implementation of forEach using reduce
 * @param {Array} array array to iterate over
 * @param {Function} fn function to execute for each element in the array
 */
function redForEach(array, fn) {
	array.reduce((_, cur) => fn(cur), null);
}

/**
 * custom implementation of map using reduce
 * @param {Array} array array to iterate over
 * @param {Function} fn function to execute for each element in the array
 */
function redMap(array, fn) {
	return array.reduce(
		(acc, curr) => {
			acc.push(fn(curr))
			return acc;
		},
		[]
	);
}

/**
 * custom implementation of filter using reduce
 * @param {Array} array array to iterate over
 * @param {Function} fn function to execute for each element in the array
 */
function redFilter(array, fn) {
	return array.reduce(
		(acc, curr) => {
			if (fn(curr)) {
				acc.push(curr);
			}
			return acc;
		}, []
	);
}

/**
 * custom implementation of indexOf using reduce
 * @param {Array} array array to iterate over
 * @param {Function} fn function to execute for each element in the array
 */
function redIndexOf(array, searchElement, fromIndex = 0) {
	if (fromIndex < 0) {
		fromIndex = array.length + fromIndex;
	}
	return array.reduce(
		(acc, cur, index) => {
			if (acc === -1 && index >= fromIndex && cur === searchElement) {
				acc = index;
			}
			return acc;
		}, -1
	);

}



let a = [1, 2, 3, 4, 2];
let fn = num => num % 2 == 0;

console.log(a.indexOf(2,-0));
console.log(redIndexOf(a,2,-0));



