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

let arrivalsList = [
    {
        time: new Date(Date.now() + 15000),
        origin: "Napoli",
        flightStatus: "ON_TIME",
        flightNum: "FR3298",
        plane: "73H"
    },
    {
        time: new Date(Date.now() + 45000),
        origin: "Roma",
        flightStatus: "ON_TIME",
        flightNum: "AZ1423",
        plane: "320"
    },
    {
        time: new Date(Date.now() + 75000),
        origin: "Milano Malpensa",
        flightStatus: "DELAYED",
        flightNum: "U22911",
        plane: "319"
    },
    {
        time: new Date(Date.now() + 105000),
        origin: "Parigi",
        flightStatus: "ON_TIME",
        flightNum: "AF1208",
        plane: "321"
    },
    {
        time: new Date(Date.now() + 135000),
        origin: "Londra Gatwick",
        flightStatus: "DELAYED",
        flightNum: "BA2564",
        plane: "32N"
    },
    {
        time: new Date(Date.now() + 165000),
        origin: "Madrid",
        flightStatus: "ON_TIME",
        flightNum: "IB7110",
        plane: "333"
    },
    {
        time: new Date(Date.now() + 195000),
        origin: "Barcellona",
        flightStatus: "ON_TIME",
        flightNum: "VY6422",
        plane: "320"
    },
    {
        time: new Date(Date.now() + 225000),
        origin: "Berlino",
        flightStatus: "DELAYED",
        flightNum: "EW8827",
        plane: "32A"
    },
    {
        time: new Date(Date.now() + 255000),
        origin: "Amsterdam",
        flightStatus: "ON_TIME",
        flightNum: "KL1649",
        plane: "738"
    },
    {
        time: new Date(Date.now() + 285000),
        origin: "Bruxelles",
        flightStatus: "",
        flightNum: "SN3155",
        plane: "E95"
    },
    {
        time: new Date(Date.now() + 420000),
        origin: "Francoforte",
        flightStatus: "DELAYED",
        flightNum: "LH2431",
        plane: "32Q"
    },
    {
        time: new Date(Date.now() + 1200000),
        origin: "Monaco",
        flightStatus: "",
        flightNum: "EN8320",
        plane: "E90"
    },
    {
        time: new Date(Date.now() + 1980000),
        origin: "Vienna",
        flightStatus: "DELAYED",
        flightNum: "OS5219",
        plane: "321"
    },
    {
        time: new Date(Date.now() + 2760000),
        origin: "Atene",
        flightStatus: "",
        flightNum: "A37172",
        plane: "320"
    },
    {
        time: new Date(Date.now() + 3540000),
        origin: "Lisbona",
        flightStatus: "DELAYED",
        flightNum: "TP9483",
        plane: "32N"
    },
    {
        time: new Date(Date.now() + 4320000),
        origin: "Dublino",
        flightStatus: "ON_TIME",
        flightNum: "EI4402",
        plane: "7M8"
    },
    {
        time: new Date(Date.now() + 5100000),
        origin: "Praga",
        flightStatus: "",
        flightNum: "OK2716",
        plane: "319"
    },
    {
        time: new Date(Date.now() + 5880000),
        origin: "Budapest",
        flightStatus: "",
        flightNum: "W62457",
        plane: "320"
    },
    {
        time: new Date(Date.now() + 6660000),
        origin: "Zurigo",
        flightStatus: "DELAYED",
        flightNum: "LX1714",
        plane: "223"
    },
    {
        time: new Date(Date.now() + 7440000),
        origin: "Copenaghen",
        flightStatus: "ON_TIME",
        flightNum: "SK1890",
        plane: "32A"
    },
    {
        time: new Date(Date.now() + 8220000),
        origin: "Varsavia",
        flightStatus: "",
        flightNum: "LO3954",
        plane: "E75"
    },
    {
        time: new Date(Date.now() + 9000000),
        origin: "Amburgo",
        flightStatus: "DELAYED",
        flightNum: "EW1641",
        plane: "320"
    },
    {
        time: new Date(Date.now() + 9780000),
        origin: "Colonia",
        flightStatus: "",
        flightNum: "4U8821",
        plane: "319"
    },
    {
        time: new Date(Date.now() + 10560000),
        origin: "Stoccarda",
        flightStatus: "DELAYED",
        flightNum: "LH5140",
        plane: "32N"
    },
    {
        time: new Date(Date.now() + 11340000),
        origin: "Lione",
        flightStatus: "",
        flightNum: "AF7330",
        plane: "E90"
    },
    {
        time: new Date(Date.now() + 12120000),
        origin: "Marsiglia",
        flightStatus: "",
        flightNum: "FR8471",
        plane: "73H"
    },
    {
        time: new Date(Date.now() + 12900000),
        origin: "Nizza",
        flightStatus: "DELAYED",
        flightNum: "U21742",
        plane: "320"
    },
    {
        time: new Date(Date.now() + 13680000),
        origin: "Bordeaux",
        flightStatus: "DELAYED",
        flightNum: "V72933",
        plane: "319"
    },
    {
        time: new Date(Date.now() + 14460000),
        origin: "Siviglia",
        flightStatus: "",
        flightNum: "IB4042",
        plane: "321"
    },
    {
        time: new Date(Date.now() + 15240000),
        origin: "Valencia",
        flightStatus: "",
        flightNum: "VY8710",
        plane: "32N"
    },
    {
        time: new Date(Date.now() + 16020000),
        origin: "Palma",
        flightStatus: "DELAYED",
        flightNum: "FR2054",
        plane: "738"
    },
    {
        time: new Date(Date.now() + 16800000),
        origin: "Malaga",
        flightStatus: "",
        flightNum: "UX6129",
        plane: "333"
    },
    {
        time: new Date(Date.now() + 17580000),
        origin: "Bilbao",
        flightStatus: "",
        flightNum: "IB6624",
        plane: "320"
    },
    {
        time: new Date(Date.now() + 18360000),
        origin: "Porto",
        flightStatus: "DELAYED",
        flightNum: "TP9412",
        plane: "E95"
    },
    {
        time: new Date(Date.now() + 19140000),
        origin: "Faro",
        flightStatus: "",
        flightNum: "FR7130",
        plane: "73H"
    },
    {
        time: new Date(Date.now() + 19920000),
        origin: "Manchester",
        flightStatus: "DELAYED",
        flightNum: "BA7712",
        plane: "320"
    },
    {
        time: new Date(Date.now() + 20700000),
        origin: "Bristol",
        flightStatus: "",
        flightNum: "U28110",
        plane: "319"
    },
    {
        time: new Date(Date.now() + 21480000),
        origin: "Edimburgo",
        flightStatus: "",
        flightNum: "FR5591",
        plane: "7M8"
    },
    {
        time: new Date(Date.now() + 22260000),
        origin: "Glasgow",
        flightStatus: "",
        flightNum: "BA1281",
        plane: "320"
    },
    {
        time: new Date(Date.now() + 23040000),
        origin: "Newcastle",
        flightStatus: "",
        flightNum: "LS9304",
        plane: "321"
    },
    {
        time: new Date(Date.now() + 27600000),
        origin: "Oslo",
        flightStatus: "",
        flightNum: "DY1743",
        plane: "738"
    },
    {
        time: new Date(Date.now() + 32200000),
        origin: "Stoccolma",
        flightStatus: "",
        flightNum: "SK2871",
        plane: "32A"
    },
    {
        time: new Date(Date.now() + 36800000),
        origin: "Helsinki",
        flightStatus: "",
        flightNum: "AY1738",
        plane: "321"
    },
    {
        time: new Date(Date.now() + 41400000),
        origin: "Tallinn",
        flightStatus: "",
        flightNum: "BT6402",
        plane: "223"
    },
    {
        time: new Date(Date.now() + 46000000),
        origin: "Riga",
        flightStatus: "",
        flightNum: "BT8105",
        plane: "320"
    },
    {
        time: new Date(Date.now() + 50600000),
        origin: "Vilnius",
        flightStatus: "",
        flightNum: "W68171",
        plane: "32N"
    },
    {
        time: new Date(Date.now() + 55200000),
        origin: "Sofia",
        flightStatus: "",
        flightNum: "FB4360",
        plane: "319"
    },
    {
        time: new Date(Date.now() + 59800000),
        origin: "Bucarest",
        flightStatus: "",
        flightNum: "RO4112",
        plane: "320"
    },
    {
        time: new Date(Date.now() + 69000000),
        origin: "Belgrado",
        flightStatus: "",
        flightNum: "JU9841",
        plane: "319"
    },
    {
        time: new Date(Date.now() + 85800000),
        origin: "Istanbul",
        flightStatus: "",
        flightNum: "TK1874",
        plane: "333"
    }
];

