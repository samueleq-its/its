/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * takes user input and generates a story based on it, then displays the story in the story div
 */

/**
 * generates a story based on user input and displays it in the story div
 */
function makeStory() {
    //get values from inputs
    let noun = document.getElementById("noun").value;
    let adjective = document.getElementById("adjective").value;
    let person = document.getElementById("person").value;

    //generate story
    let story = `${person} detests ${adjective} ${noun}`;

    //insert story into story div
    document.getElementById("story").textContent = story;
}

let genButton = document.getElementById("gen-button");
if (genButton) {
    genButton.addEventListener("click", makeStory);
}