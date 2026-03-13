let game = {
    nome: "Minecraft Java Edition",
    platform: "pc",
    publisher: "Mojang",
    year: 2011
};

let gameJson = JSON.stringify(game);

console.log(game);
console.log(gameJson);


let game2 = JSON.parse(gameJson);

console.log(game2);