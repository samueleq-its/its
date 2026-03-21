/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * Airport arrivals table update logic
 *
 * handles the update and display of the arrivals table, updating the flight status to "LANDED"
 * when the arrival time has passed and removing flights that have landed more than 60s ago
 */

const UPDATE_RATE = 10000;
const LANDED_REMOVAL_TIME = 60000;
const DISPLAYED_FLIGHTS = 10;
const MILLISECONDS_PER_HOUR = 3600000;
let expandedFlight = null; // the flight number with the open accordion for extr info

let arrivalsList = [
	{
		time: new Date(Date.now() + 15000),
		origin: "Napoli",
		flightStatus: "ON_TIME",
		delay: 0,
		flightNum: "FR3298",
		plane: "73H"
	},
	{
		time: new Date(Date.now() + 45000),
		origin: "Roma",
		flightStatus: "ON_TIME",
		delay: 0,
		flightNum: "AZ1423",
		plane: "320"
	},
	{
		time: new Date(Date.now() + 75000),
		origin: "Milano Malpensa",
		flightStatus: "DELAYED",
		delay: 0.5 * MILLISECONDS_PER_HOUR,
		flightNum: "U22911",
		plane: "319"
	},
	{
		time: new Date(Date.now() + 105000),
		origin: "Parigi",
		flightStatus: "ON_TIME",
		delay: 0,
		flightNum: "AF1208",
		plane: "321"
	},
	{
		time: new Date(Date.now() + 135000),
		origin: "Londra Gatwick",
		flightStatus: "DELAYED",
		delay: 1.25 * MILLISECONDS_PER_HOUR,
		flightNum: "BA2564",
		plane: "32N"
	},
	{
		time: new Date(Date.now() + 165000),
		origin: "Madrid",
		flightStatus: "ON_TIME",
		delay: 0,
		flightNum: "IB7110",
		plane: "333"
	},
	{
		time: new Date(Date.now() + 195000),
		origin: "Barcellona",
		flightStatus: "ON_TIME",
		delay: 0,
		flightNum: "VY6422",
		plane: "320"
	},
	{
		time: new Date(Date.now() + 225000),
		origin: "Berlino",
		flightStatus: "DELAYED",
		delay: 0.75 * MILLISECONDS_PER_HOUR,
		flightNum: "EW8827",
		plane: "32A"
	},
	{
		time: new Date(Date.now() + 255000),
		origin: "Amsterdam",
		flightStatus: "ON_TIME",
		delay: 0,
		flightNum: "KL1649",
		plane: "738"
	},
	{
		time: new Date(Date.now() + 285000),
		origin: "Bruxelles",
		flightStatus: "ON_TIME",
		delay: 0,
		flightNum: "SN3155",
		plane: "E95"
	},
	{
		time: new Date(Date.now() + 420000),
		origin: "Francoforte",
		flightStatus: "DELAYED",
		delay: 1.5 * MILLISECONDS_PER_HOUR,
		flightNum: "LH2431",
		plane: "32Q"
	},
	{
		time: new Date(Date.now() + 1200000),
		origin: "Monaco",
		flightStatus: "",
		delay: 0,
		flightNum: "EN8320",
		plane: "E90"
	},
	{
		time: new Date(Date.now() + 1980000),
		origin: "Vienna",
		flightStatus: "DELAYED",
		delay: 2 * MILLISECONDS_PER_HOUR,
		flightNum: "OS5219",
		plane: "321"
	},
	{
		time: new Date(Date.now() + 2760000),
		origin: "Atene",
		flightStatus: "",
		delay: 0,
		flightNum: "A37172",
		plane: "320"
	},
	{
		time: new Date(Date.now() + 3540000),
		origin: "Lisbona",
		flightStatus: "DELAYED",
		delay: 1 * MILLISECONDS_PER_HOUR,
		flightNum: "TP9483",
		plane: "32N"
	},
	{
		time: new Date(Date.now() + 4320000),
		origin: "Dublino",
		flightStatus: "ON_TIME",
		delay: 0,
		flightNum: "EI4402",
		plane: "7M8"
	},
	{
		time: new Date(Date.now() + 5100000),
		origin: "Praga",
		flightStatus: "",
		delay: 0,
		flightNum: "OK2716",
		plane: "319"
	},
	{
		time: new Date(Date.now() + 5880000),
		origin: "Budapest",
		flightStatus: "",
		delay: 0,
		flightNum: "W62457",
		plane: "320"
	},
	{
		time: new Date(Date.now() + 6660000),
		origin: "Zurigo",
		flightStatus: "DELAYED",
		delay: 0.5 * MILLISECONDS_PER_HOUR,
		flightNum: "LX1714",
		plane: "223"
	},
	{
		time: new Date(Date.now() + 7440000),
		origin: "Copenaghen",
		flightStatus: "ON_TIME",
		delay: 0,
		flightNum: "SK1890",
		plane: "32A"
	},
	{
		time: new Date(Date.now() + 8220000),
		origin: "Varsavia",
		flightStatus: "",
		delay: 0,
		flightNum: "LO3954",
		plane: "E75"
	},
	{
		time: new Date(Date.now() + 9000000),
		origin: "Amburgo",
		flightStatus: "DELAYED",
		delay: 1.75 * MILLISECONDS_PER_HOUR,
		flightNum: "EW1641",
		plane: "320"
	},
	{
		time: new Date(Date.now() + 9780000),
		origin: "Colonia",
		flightStatus: "",
		delay: 0,
		flightNum: "4U8821",
		plane: "319"
	},
	{
		time: new Date(Date.now() + 10560000),
		origin: "Stoccarda",
		flightStatus: "DELAYED",
		delay: 1.25 * MILLISECONDS_PER_HOUR,
		flightNum: "LH5140",
		plane: "32N"
	},
	{
		time: new Date(Date.now() + 11340000),
		origin: "Lione",
		flightStatus: "",
		delay: 0,
		flightNum: "AF7330",
		plane: "E90"
	},
	{
		time: new Date(Date.now() + 12120000),
		origin: "Marsiglia",
		flightStatus: "",
		delay: 0,
		flightNum: "FR8471",
		plane: "73H"
	},
	{
		time: new Date(Date.now() + 12900000),
		origin: "Nizza",
		flightStatus: "DELAYED",
		delay: 0.75 * MILLISECONDS_PER_HOUR,
		flightNum: "U21742",
		plane: "320"
	},
	{
		time: new Date(Date.now() + 13680000),
		origin: "Bordeaux",
		flightStatus: "DELAYED",
		delay: 1.5 * MILLISECONDS_PER_HOUR,
		flightNum: "V72933",
		plane: "319"
	},
	{
		time: new Date(Date.now() + 14460000),
		origin: "Siviglia",
		flightStatus: "",
		delay: 0,
		flightNum: "IB4042",
		plane: "321"
	},
	{
		time: new Date(Date.now() + 15240000),
		origin: "Valencia",
		flightStatus: "",
		delay: 0,
		flightNum: "VY8710",
		plane: "32N"
	},
	{
		time: new Date(Date.now() + 16020000),
		origin: "Palma",
		flightStatus: "DELAYED",
		delay: 0.5 * MILLISECONDS_PER_HOUR,
		flightNum: "FR2054",
		plane: "738"
	},
	{
		time: new Date(Date.now() + 16800000),
		origin: "Malaga",
		flightStatus: "",
		delay: 0,
		flightNum: "UX6129",
		plane: "333"
	},
	{
		time: new Date(Date.now() + 17580000),
		origin: "Bilbao",
		flightStatus: "",
		delay: 0,
		flightNum: "IB6624",
		plane: "320"
	},
	{
		time: new Date(Date.now() + 18360000),
		origin: "Porto",
		flightStatus: "DELAYED",
		delay: 2 * MILLISECONDS_PER_HOUR,
		flightNum: "TP9412",
		plane: "E95"
	},
	{
		time: new Date(Date.now() + 19140000),
		origin: "Faro",
		flightStatus: "",
		delay: 0,
		flightNum: "FR7130",
		plane: "73H"
	},
	{
		time: new Date(Date.now() + 19920000),
		origin: "Manchester",
		flightStatus: "DELAYED",
		delay: 1 * MILLISECONDS_PER_HOUR,
		flightNum: "BA7712",
		plane: "320"
	},
	{
		time: new Date(Date.now() + 20700000),
		origin: "Bristol",
		flightStatus: "",
		delay: 0,
		flightNum: "U28110",
		plane: "319"
	},
	{
		time: new Date(Date.now() + 21480000),
		origin: "Edimburgo",
		flightStatus: "",
		delay: 0,
		flightNum: "FR5591",
		plane: "7M8"
	},
	{
		time: new Date(Date.now() + 22260000),
		origin: "Glasgow",
		flightStatus: "",
		delay: 0,
		flightNum: "BA1281",
		plane: "320"
	},
	{
		time: new Date(Date.now() + 23040000),
		origin: "Newcastle",
		flightStatus: "",
		delay: 0,
		flightNum: "LS9304",
		plane: "321"
	},
	{
		time: new Date(Date.now() + 27600000),
		origin: "Oslo",
		flightStatus: "",
		delay: 0,
		flightNum: "DY1743",
		plane: "738"
	},
	{
		time: new Date(Date.now() + 32200000),
		origin: "Stoccolma",
		flightStatus: "",
		delay: 0,
		flightNum: "SK2871",
		plane: "32A"
	},
	{
		time: new Date(Date.now() + 36800000),
		origin: "Helsinki",
		flightStatus: "",
		delay: 0,
		flightNum: "AY1738",
		plane: "321"
	},
	{
		time: new Date(Date.now() + 41400000),
		origin: "Tallinn",
		flightStatus: "",
		delay: 0,
		flightNum: "BT6402",
		plane: "223"
	},
	{
		time: new Date(Date.now() + 46000000),
		origin: "Riga",
		flightStatus: "",
		delay: 0,
		flightNum: "BT8105",
		plane: "320"
	},
	{
		time: new Date(Date.now() + 50600000),
		origin: "Vilnius",
		flightStatus: "",
		delay: 0,
		flightNum: "W68171",
		plane: "32N"
	},
	{
		time: new Date(Date.now() + 55200000),
		origin: "Sofia",
		flightStatus: "",
		delay: 0,
		flightNum: "FB4360",
		plane: "319"
	},
	{
		time: new Date(Date.now() + 59800000),
		origin: "Bucarest",
		flightStatus: "",
		delay: 0,
		flightNum: "RO4112",
		plane: "320"
	},
	{
		time: new Date(Date.now() + 69000000),
		origin: "Belgrado",
		flightStatus: "",
		delay: 0,
		flightNum: "JU9841",
		plane: "319"
	},
	{
		time: new Date(Date.now() + 85800000),
		origin: "Istanbul",
		flightStatus: "",
		delay: 0,
		flightNum: "TK1874",
		plane: "333"
	}
];

