/**
 * @file: main.js
 * @author: Samuele
 * defines function to print to console "Hello, Wolrd" in various languages
 */

/**
 * translates and prints to console "Hello, World", defaults to English
 * @param {string} languageCode the language code to translate
 * @returns the translation of "Hello, World"
 */
function helloWorld(languageCode) {
    switch (languageCode) {
        case "it":
            return "Ciao, Mondo";
            break;
        case "de":
            return "Hallo, Welt";
            break;
        case "en":
        default:
            return "Hello, World";
    }
}

console.log(helloWorld("en"));
console.log(helloWorld("it"));
console.log(helloWorld("de"));
console.log(helloWorld("prova"));