/*
Esercizio - FatturaAzienda
Dato in input l'imponibile, calcolare il totale da pagare sapendo che l'aliquota iva è al 22%
Visualizzare i risultati
input ...
output
Imponibile: 156,99 euro
Iva (22%): ?? euro
Totale: ?? euro
*/

//input
Console.Write("inponibile: ");
double inponibile = double.Parse(Console.ReadLine());
const int aliquotaIva = 22; // 22%

//calcoli
double iva = inponibile * aliquotaIva / 100;
double totale = inponibile + iva;

//risultati
Console.WriteLine(
	$"Iva ({aliquotaIva}%): {iva:f2} euro\n" + 
	$"Totale: {totale:f2} euro"
	);