/**
 * Updates the arrivals table with the latest flight information
 * @param {arrivalsList} arrivalsList array of flight objects containing time, origin, flightStatus, flightNum and plane
 * @param {HTMLElement} arrivalsTable the tbody element where the table rows will be inserted
 */
function updateTable(arrivalsList, arrivalsTable) {
    let updatedRows = Array();
    //create list of updated table rows
    for (let flight of arrivalsList) {
        let row = document.createElement("tr");
        //Date: DD-MM
        let dateTd = document.createElement("td");
        dateTd.append(
            `${String(flight.time.getDate()).padStart(2, "0")}-` +
            `${String(flight.time.getMonth() + 1).padStart(2, "0")}`
        );
        row.append(dateTd);
        //Time hh:mm
        let timeTd = document.createElement("td");
        timeTd.append(
            `${String(flight.time.getHours()).padStart(2, "0")}:` +
            `${String(flight.time.getMinutes()).padStart(2, "0")}`
        );
        row.append(timeTd);
        //Origin
        let originTd = document.createElement("td");
        originTd.append(flight.origin);
        row.append(originTd);
        //Status
        let statusTd = document.createElement("td");
        statusTd.append(flight.flightStatus);
        row.append(statusTd);
        //Flight number
        let flightTd = document.createElement("td");
        flightTd.append(flight.flightNum);
        row.append(flightTd);
        //Airplane number
        let airplaneTd = document.createElement("td");
        airplaneTd.append(flight.plane);
        row.append(airplaneTd);
        //class = delayed (if delayed)
        if (flight.flightStatus == "DELAYED") {
            row.className = "delayed";
        }
        //add to new rows
        updatedRows.push(row);
    }
    //replaces previous table
    arrivalsTable.replaceChildren(...updatedRows);
}

