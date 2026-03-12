/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * defines an array recipes as objects and prints their properties to console
 */


// let favRecipe = {
//     title: "Penne with salmon" ,
//     serving: 2,
//     ingredients: ["penne", "cream", "salmon", "parsley"]
// };

let recipes = [
    {
        title: "Penne with salmon",
        serving: 2,
        ingredients: ["penne", "cream", "salmon", "parsley"]
    },
    {
        title: "Spaghetti carbonara",
        serving: 4,
        ingredients: ["spaghetti", "eggs", "bacon", "parmesan", "black pepper"]
    },
    {
        title: "Rice with mushrooms",
        serving: 3,
        ingredients: ["rice", "mushrooms", "onion", "white wine", "broth", "butter"]
    }
];

/**
 * prints the properties of a recipe to console
 * @param {object} recipe recipe to print to console
 */
function printRecipe(recipe) {
    console.log("Title:", recipe.title);
    console.log("Servins:", recipe.serving);
    console.log("Ingredients:", recipe.ingredients);
}

for (let i = 0; i < recipes.length; i++) {
    printRecipe(recipes[i]);
}