/*
Esercizio - PrezzoQuantita
Dati in input il prezzo e la quantità di acquisto di un prodotto, calcolare il totale e visualizzare il risultato.
es. 
prezzo: 10.00
quantita': 3
totale: 30.00 euro
*/

//input
Console.Write("prezzo: ");
double prezzo = double.Parse(Console.ReadLine());

Console.Write("quantita': ");
int quantita = int.Parse(Console.ReadLine());

//calcoli
double totale = prezzo * quantita;

//risultati
Console.WriteLine($"totale: {totale:N2} euro");