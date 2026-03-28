/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * Purpose of file
 *
 * Detailed explanation of what the file does
 * on multiple lines
 */

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
 * Moves the cat across the screen, flipping the image and inverting the movement direction when it reaches the edges.
 * This function is called repeatedly by setInterval to create the animation effect.
 * @param {string} catId the id of the cat image to move
 */
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

/**
 * Moves the cat across the screen, waiting at the center before changing image and continuing with catWalkFlip.
 * This function is called repeatedly by setInterval to create the animation effect.
 * @param {string} catId the id of the cat image to move
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