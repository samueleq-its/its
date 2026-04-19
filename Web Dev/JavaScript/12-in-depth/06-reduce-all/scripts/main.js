/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * custom implementations of forEach, map, filter, indexOf and slice using reduce
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

/**
 * custom implementation of slice using reduce
 * @param {Array} array array to iterate over
 * @param {Number} start starting index
 * @param {Number} end ending index (not included)
 */
function redSlice(array, start = 0, end = array.length) {
	if (start < 0) {
		start = Math.max(array.length + start, 0);
	}
	if (end < 0) {
		end = Math.max(array.length + end, 0);
	}
	return array.reduce(
		(acc, cur, curIndex) => {
			if (curIndex >= start && curIndex < end) {
				acc.push(cur);
			}
			return acc;
		}, []
	);
}


let testArrays = [
	[1, 2, 3, 4, 5],
	['a', 'b', 'c', 'd', 'e'],
	[1, 2, 1, 5, 3, 0, 1]
];

console.log('==== Testing Array.foreach() method ====');
testArrays.forEach(
	arr => {
		let output = "";
		arr.forEach(x => output += x);
		console.log(output);
		output = "";
		redForEach(arr, x => output += x);
		console.log(output);
	}
);

console.log('==== Testing Array.map() method ====');
testArrays.forEach(
	arr => {
		console.log(arr.map(x => x * 2));
		console.log(redMap(arr, x => x * 2));
	}
);

console.log('==== Testing Array.filter() method ====');
testArrays.forEach(
	arr => {
		console.log(arr.filter(x => x % 2 == 0));
		console.log(redFilter(arr, x => x % 2 == 0));
	}
);

console.log('==== Testing Array.indexOf() method ====');
testArrays.forEach(
	arr => {
		console.log(arr.indexOf(1,1));
		console.log(redIndexOf(arr, 1,1));
	}
);

console.log('==== Testing Array.slice() method ====');
testArrays.forEach(
	arr => {
		console.log(arr.slice(1,-1));
		console.log(redSlice(arr, 1,-1));
	}
);