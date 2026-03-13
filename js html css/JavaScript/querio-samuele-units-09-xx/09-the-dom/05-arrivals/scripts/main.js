/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * Scaffolding JavaScript file for the 5.Arrivals exercise.
 *
 * Add DOM logic and simulation behavior here when explicitly requested.
 */

let flightList = [
    {
        time: new Date(Date.now() + 5000),
        origin: "Napoli",
        flightStatus: "ON_TIME",
        flightNum: "FR3298",
        plane: "73H"
    },
    {
        time: new Date(Date.now() + 120000),
        origin: "Roma",
        flightStatus: "ON_TIME",
        flightNum: "AZ1423",
        plane: "320"
    },
    {
        time: new Date(Date.now() + 210000),
        origin: "Milano Malpensa",
        flightStatus: "DELAYED",
        flightNum: "U22911",
        plane: "319"
    },
    {
        time: new Date(Date.now() + 345000),
        origin: "Parigi",
        flightStatus: "ON_TIME",
        flightNum: "AF1208",
        plane: "321"
    },
    {
        time: new Date(Date.now() + 480000),
        origin: "Londra Gatwick",
        flightStatus: "DELAYED",
        flightNum: "BA2564",
        plane: "32N"
    },
    {
        time: new Date(Date.now() + 620000),
        origin: "Madrid",
        flightStatus: "ON_TIME",
        flightNum: "IB7110",
        plane: "333"
    },
    {
        time: new Date(Date.now() + 760000),
        origin: "Barcellona",
        flightStatus: "DEPARTING",
        flightNum: "VY6422",
        plane: "320"
    },
    {
        time: new Date(Date.now() + 915000),
        origin: "Berlino",
        flightStatus: "DELAYED",
        flightNum: "EW8827",
        plane: "32A"
    },
    {
        time: new Date(Date.now() + 1040000),
        origin: "Amsterdam",
        flightStatus: "ON_TIME",
        flightNum: "KL1649",
        plane: "738"
    },
    {
        time: new Date(Date.now() + 1215000),
        origin: "Bruxelles",
        flightStatus: "ON_TIME",
        flightNum: "SN3155",
        plane: "E95"
    },
    {
        time: new Date(Date.now() + 1360000),
        origin: "Francoforte",
        flightStatus: "DEPARTING",
        flightNum: "LH2431",
        plane: "32Q"
    },
    {
        time: new Date(Date.now() + 1525000),
        origin: "Monaco",
        flightStatus: "ON_TIME",
        flightNum: "EN8320",
        plane: "E90"
    },
    {
        time: new Date(Date.now() + 1690000),
        origin: "Vienna",
        flightStatus: "DELAYED",
        flightNum: "OS5219",
        plane: "321"
    },
    {
        time: new Date(Date.now() + 1845000),
        origin: "Atene",
        flightStatus: "ON_TIME",
        flightNum: "A37172",
        plane: "320"
    },
    {
        time: new Date(Date.now() + 2010000),
        origin: "Lisbona",
        flightStatus: "DEPARTING",
        flightNum: "TP9483",
        plane: "32N"
    },
    {
        time: new Date(Date.now() + 2190000),
        origin: "Dublino",
        flightStatus: "DEPARTING",
        flightNum: "EI4402",
        plane: "7M8"
    },
    {
        time: new Date(Date.now() + 2380000),
        origin: "Praga",
        flightStatus: "",
        flightNum: "OK2716",
        plane: "319"
    },
    {
        time: new Date(Date.now() + 2570000),
        origin: "Budapest",
        flightStatus: "",
        flightNum: "W62457",
        plane: "320"
    },
    {
        time: new Date(Date.now() + 2780000),
        origin: "Zurigo",
        flightStatus: "DEPARTING",
        flightNum: "LX1714",
        plane: "223"
    },
    {
        time: new Date(Date.now() + 2995000),
        origin: "Copenaghen",
        flightStatus: "",
        flightNum: "SK1890",
        plane: "32A"
    }
];


/**
 * 
 * @param {object} flight 
 * @returns 
 */
function buildTableEntry(flight) {
    let tr = document.createElement("tr");
    //time
    let time = document.createElement("td");
    let day = flight.time.getDate();
    let month = String(flight.time.getMonth() + 1).padStart(2, "0");
    let hours = String(flight.time.getHours()).padStart(2, "0");
    let minutes = String(flight.time.getMinutes()).padStart(2, "0");
    let seconds = String(flight.time.getSeconds()).padStart(2, "0");
    time.append(`${day}-${month} ${hours}:${minutes}:${seconds}`);
    
    //origin
    let origin = document.createElement("td");
    origin.append(flight.origin);
    
    //status
    let flighStatus = document.createElement("td");
    flighStatus.append(flight.flightStatus);
    
    //flight
    let flightNum = document.createElement("td");
    flightNum.append(flight.flightNum);
    
    //plane
    let plane = document.createElement("td");
    plane.append(flight.plane);
    
    //row construction
    tr.append(time, origin, flighStatus, flightNum, plane);
    
    //id and classes
    tr.id += flight.flightNum;
    if (flight.flightStatus == "DELAYED") {
        tr.className += "delayed";
    }
    return tr;
}

function update() {
    for (let flight of flightList) {
        if (flight.time < Date.now() - 60000) {
            //if the flight arrived more than 60 seconds ago, remove the row from the table
            let flightRow = document.getElementById(flight.flightNum);
            if (flightRow) { flightRow.remove(); }
            continue;
        } // else
        if (flight.time < Date.now()) {
            //if flight has arrived withing 60 seconds, change status to 'ARRIVED'
            let flightStatus = document.querySelector(`#${flight.flightNum} td:nth-of-type(3)`);
            flightStatus.textContent = "ARRIVED";
        }

    }

}

//populate table with flights
let tbody = document.querySelector("#arrivals tbody");
for (let flight of flightList) {
    let tr = buildTableEntry(flight);
    tbody.append(tr);
}

//start updating the table
const UPDATE_RATE = 10000;
setInterval(update, UPDATE_RATE);