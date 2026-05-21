/*
 Esercizio - Cerchio
Dato in input il raggio di un cerchio, calcolare il diametro, la circonferenza e l'area.
Visualizzare il risultato.
 */

//input
Console.Write("raggio: ");
double raggio = double.Parse(Console.ReadLine());

//calcoli
double diametro = raggio * 2;
double circonferenza = diametro * Math.PI;
double area = Math.Pow(raggio, 2) * Math.PI;

//risultati
Console.WriteLine(
	$"diametro: {diametro}\n" +
	$"circonferenza: {circonferenza}\n" +
	$"area: {area}"
	);