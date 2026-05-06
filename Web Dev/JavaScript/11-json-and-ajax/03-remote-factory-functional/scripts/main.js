

const jsons = {
	factory: "./json/factory.json",
	cars: {
		car1: "./json/car1.json",
		car2: "./json/car2.json",
		car3: "./json/car3.json",
		car4: "./json/car4.json",
		car5: "./json/car5.json"
	}
}

/**
 * @param {string} path 
 * @returns {Promise<Object>}
 */
function fetchData(path) {
	return fetch(path)
		.then(result => result.json())
		.then(data => data);
	//.catch(error => error);
}

/**
 * @param {string} type 
 * @param {string} text 
 * @returns {HTMLElement}
 */
function createTextElement(type, text) {
	let elem = document.createElement(type);
	elem.textContent = text;
	return elem;
}

/**
 * 
 * @param {Function} type 
 * @param {object} obj 
 * @returns {HTMLElement[]}
 */
function parseObjToHtml(type, obj) {
	let parser = OBJ_PARSER[type] || (() => { throw new Error("Unknown type"); });
	return parser(obj);
}

function carButtonsData(data,) {
	const saveBtn = document.createElement("button");
	saveBtn.type = "button";
	saveBtn.className = "save-button";
	saveBtn.id = data.id;
	saveBtn.textContent = "Save";
	const accordionBtn = document.createElement("button");
	accordionBtn.type = "button";
	accordionBtn.textContent = "Extra Info";

	const buttonsData = [
		saveBtn,
		accordionBtn
	];

	return buttonsData;
}

function carButtonsContainer(buttonsData) {
	const buttonsContainer = document.createElement("div");
	buttonsContainer.className = "controls";
	buttonsContainer.append(...buttonsData);
	return buttonsContainer;
}

async function pipeline(path, type, elementId) {
	const data = await fetchData(path);
	const html = parseObjToHtml(OBJ_TYPE.FACTORY, data);
	document.getElementById(elementId).append(...html);
}

// refactor
function loadingFinish() {
	document.getElementById("loading").classList.add("fade-out");
}

//refactor
function appendLabelInput(parent, id, inputName, labelText, value) {
	let label = document.createElement("label");
	label.htmlFor = id;
	label.textContent = labelText;
	let input = document.createElement("input");
	input.id = id;
	input.name = inputName;
	input.type = typeof value == "number" ? "number" : typeof value == "boolean" ? "checkbox" : "text";
	input.value = value;
	parent.append(label, input);
}

async function main() {
	pipeline(jsons.factory, OBJ_TYPE.FACTORY, "factory");

	{
		const path = jsons.cars.car1;

		const data = await fetchData(path);

		const html = [];

		const carsContainer = document.getElementById("cars");
		//const carDiv = document.createElement("div");
		const carDiv = document.createElement("form");
		carDiv.id = data.id;
		carsContainer.append(carDiv);

		//controls buttons
		let controlsDiv = document.createElement("div");
		controlsDiv.className = "controls";
		carDiv.append(controlsDiv);
		let saveBtn = document.createElement("button");
		saveBtn.type = "button";
		saveBtn.className = "save-button";
		saveBtn.id = data.id;
		saveBtn.textContent = "Save";
		controlsDiv.append(saveBtn);
		let accordionBtn = document.createElement("button");
		accordionBtn.type = "button";
		accordionBtn.textContent = "Extra Info";
		controlsDiv.append(accordionBtn);

		//base info
		appendLabelInput(carDiv, `${data.id}-make`, "make", "Make: ", data.make);
		appendLabelInput(carDiv, `${data.id}-model`, "model", "Model: ", data.model);
		appendLabelInput(carDiv, `${data.id}-year`, "year", "Year: ", data.year);
		appendLabelInput(carDiv, `${data.id}-color`, "color", "Color: ", data.color);
		appendLabelInput(carDiv, `${data.id}-licensePlate`, "licensePlate", "License plate: ", data.licensePlate);

		//extra info accordion
		//make separate function?
		const accordion = document.createElement("div");
		carDiv.append(accordion);
		appendLabelInput(accordion, `${data.id}-fourWheelDrive`, "fourWheelDrive", "Four wheel drive: ", data.fourWheelDrive);

		//engine
		accordion.append(createTextElement("h4", "Engine"));
		appendLabelInput(accordion, `${data.id}-engine-type`, "type", "Type: ", data.engine.type);
		appendLabelInput(accordion, `${data.id}-engine-displacement`, "displacement", "Displacement: ", data.engine.displacement);
		appendLabelInput(accordion, `${data.id}-engine-horsepower`, "horsepower", "Horsepower: ", data.engine.horsepower);
		appendLabelInput(accordion, `${data.id}-engine-fuelType`, "fuelType", "Fuel types: ", data.engine.fuelType.join(", "));

		//add accordion logic
		accordion.classList.add("accordion");
		accordionBtn.addEventListener("click",
			(event) => {
				accordion.classList.toggle("expanded");
			}
		);

		//add update logic
		saveBtn.addEventListener("click",
			(event) => {
				putCar(data.id);
			}
		);
	}

	{
		const path = jsons.cars.car1;

		const data = await fetchData(path);

		const buttonsData = carButtonsData(data);
		const buttonsContainer = carButtonsContainer(buttonsData);




		// car form container
		const container = document.createElement("form");
		container.id = data.id;

		container.append(buttonsContainer);

		document.getElementById("cars").append(container);

	}



}

const OBJ_TYPE = {
	FACTORY: 0,
	CAR: 1
}

const OBJ_PARSER = {
	[OBJ_TYPE.FACTORY]: (obj) => [
		createTextElement("h2", obj.name),
		createTextElement("p",
			`${obj.address.street}, ${obj.address.city}, ${obj.address.country}`),
		createTextElement("p", `Departments: ${obj.departments.join(", ")}`),
		createTextElement("p", `Founding year: ${obj.foundedYear}`)
	],
	[OBJ_TYPE.CAR]: () => { throw new Error("not implemented"); }
}



main();
loadingFinish();
