for (game of GAMES) {
    console.dir(game);
    const RIGA = document.createElement('tr');
    const TD1 = document.createElement('td');
    const TD2 = document.createElement('td');
    const TD3 = document.createElement('td');
    const TD4 = document.createElement('td');
    const TD5 = document.createElement('td');
    TD1.textContent= game['Game'];
    TD2.textContent= game['Genre'];
    TD3.textContent= game['Platform'];
    TD4.textContent= game['Publisher'];
    TD5.textContent= game['year'];

    RIGA.append(TD1,TD2,TD3,TD4,TD5);
    document.querySelector('table > tbody').append(RIGA);

}