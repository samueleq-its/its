/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * creates an array from a list of words
 * for each word, it creates a 'sound wave' by capitalizing one letter at a time and adding exclamation marks
 */

let noisesArray = ['quack', 'sneeze', 'boom'];

let soundWaves = [];

for (const word of noisesArray) {
    for (let i = 0; i < word.length; i++) {
        soundWaves.push(word.slice(0, i) + word.charAt(i).toUpperCase() + word.slice(i + 1, word.length) + "!".repeat(i + 1));
    }
}

console.log(soundWaves);