/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * cat walking animation with start, stop, faster and slower controls
 */

const startBtn = document.getElementById("start-btn");
const fasterBtn = document.getElementById("faster-btn");
const slowerBtn = document.getElementById("slower-btn");
const stopBtn = document.getElementById("stop-btn");
const statusText = document.getElementById("status");
let catIntervalId = null;
let catSpeed = 50; // base speed in milliseconds
let speedMult = 100; // cat speed multiplier (100% of base speed)
const SPEED_STEP = 20; // speed change step (20% of base speed)


/**
 * Moves the cat across the screen, resetting to the left once it goes off the right edge.
 * This function is called repeatedly by setInterval to create the animation effect.
 * @param {string} catId the id of the cat image to move
 */
function catWalkRepeat(catId) {
    const cat = document.getElementById(catId);
    const position = parseInt(cat.style.left.replace("px", "")) || 0;
    if (position >= window.innerWidth) {
        cat.style.left = "-250px";
    } else {
        cat.style.left = position + 10 + "px";
    }
}

/**
 * handles starting and stopping the cat movement by managing the interval timer
 * @param {boolean} start if true, starts the cat movement; if false, stops it
 */
function catMove(start){
    if (catIntervalId) {
        clearInterval(catIntervalId);
        catIntervalId = null;
    }
    if (start) {
        catIntervalId = setInterval(catWalkRepeat, catSpeed / speedMult * 100, "cat-repeat");
    }
}

/**
 * handles the start button click event, enabling the other buttons and starting the cat movement
 */
function startAction() {
    startBtn.disabled = true;
    fasterBtn.disabled = false;
    slowerBtn.disabled = false;
    stopBtn.disabled = false;

    catMove(true);
    statusText.textContent = "The cat is walking, speed: " + speedMult + "%";
}

/**
 * handles the faster button click event, increasing the speed multiplier and updating the cat movement and status text
 */
function fasterAction() {
    if (speedMult >= 500) return; // limit max speed to 500%
    speedMult += SPEED_STEP;
    catMove(true);
    statusText.textContent = "The cat is walking, speed: " + speedMult + "%";
}

/**
 * handles the slower button click event, decreasing the speed multiplier and updating the cat movement and status text
 */
function slowerAction() {
    if (speedMult <= 20) return; // prevent speed from going to zero or negative
    speedMult -= SPEED_STEP;
    catMove(true);
    statusText.textContent = "The cat is walking, speed: " + speedMult + "%";
}

/**
 * handles the stop button click event, keeping enable only the start button and stopping the cat movement
 */
function stopAction() {
    startBtn.disabled = false;
    fasterBtn.disabled = true;
    slowerBtn.disabled = true;
    stopBtn.disabled = true;

    catMove(false);
    statusText.textContent = "The cat has stopped, press Start to make it walk again";
}

// add event listeners to buttons
startBtn.addEventListener("click", startAction);
fasterBtn.addEventListener("click", fasterAction);
slowerBtn.addEventListener("click", slowerAction);
stopBtn.addEventListener("click", stopAction);
