/*
 frequenza lanci dado
*/

Console.WriteLine("Frequenza di ogni faccia su n lanci di un d6");
int numeroLanci;
while (true)
{
Console.Write("n lanci: ");
numeroLanci = int.Parse(Console.ReadLine());
	if (numeroLanci <= 0)
	{
		Console.WriteLine("Errore, inserire un numero maggiore di 0");
		continue;
	}
	break;
}
Random rng = new Random();
int n1 = 0, n2 = 0, n3 = 0, n4 = 0, n5 = 0, n6 = 0;

for (int i = 0; i < numeroLanci; i++)
{
	int dado = rng.Next(6) +1 ; // oppure Next(1, 7);

	switch (dado)
	{
		case 1: n1++; break;
		case 2: n2++; break;
		case 3: n3++; break;
		case 4: n4++; break;
		case 5: n5++; break;
		case 6: n6++; break;
	}
}

string output = $"Frequenza facce:\n" +
	$"1: {((double)n1 / numeroLanci):0.##%}\n" +
	$"2: {((double)n2 / numeroLanci):0.##%}\n" +
	$"3: {((double)n3 / numeroLanci):0.##%}\n" +
	$"4: {((double)n4 / numeroLanci):0.##%}\n" +
	$"5: {((double)n5 / numeroLanci):0.##%}\n" +
	$"6: {((double)n6 / numeroLanci):0.##%}\n";

Console.WriteLine(output);
