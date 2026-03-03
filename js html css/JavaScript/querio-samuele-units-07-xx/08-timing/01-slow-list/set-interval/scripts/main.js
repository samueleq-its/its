/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * setTimeout example
 * This code will print the name of a star every second, until it reaches the end of the array.
 * schedules a function to print to console for each element of the array, 
 * with a delay that depends on the index of the element in the array.
 */


let stars = ["Sirius", "Canopus", "Rigil Kentaurus", "Arcturus", "Vega", "Capella", "Rigel", "Procyon", "Achernar", "Betelgeuse", "Hadar", "Altair", "Acrux", "Aldebaran", "Spica", "Antares", "Pollux", "Fomalhaut", "Deneb", "Mimosa", "Regulus", "Adhara", "Castor", "Shaula", "Bellatrix", "Alnath", "Alnilam", "Alnitak", "Peacock", "Epsilon Centauri"];

// with setTimeout
console.log("==WITH TIMEOUT==");
const step = 1000;
let fn = (x) => { console.log(x); }
for (let i = 0; i < stars.length; i++) {
    setTimeout(fn, (i + 1) * step, stars[i]);
}