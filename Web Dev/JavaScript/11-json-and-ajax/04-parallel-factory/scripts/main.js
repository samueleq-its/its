/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * Purpose of file
 *
 * Detailed explanation of what the file does
 * on multiple lines
 */

// object with the api URL and the ids of the jsons
const jsonblob = {
    endpoint: "https://api.jsonblob.com/",
    factory: "019d3ebd-7dfa-74ca-92c4-3e3d2dcc2692",
    cars: {
        "car1": "019d4e11-8584-7a55-a9b9-7b7272a289a7",
        "car2": "019d4e11-c59a-7177-8110-6dfd77bcf506",
        "car3": "019d4e13-0b14-71d9-9346-fbe6ccc0ea10",
        "car4": "019d4e11-f153-7ba8-a97f-6892045ad5a9",
        "car5": "019d4e12-a5f9-77b7-ae5d-e12302a98bf5"
    }
};

let requestsQueue = {factory: null};
for (let carId in jsonblob.cars) {
    requestsQueue[carId] = null;
}

/**
 * helper function, returns an element of the given type with the given text
 * @param {string} type type of the element to create
 * @param {string} text text content of the element
 * @returns {HTMLElement} the created element
 */
function createTextElement(type, text) {
    let elem = document.createElement(type);
    elem.textContent = text;
    return elem;
}

/**
 * appends a label and an input element to the parent element, the input type is determined by the value type
 * @param {HTMLElement} parent parent element to append to
 * @param {string} id id of the input element
 * @param {string} inputName name property of the input element
 * @param {string} labelText text content of the label for the input element
 * @param {string|number|boolean} value initial value for the input element
 */
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

function displayMessage(message, isWarning = false) {
    const messageContainer = document.getElementById("message-container");
    messageContainer.classList.remove("hide");
    messageContainer.children[0].textContent = message;
    if (isWarning) {
        messageContainer.children[0].classList.add("warning-message");
    }
}

/**
 * Updates the information of a car in the remote API, the car id is used to get the form and the jsonblob id, the form is used to create an object with the updated data that is sent to the API
 * @param {string} carId the id of the car to update, used to get the form and the jsonblob id
 */
function putCar(carId) {
    displayMessage("Saving...");
    const carPutRequest = new XMLHttpRequest();
    carPutRequest.open("PUT", jsonblob.endpoint + jsonblob.cars[carId]);
    carPutRequest.setRequestHeader("Content-Type", "application/json");

    //create object from the form
    let updatedCar = {
        "id": carId,
        "engine": {}
    };
    const carForm = document.forms.namedItem(carId);
    for (let elem of carForm) {
        let value = elem.type == "number" ? Number(elem.value) : elem.type == "checkbox" ? elem.checked : elem.value;
        if (elem.tagName != "INPUT") { continue; }
        if (elem.id.includes("engine")) { //if engine data put it into the engine sub object
            if (elem.name == "fuelType") {
                updatedCar.engine[elem.name] = value.split(", ");
            } else {
                updatedCar.engine[elem.name] = value;
            }
        } else {
            updatedCar[elem.name] = value;
        }
    }
    carPutRequest.onload = () => {
        displayMessage("Data saved correctly");
        setTimeout(() => { window.location.reload(); }, 1000);
    };
    carPutRequest.onerror = (event) => { // error happened, data wasn't saved
        displayMessage("Error! data wasn't saved", true);
    };
    carPutRequest.send(JSON.stringify(updatedCar));
}

/**
 * Displays the information of a factory in the DOM
 * @param {object} factoryData json object with the factory data, should contain name, address (with street, city and country), departments (array of strings), foundedYear and optionally notes
 */
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

/**
 * Displays the information of a car in the DOM
 * @param {object} car json object with the car data, should contain id, make, model, year, color, licensePlate, fourWheelDrive and engine (with type, displacement, horsepower and fuelType (array of strings))
 */
