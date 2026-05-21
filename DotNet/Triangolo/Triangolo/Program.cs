/* dati in input i lati di un triangolo
 * calcolare:
 *		perimentro
 *		area
 *		tipo
 */

Console.Write("lato 1:");
double latoA = double.Parse( Console.ReadLine());
Console.Write("lato 2:");
double latoB = double.Parse( Console.ReadLine());
Console.Write("lato 3:");
double latoC = double.Parse( Console.ReadLine());

if (latoA + latoB > latoC && latoB + latoC > latoA && latoC + latoA > latoB)
{
	double perimetro = latoA + latoB + latoC;
	double s = perimetro / 2;
	double area = Math.Sqrt(s * (s - latoA) * (s - latoB) * (s - latoC));

	string tipo = "Scaleno";
	if (latoA == latoB && latoB == latoC)
	{
		tipo = "Equilatero";
	}
	else if (latoA == latoB || latoB == latoC || latoC == latoA)
	{
		tipo = "Isoscele";
	}

	Console.WriteLine(
		$"Risultati:\n" +
		$"Perimetro: {perimetro}\n" +
		$"Area: {area}\n" +
		$"Tipo: {tipo}"
		);
} else
{
	Console.WriteLine("non è un triangolo, la somma di due lati deve essere maggiore del terzo");
}

