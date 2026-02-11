/**
 * @file: main.js
 * @author: Samuele
 * Purpose of file
 *
 * prints to console if every number between 0 and 20 (inclusive) is even or odd
 */

for (let i = 0; i <= 20; i++) {
    console.log(`${i} is ${i%2 == 0 ? "even" : "odd"}`);
}