/**
 * updates flight that have landed
 * removes flight that have landed more than LANDED_REMOVAL_TIME ago (60s)
 * @param {arrivalsList} arrivalsList array of flight objects containing time, origin, flightStatus, flightNum and plane
 */
function updateFlights(arrivalsList) {    
    for (let i = (arrivalsList.length-1); i >= 0; i--) {
        if (Date.now() - arrivalsList[i].time > LANDED_REMOVAL_TIME){
            arrivalsList.splice(i,1);
        }
        if (arrivalsList[i].time < Date.now()) {
            arrivalsList[i].flightStatus = "LANDED";
        }
    }
    
}

/**
 * wrapper function to update flights and table
 * @param {arrivalsList} arrivalsList array of flight objects containing time, origin, flightStatus, flightNum and plane
 * @param {HTMLElement} arrivalsTable the tbody element where the table rows will be inserted
 */
function update(arrivalsList, arrivalsTable) {
    updateFlights(arrivalsList);
    updateTable(arrivalsList, arrivalsTable);
}

//initial table update
let arrivalsTable = document.querySelector("#arrivals tbody");
updateTable(arrivalsList, arrivalsTable);
//start updating the table every UPDATE_RATE ms (10s)
setInterval(update, UPDATE_RATE, arrivalsList, arrivalsTable);