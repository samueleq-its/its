/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * Purpose of file
 *
 * Detailed explanation of what the file does
 * on multiple lines
 */


const jsonblob = {
    endpoint: "https://api.jsonblob.com/",
    factory: "019d3ebd-7dfa-74ca-92c4-3e3d2dcc2692",
    cars: [
        "019d4e11-8584-7a55-a9b9-7b7272a289a7",
        "019d4e11-c59a-7177-8110-6dfd77bcf506",
        "019d4e13-0b14-71d9-9346-fbe6ccc0ea10",
        "019d4e11-f153-7ba8-a97f-6892045ad5a9",
        "019d4e12-a5f9-77b7-ae5d-e12302a98bf5"
    ]
};

function createTextElement(type, text) {
    let elem = document.createElement(type);
    elem.textContent = text;
    return elem
}

function displayFactory(factoryData) {
    let factoryDiv = document.getElementById("factory");
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
    const carsDiv = document.getElementById("cars")
    const carDiv = document.createElement("div");
    carsDiv.append(carDiv);
    const list = document.createElement("ul");
    carDiv.append(list);
    list.append(createTextElement("li", "Make: " + car.make));
    list.append(createTextElement("li", "Model: " + car.model));
    list.append(createTextElement("li", "Year: " + car.year));
    list.append(createTextElement("li", "Color: " + car.color));
    list.append(createTextElement("li", "License Plate: " + car.licensePlate));
    //extra info accordion
    //make separate function?
    const accordion = document.createElement("div");
    carDiv.append(accordion);
    accordion.append(createTextElement("p", "Four wheel drive: " + (car.fourWheelDrive ? "yes" : "no")));
    //	engine
    accordion.append(createTextElement("h4", "Engine"));
    const accordList = document.createElement("ul");
    accordion.append(accordList);
    accordList.append(createTextElement("li", "Type: " + car.engine.type));
    accordList.append(createTextElement("li", "Displacement: " + car.engine.displacement));
    accordList.append(createTextElement("li", "Horse power: " + car.engine.horsepower));
    accordList.append(createTextElement("li", "fuel types: " + car.engine.fuelType.join(", ")));
    // add accordion logic
    accordion.classList.add("accordion");
    carDiv.addEventListener("click",
        (event) => {
            accordion.classList.toggle("expanded");
        }
    );

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
    split blobs 1 per car
    ERRORS:
        blob doesnt exist
        no/wrong response

NOTES:
    jsonblob will expire
*/