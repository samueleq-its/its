/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * Purpose of file
 *
 * Detailed explanation of what the file does
 * on multiple lines
 */

/**
 * function description
 * @param {type} paramName description
 * @returns {type} description
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

//transform: rotateY(180deg);
function catWalkFlip(catId) {
    const cat = document.getElementById(catId);
    const position = parseInt(cat.style.left.replace("px", "")) || 0;
    const currentDirection = cat.style.transform ? "left" : "right";
    if (currentDirection == "right") {
        cat.style.left = position + 10 + "px";

    } else { // going left
        cat.style.left = position - 10 + "px";
    }
    // could be modified to keep switching direction
    if (position >= window.innerWidth - cat.width) {
        cat.style.transform = "rotateY(180deg)";
    }
}

/**catWalkWait
 * setinterval until middle of the screen, then settimeout for 10 seconds, then setinterval again
 * 
 */
function catWalkWait(catId) {
    const cat = document.getElementById(catId);
    const position = parseInt(cat.style.left.replace("px", "")) || 0;

    cat.style.left = position + 10 + "px";
    if (position >= window.innerWidth / 2 - cat.width / 2) {
        clearInterval(catWalkWaitId);
        cat.src = "./assets/img/black-cat-sitting.png"
        cat.style.width = "300px";
        setTimeout(
            () => {
                cat.src = "http://www.anniemation.com/clip_art/images/cat-walk.gif";
                cat.style.width = "unset";
                setInterval(catWalkFlip, 50, "cat-wait")
            },
            10000, // timeout wait time
        );
    }
}



setInterval(catWalkRepeat, 50, "cat-repeat");
let catWalkFlipId = setInterval(catWalkFlip, 50, "cat-flip");
let catWalkWaitId = setInterval(catWalkWait, 50, "cat-wait");