function displayCar(car) {
    const carsContainer = document.getElementById("cars");
    //const carDiv = document.createElement("div");
    const carDiv = document.createElement("form");
    carDiv.id = car.id;
    carsContainer.append(carDiv);

    //controls buttons
    let controlsDiv = document.createElement("div");
    controlsDiv.className = "controls";
    carDiv.append(controlsDiv);
    let saveBtn = document.createElement("button");
    saveBtn.type = "button";
    saveBtn.className = "save-button";
    saveBtn.id = car.id;
    saveBtn.textContent = "Save";
    controlsDiv.append(saveBtn);
    let accordionBtn = document.createElement("button");
    accordionBtn.type = "button";
    accordionBtn.textContent = "Extra Info";
    controlsDiv.append(accordionBtn);

    //base info
    appendLabelInput(carDiv, `${car.id}-make`, "make", "Make: ", car.make);
    appendLabelInput(carDiv, `${car.id}-model`, "model", "Model: ", car.model);
    appendLabelInput(carDiv, `${car.id}-year`, "year", "Year: ", car.year);
    appendLabelInput(carDiv, `${car.id}-color`, "color", "Color: ", car.color);
    appendLabelInput(carDiv, `${car.id}-licensePlate`, "licensePlate", "License plate: ", car.licensePlate);

    //extra info accordion
    //make separate function?
    const accordion = document.createElement("div");
    carDiv.append(accordion);
    appendLabelInput(accordion, `${car.id}-fourWheelDrive`, "fourWheelDrive", "Four wheel drive: ", car.fourWheelDrive);

    //engine
    accordion.append(createTextElement("h4", "Engine"));
    appendLabelInput(accordion, `${car.id}-engine-type`, "type", "Type: ", car.engine.type);
    appendLabelInput(accordion, `${car.id}-engine-displacement`, "displacement", "Displacement: ", car.engine.displacement);
    appendLabelInput(accordion, `${car.id}-engine-horsepower`, "horsepower", "Horsepower: ", car.engine.horsepower);
    appendLabelInput(accordion, `${car.id}-engine-fuelType`, "fuelType", "Fuel types: ", car.engine.fuelType.join(", "));

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
            putCar(car.id);
        }
    );

}

/**
 * Handler for the onloadend event of the XMLHttpRequest, if the request is successful it executes the given action function, otherwise it displays the given error message
 * @param {XMLHttpRequest} XHRRequest the calling request 
 * @param {function} action function to execute if the request is successful
 * @param {string} errorMessage error message to display if the request fails
 */
function loadEndHandler(XHRRequest, action, errorMessage) {
    if (XHRRequest.status == 200) {
        action();
    } else {
        displayMessage(errorMessage, true);
    }
}

/**
 * helper function, adds the fade-out class to the loading element to hide it with a fade out animation
 */
function loadingFinish() {
    document.getElementById("loading").classList.add("fade-out");
}

/**
 * checks if all the requests in the requestsQueue object have been completed
 * if they are, it displays the factory and cars data and hides the loading element
 */
function checkRequestQueue(){
    if (Object.values(requestsQueue).includes(null)) { return; }
    for (let response in requestsQueue) {
        if (response == "factory") {
            displayFactory(JSON.parse(requestsQueue[response]));
        } else  {
            displayCar(JSON.parse(requestsQueue[response]));
        }
    }
    loadingFinish();
}

const factoryRequest = new XMLHttpRequest();
factoryRequest.open("GET", jsonblob.endpoint + jsonblob.factory);
factoryRequest.onloadend = () => {
    loadEndHandler(
        factoryRequest,
        () => {
            requestsQueue["factory"] = factoryRequest.responseText;
            checkRequestQueue();
        },
        "Error! factory data wasn't loaded, reload or contact support"
    );
};
factoryRequest.send()
for (let carId in jsonblob.cars) {
    const carRequest = new XMLHttpRequest();
    carRequest.open("GET", jsonblob.endpoint + jsonblob.cars[carId]);
    carRequest.onloadend = () => {
        loadEndHandler(
            carRequest,
            () => {
                requestsQueue[carId] = carRequest.responseText;
                checkRequestQueue();
            },
            "Error! car data wasn't loaded, reload or contact support"
        );
    };
    carRequest.send();
}


/*
TODO:
    check input values
*/