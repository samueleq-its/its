/*
Esercizio - MaxNPositivi
Dati in input n numeri interi strettamente positivi, determinare il valore max inserito.
Visualizzare il max.

NOTA: l'inserimento dei dati si interrompe quando viene inserito un valore non positivo o nullo.
*/


int max = int.MinValue;

Console.Out.WriteLine("inserisci numeri positivi, 0 o negativo per uscire");
while (true)
{
	Console.Out.Write("inserisci numero:");
	int n = int.Parse(Console.In.ReadLine());
	if (n <= 0)
	{
		break;
	}
	max = n > max ? n : max;
}
if (max == int.MinValue)
{
	Console.Out.WriteLine($"Nessun numero inserito");
}
else
{
	Console.Out.WriteLine($"Numero più grande inserito: {max}");
}
