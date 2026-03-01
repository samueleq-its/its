/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * checks if a credit card number is valid and prints the result in the console
 * 
 * validation rules:
 * - Number must be 16 digits, all of them must be numbers
 * - all of the digits cannot be the same
 * - The final digit must be even
 * - The sum of all the digits must be greater than 16
 */

/**
 * checks if the sum of the digits in the credit card number is greater than 16
 * @param {string} creditCardNumber the credit card number to validate
 * @returns {boolean} true if the sum of the digits is greater than 16, false otherwise
 */
function isSumGreaterThan16(creditCardNumber) {
	let sum = 0;
	for (let i = 0; i < creditCardNumber.length; i++) {
		sum += parseInt(creditCardNumber[i]);
	}
	return sum > 16;
}

/**
 * validates a credit card number based on the following rules:
 * - Number must be 16 digits, all of them must be numbers
 * - all of the digits cannot be the same
 * - The final digit must be even
 * - The sum of all the digits must be greater than 16
 * @param {string} creditCardNumber the credit card number to validate
 * @returns {object} an object containing the validation result, the credit card number and an error message if the validation failed
 */
function validateCreditCard(creditCardNumber) {
	let isValid = true;
	let error = "";
	let formattedNumber = creditCardNumber.replaceAll("-", "");

	if (formattedNumber.length != 16) {
		// invalid length
		isValid = false;
		error = "Invalid length         ";
	} else if (/[^0-9]/.test(formattedNumber)) { //checks if there are non-digit characters
		// invalid characters
		isValid = false;
		error = "Invalid characters     ";
	} else if (!RegExp(`[^${formattedNumber[0]}]`).test(formattedNumber)) { //checks if there are characters different from the first one
		// all digits are the same
		isValid = false;
		error = "All digits are the same";
	} else if (formattedNumber.charAt(formattedNumber.length - 1) % 2 != 0) { //checks if the last digit is even
		// last digit is not even
		isValid = false;
		error = "Last digit not even    ";
	} else if (!isSumGreaterThan16(formattedNumber)) {
		// sum of digits is not greater than 16
		error = "Sum is lower than 16   ";
	}
	return isValid ? { valid: true, number: creditCardNumber } : { valid: false, number: creditCardNumber, error: error };
}

/**
 * prints the validation result of a credit card number
 * @param {object} validation the validation result object returned by the validateCreditCard function
 */
function printValidation(validation) {
	let output = (
		`===================================\n` +
		`= number : ${validation.number}    =\n` +
		(validation.valid ?
			// if valid
			`= valid : true                    =\n` :
			// if not valid
			`= valid : false                   =\n` +
			`= error : ${validation.error} =\n`
		) +
		`===================================\n`
	);
	console.log(output);
}

printValidation(validateCreditCard("9999-9999-8888-0000"));
printValidation(validateCreditCard('4444-4444-4444-4444'));
printValidation(validateCreditCard('6666-6666-6666-1666'));
printValidation(validateCreditCard('a923-3211-9c01-1112'));