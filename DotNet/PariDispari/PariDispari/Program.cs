/* dato un numero intero in input, visualizzare se è pari o dispari */

// input

Console.Write("inserisci un numero intero: ");
int numero = int.Parse(Console.ReadLine());

if (numero % 2 == 0)
{
	Console.WriteLine($"{numero} è pari");
}
else
{
	Console.WriteLine($"{numero} è dispari");
}