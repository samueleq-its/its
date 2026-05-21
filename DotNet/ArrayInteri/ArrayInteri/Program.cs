/*
Riempire un array di n numeri casuali appaertenenti all'intervallo [inf,sup]
con n, inf e sup dati in input

visualizzare i numeri generati e relativa posizione
*/

Console.WriteLine("Array di numeri interi");
Console.Write("n= ");
int n = int.Parse(Console.ReadLine());
Console.Write("inf= ");
int inf = int.Parse(Console.ReadLine());
Console.Write("sup= ");
int sup = int.Parse(Console.ReadLine());

int[] numeri = new int[n];

Random rng = new Random();

for (int i = 0; i < numeri.Length; i++)
{
	numeri[i] = rng.Next(inf, sup + 1);
}
Console.WriteLine("Riempimento effettuato");

Console.WriteLine("Risultato:");
foreach (int num in numeri)
{
	Console.Write($"{num}, ");
}