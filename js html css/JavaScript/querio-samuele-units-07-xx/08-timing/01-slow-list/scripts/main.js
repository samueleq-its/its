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
 * @param {type} paramName description
 * @returns {type} description
 */

let items = ["Sirius", "Canopus", "Rigil Kentaurus", "Arcturus", "Vega", "Capella", "Rigel", "Procyon", "Achernar", "Betelgeuse", "Hadar", "Altair", "Acrux", "Aldebaran", "Spica", "Antares", "Pollux", "Fomalhaut", "Deneb", "Mimosa", "Regulus", "Adhara", "Castor", "Shaula", "Bellatrix", "Alnath", "Alnilam", "Alnitak", "Peacock", "Epsilon Centauri"];

//with setInterval
console.log("With setInterval");

//WARNING: both start toghter

// with setTimeout
console.log("With setTimeout");
const step = 1000;
for (let i = 0; i < items.length; i++) {
    setTimeout(
        (x) => {console.log(x)},
        (i+1)*1000,
        items[i]
    );
}