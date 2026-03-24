/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * Identity Hijack exercise starter script
 *
 * Add DOM manipulation code here to transform Stanford branding
 * and references into Berkeley equivalents.
 */

//replace title text
let title = document.querySelector("title");
title.textContent = title.textContent.replaceAll("Stanford", "Berkeley");

// replace all instances of "Stanford" with "Berkeley"
let everything = document.querySelectorAll("a, div, p, h1,h2,h3");
for (let element of everything) {
    element.textContent = element.textContent.replaceAll("Stanford", "Berkeley");
}