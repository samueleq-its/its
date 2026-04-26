/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * This file contains the code to create a factory object and a list of cars, then it creates an HTML representation of the factory and the cars using a recursive function.
 */

/**
 * function description
 * @param {type} paramName description
 * @returns {type} description
 */

let factoryString = `{
	"id": 1,
	"name": "Torino Auto Plant",
	"isActive": true,
	"foundedYear": 1985,
	"address": {
		"street": "Via Industria 10",
		"city": "Torino",
		"country": "Italy"
	},
	"departments": ["Assembly", "Paint", "Quality Control", "Logistics"],
	"carsIds": [1, 2, 3, 4, 5],
	"notes": null
}`;

let carsString = `[
    {
        "id": 1,
        "make": "Fiat",
        "model": "Panda",
        "year": 2020,
        "engine": {
            "type": "Inline-4",
            "displacement": "2.5L",
            "horsepower": 203,
            "fuelType": [
                "Gasoline",
                "LPG"
            ]
        },
        "fourWheelDrive": false,
        "Color":"Black",
        "licensePlate": "AQ4821CF"
    },
    {
        "id": 2,
        "make": "Fiat",
        "model": "Panda",
        "year": 2020,
        "engine": {
            "type": "Inline-4",
            "displacement": "2.5L",
            "horsepower": 203,
            "fuelType": [
                "Gasoline",
                "LPG"
            ]
        },
        "fourWheelDrive": false,
        "Color": "Red",
        "licensePlate": "AX1234RT"
    },
    {
        "id": 3,
        "make": "Fiat",
        "model": "Panda",
        "year": 2020,
        "engine": {
            "type": "Inline-4",
            "displacement": "2.5L",
            "horsepower": 203,
            "fuelType": [
                "Gasoline",
                "LPG"
            ]
        },
        "fourWheelDrive": false,
        "Color": "Blue",
        "licensePlate": "AX5678BT"
    },
    {
        "id": 4,

        "make": "Fiat",
        "model": "Panda",
        "year": 2020,
        "engine": {
            "type": "Inline-4",
            "displacement": "2.5L",
            "horsepower": 203,
            "fuelType": [
                "Gasoline",
                "LPG"
            ]
        },
        "fourWheelDrive": false,
        "Color": "Green",
        "licensePlate": "AX598ZA"
    },
    {
        "id": 5,
        "make": "Fiat",
        "model": "Panda",
        "year": 2020,
        "engine": {
            "type": "Inline-4",
            "displacement": "2.5L",
            "horsepower": 203,
            "fuelType": [
                "Gasoline",
                "LPG"
            ]
        },
        "fourWheelDrive": true,
        "Color": "Black",
        "licensePlate": "AZ600PU"
    }
]`;

console.log(JSON.parse(factoryString));
console.log(JSON.parse(carsString));

/**
 * Creates an HTML list representing a factory object, works recursively to create nested lists for nested objects.
 * @param {Object} factory - The factory object to convert to HTML.
 * @returns {HTMLElement} The created HTML list element.
 */
function createFactoryHtml(factory) {
    /*
    create a ul element
    create a li element for each property of the factory object
        if the property is an object, call recursively the function to create a nested ul
    append the li elements to the ul element
    */
    let ul = document.createElement("ul");
    for (let key in factory) {
        let li = document.createElement("li");
        if (typeof factory[key] === "object" && factory[key] !== null) {
            li.textContent = key + ":";
            li.appendChild(createFactoryHtml(factory[key]));
        } else {
            li.textContent = key + ": " + factory[key];
        }
        ul.appendChild(li);
    }
    return ul;
}

let factoryH2 = document.createElement("h2");
factoryH2.textContent = "Factory:";
document.getElementById("factory").appendChild(factoryH2);
document.getElementById("factory").appendChild(createFactoryHtml(JSON.parse(factoryString)));

let carH2 = document.createElement("h2");
carH2.textContent = "Cars:";
document.getElementById("cars").appendChild(carH2);
document.getElementById("cars").appendChild(createFactoryHtml(JSON.parse(carsString)));