/**
 * updates flight that have landed
 * removes flight that have landed more than LANDED_REMOVAL_TIME ago (60s)
 * @param {object[]} arrivalsList array of flight objects containing time, origin, flightStatus, flightNum and plane
 */
function updateFlights(arrivalsList) {
	for (let i = (arrivalsList.length - 1); i >= 0; i--) {
		let landingTime = arrivalsList[i].time.getTime() + arrivalsList[i].delay;
		if (Date.now() - landingTime > LANDED_REMOVAL_TIME) {
			arrivalsList.splice(i, 1);
		}
		if (landingTime < Date.now()) {
			arrivalsList[i].flightStatus = "LANDED";
		}
	}
}

/**
 * 
 * @param {object[]} arrivalsList array of flight objects containing time, origin, flightStatus, flightNum and plane
 * @param {HTMLElement} arrivalsTable
 */
function updateTable(arrivalsList, arrivalsTable) {
	// for each flight
	// create main row
	// create extra info row
	// append both to the table
	for (let i = 0; i < arrivalsList.length && i < DISPLAYED_FLIGHTS; i++) {
		let mainRow = createMainRow(arrivalsList[i]);
		let extraRow = createExtraRow(arrivalsList[i]);

		arrivalsTable.append(mainRow, extraRow);
	}
}

