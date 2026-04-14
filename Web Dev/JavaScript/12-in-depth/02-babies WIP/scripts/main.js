/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * add 4 babies to an array in different ways, then print all the babies with their properties
 */

let babies = [];

babies.push({
    name: "Timmy",
    months: 8,
    noise: ["ugugaga", "ue"],
    favoriteFoods: ["milk", "pineapple"]
});

babies.unshift({
    name: "Timbo",
    months: 3,
    noise: ["aaaaaaaaa", "ue"],
    favoriteFoods: ["milk"]
});

babies = babies.concat([{
    name: "Xoti",
    months: 5,
    noise: ["gne", "iiii"],
    favoriteFoods: ["steak", "hamburger"]
}])

babies[3] = {
    name: "Berta",
    months: 12,
    noise: ["oooooo", "AAAAAA"],
    favoriteFoods: ["her hands", "chocolate"]
}

babies.forEach(
    baby => {
        Object.keys(baby).forEach(key => { console.log(key +":"+ baby[key]) });
    }
);

babies[1].outfit = {
    shirt: "red",
    pants: "blue",
    shoes: "white"
};

babies[2].outfit = {
    hat: "blue",
    pants: "blue",
    shoes: "white"
};

babies[1].outfit = {
    shirt: "red",
    pants: "blue",
    shoes: "white"
};

babies[1].outfit = {
    shirt: "red",
    pants: "blue",
    shoes: "white"
};


babies.forEach(
    baby => {
        Object.keys(baby).forEach(key => { console.log(key +":"+ baby[key]) });
    }
);
