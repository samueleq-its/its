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
 * @param {string} creditCardNumber the credit card number to validate
 * @returns {object}
 */
function validateCreditCard(creditCardNumber) {
    /*
    - Number must be 16 digits, all of them must be numbers
    - You must have at least two different digits represented (all of the digits cannot be the same)
    - The final digit must be even
    - The sum of all the digits must be greater than 16
    */
   creditCardNumber = creditCardNumber.replaceAll("-", "");
    if (creditCardNumber.length != 16) {
        // invalid length
    }
    regexNotNumbers = /[^0-9]/;
    if (regexNotNumbers.test(creditCardNumber)) {
        // invalid characters
    }
    
}