/**
 * 
 * @param {object} flight object containing flight info
 * @returns {HTMLElement} table row with the flight main info
 */
function createMainRow(flight) {
	let mainRow = document.createElement("tr");
	let dateTd = document.createElement("td");
	let timeTd = document.createElement("td");
	let originTd = document.createElement("td");
	let statusTd = document.createElement("td");
	let flightTd = document.createElement("td");

	//Date: DD-MM
	dateTd.append(
		`${String(flight.time.getDate()).padStart(2, "0")}-` +
		`${String(flight.time.getMonth() + 1).padStart(2, "0")}`
	);
	//Time hh:mm
	timeTd.append(
		`${String(flight.time.getHours()).padStart(2, "0")}:` +
		`${String(flight.time.getMinutes()).padStart(2, "0")}`
	);
	//Origin
	originTd.append(flight.origin);
	//Status
	statusTd.append(flight.flightStatus);
	//Flight number
	flightTd.append(flight.flightNum);
	//class = delayed (if delayed)
	if (flight.flightStatus == "DELAYED") {
		mainRow.classList.add("delayed");
	}
	mainRow.append(dateTd, timeTd, originTd, statusTd, flightTd);
	mainRow.id = flight.flightNum;

	return mainRow;
}

/**
 * 
 * @param {object} flight object containing flight info
 * @returns {HTMLElement} table row with the flight extra info
 */
