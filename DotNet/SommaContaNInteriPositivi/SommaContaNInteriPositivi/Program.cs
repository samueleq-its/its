/*
Esercizio - SommaContaNInteriPositivi
Dati in input N numeri interi strettamente positivi, visualizzare la somma e quanti numeri sono stati inseriti.
La terminazione dell'inserimento dei dati in input è determinato dalla presenza di un numero non positivo o nullo
Usare iterazione indefinita WHILE
*/

int n;
int somma = 0;
int i = 0;

string s = "";

while (true)
{
	Console.Write("n:");
	s = Console.ReadLine();
	
	if (s == "" || int.Parse(s) < 1)
	{
		break; 
	}
	n = int.Parse(s);
	somma += n;
	i++;
}

Console.WriteLine($"numeri inseriti: {i}");
Console.WriteLine($"somma: {somma}");