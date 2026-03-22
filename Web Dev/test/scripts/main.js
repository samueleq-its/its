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

document.getElementById('list').addEventListener('click', event => {
    const target = event.target;
    // if clicked element is a button
    if (target.tagName === 'BUTTON') {
    const parent = target.parentElement;
    parent.classList.toggle('highlighted'); // mark as highlighted
    }
    });