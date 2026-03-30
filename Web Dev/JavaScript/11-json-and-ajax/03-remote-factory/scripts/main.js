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

let factoryString;

const factoryRequest = new XMLHttpRequest();

factoryRequest.open("GET", endpoint + factoryBlobId);
// TODO: handle errors
factoryRequest.onload =
    () => {
        // 
    };

factoryRequest.send();

const carsRequest = new XMLHttpRequest();

carsRequest.open("GET", endpoint + carsBlobId);
// TODO: handle errors
carsRequest.onload =
    () => {
        // 
    };

carsRequest.send();



/*
TODO:
    check errors from request
    blobs might expire
*/