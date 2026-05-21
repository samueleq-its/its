/*
Esercizio - Quadrato
Dato in input il lato di un quadrato, calcolare il perimetro, l'area e la diagonale.
Visualizzare il risultato
 */

//input
Console.Write("lato: ");
double lato = double.Parse( Console.ReadLine());

//calcoli
double perimetro = lato * 4;
double area = Math.Pow(lato,2);
double diagonale = lato * Math.Sqrt(2);

//risultati
Console.WriteLine(
	$"perimentro: {perimetro}\n" +
	$"area: {area}\n" +
	$"diagonale: {diagonale}"
	);