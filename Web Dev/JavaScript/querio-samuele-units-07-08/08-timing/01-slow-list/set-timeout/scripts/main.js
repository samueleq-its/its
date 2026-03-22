/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * setInterval example
 * This code will print the name of a star every second, until it reaches the end of the array.
 * schedules a function that will iterate over every element of the array pausing for 1 second execution
 */

let stars = ["Sirius", "Canopus", "Rigil Kentaurus", "Arcturus", "Vega", "Capella", "Rigel", "Procyon", "Achernar", "Betelgeuse", "Hadar", "Altair", "Acrux", "Aldebaran", "Spica", "Antares", "Pollux", "Fomalhaut", "Deneb", "Mimosa", "Regulus", "Adhara", "Castor", "Shaula", "Bellatrix", "Alnath", "Alnilam", "Alnitak", "Peacock", "Epsilon Centauri"];

// with setInterval
console.log("==WITH INTERVAL==");
const step = 1000;
let i = 0;
let intervalId = setInterval(
    (x) => {
        if (i >= x.length) {
            clearInterval(intervalId);
            return
        }
        console.log(x[i]);
        i++;
    },
    step,
    stars
);