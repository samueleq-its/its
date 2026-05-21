/*
Esercizio - PrezzoQuantitaSconto
Dati in input il prezzo , la quantità e la percentuale di sconto per l'acquisto di un prodotto, calcolare il totale non scontato, lo sconto effettuato e il totale scontato da pagare.
Visualizzare il risultato.
es. 
prezzo: 10.00
quantita': 3
% sconto: 15
totale: 30.00 euro
 */

//input
Console.Write("prezzo: ");
double prezzo = double.Parse(Console.ReadLine());

Console.Write("quantita': ");
int quantita = int.Parse(Console.ReadLine());

Console.Write("% sconto': ");
int scontoPerc = int.Parse(Console.ReadLine());

//calcoli
double totale = prezzo * quantita;
double sconto = totale * scontoPerc / 100;
double totaleScontato = quantita * prezzo - sconto;

//risultati
Console.WriteLine($"totale non scontato: {totale:#.##} euro");
Console.WriteLine($"sconto applicato: {sconto:N2} euro");
Console.WriteLine($"totale scontato: {totaleScontato:N2} euro");