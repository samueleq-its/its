/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * Purpose of file
 *
 * Detailed explanation of what the file does
 * on multiple lines
 */

const endpoint = "https://api.jsonblob.com/";
const factoryBlobId = "019d3ebd-7dfa-74ca-92c4-3e3d2dcc2692";
const carsBlobId = "019d3ebd-d529-7d26-9800-4248845daa43";

function createTextElement(type, text) {
	let elem = document.createElement(type);
	elem.textContent = text;
	return elem
}

function displayFactory(factoryData) {
	let factoryDiv = document.getElementById("factory");
	factoryDiv.innerHTML = "";
	if (!factoryDiv) { return; }
	factoryDiv.append(createTextElement("h2", factoryData.name));
	let text = `${factoryData.address.street}, ${factoryData.address.city}, ${factoryData.address.country}`;
	factoryDiv.append(createTextElement("p", text));
	text = `Departments: ${factoryData.departments.join(", ")}`;
	factoryDiv.append(createTextElement("p", text));
	text = `Founding year: ${factoryData.foundedYear}`;
	factoryDiv.append(createTextElement("p", text));
	if (factoryData.notes) {
		factoryDiv.append(createTextElement("p", "Notes: " + factoryData.notes));
	}
}
//WIP name
function displayCar(car) {
	// create HTML
	let carsDiv = document.getElementById("cars")
	let list = document.createElement("ul");
	carsDiv.innerHTML = "";
	carsDiv.append(list);
	list.append(createTextElement("li", "Make: " + car.make));
	list.append(createTextElement("li", "Model: " + car.model));
	list.append(createTextElement("li", "Year: " + car.year));
	list.append(createTextElement("li", "Color: " + car.color));
	list.append(createTextElement("li", "License Plate: " + car.licensePlate));
	//extra info accordion
	let accordion = document.createElement("div");
	accordion.classList.add("accordion");
	accordion.append(createTextElement("p", "Four wheel drive: " + (car.fourWheelDrive? "yes" : "no")));
	//	engine
	accordion.append(createTextElement("h3", "Engine"));
	// add accordion logic
	carsDiv.append(accordion);
	
}

const factoryRequest = new XMLHttpRequest();
factoryRequest.open("GET", endpoint + factoryBlobId);
// TODO: handle errors
factoryRequest.onload = () => {
	// display factory info to screen
	displayFactory(JSON.parse(factoryRequest.responseText));
};
factoryRequest.send();

const carsRequest = new XMLHttpRequest();
carsRequest.open("GET", endpoint + carsBlobId);
// TODO: handle errors
carsRequest.onload = () => {
	for (let car of JSON.parse(carsRequest.responseText)) {
		displayCar(car);
	}
};
carsRequest.send();

/**
 * cars:
 * receive data
 * display data
 *	 	inside cars div
 *	 	each car is a div
 *	 	data in list
 *	 	extra data in extra div
 * extra info in accordion
 * data can be modified
 * if data is modified
 *  send to jsonblob
 *  reload json
 */

/*
TODO:
	check errors from request
	blobs might expire
	loading screen
	1 listener for every accordion ? 
	displayFactory uses li instead of p ?
	ERRORS:
		blob doesnt exist
		no/wrong response

NOTES:
	jsonblob will expire
	only used 2 blobs due to jsonblob limitation otherwise 1 json per car
*/