function createExtraRow(flight) {
	let extraRow = document.createElement("tr");
	let extraTd = document.createElement("td");

	extraTd.append(`plane number: ${flight.plane}`);
	if (flight.flightStatus == "DELAYED") {
		let expected = new Date(flight.time.getTime() + flight.delay);
		extraTd.append(" | expected time: " +
			`${String(expected.getHours()).padStart(2, "0")}:` +
			`${String(expected.getMinutes()).padStart(2, "0")}`
		);
	}

	extraTd.colSpan = 5;
	extraRow.append(extraTd);
	extraRow.classList.add("accordion");

	return extraRow;
}

/**
 * expands the indicated row, if the row is already expanded closes it, 
 * if there's another expanded row closes it 
 * @param {string} flightNum 
 */
function rowClickHandler(flightNum) {
	/*
	if clicked row is already expanded (expandedFlight)
		close it
		expandedFlight = null
	else
		if there's another expanded row
			close it
		open clicked row
		expandedFlight = clicked row flight number
	*/
	if (expandedFlight == flightNum) {
		document.querySelector(`#${flightNum} + .accordion`).classList.remove("expanded");
		expandedFlight = null;
	} else {
		if (expandedFlight) {
			document.querySelector(`#${expandedFlight} + .accordion`).classList.remove("expanded");
		}
		document.querySelector(`#${flightNum} + .accordion`).classList.add("expanded");
		expandedFlight = flightNum;
	}
}

/**
 * adds a listener to every row in the table that calls the rowClickHandler function
 * when the row is clicked, allowing to expand and collapse the extra info column
 */
function addListeners() {
	let rowsList = document.querySelectorAll("tbody tr:not(.accordion)");
	if (rowsList == null) {
		//table is missing
		return;
	}
	for (let row of rowsList) {
		row.addEventListener(
			"click",
			(event) => {
				rowClickHandler(event.currentTarget.id);
			}
		);
	}
}

/**
 * wrapper function to update flights and table
 * @param {object[]} arrivalsList array of flight objects containing time, origin, flightStatus, flightNum and plane
 * @param {HTMLElement} arrivalsTable the tbody element where the table rows will be inserted
 */
function update(arrivalsList, arrivalsTable) {
	updateFlights(arrivalsList);
	arrivalsTable.innerHTML = ""; // clear table before update
	updateTable(arrivalsList, arrivalsTable);
	addListeners();
	// if a row was expanded keep it so
	let expandedRow = document.querySelector(`#${expandedFlight} + .accordion`);
	if (expandedRow) { expandedRow.classList.add("expanded"); }
}

//initial table update
let arrivalsTable = document.querySelector("#arrivals tbody");
update(arrivalsList, arrivalsTable);
//start updating the table every UPDATE_RATE ms (10s)
setInterval(update, UPDATE_RATE, arrivalsList, arrivalsTable);