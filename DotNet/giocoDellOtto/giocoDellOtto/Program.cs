/*
estrazione di 5 numeri fino a 90 
*/


Console.WriteLine("Estrazione numeri dell'otto");

int n1 = 0, n2 = 0, n3 = 0, n4 = 0, n5 = 0;

Random rng = new Random();

n1 = rng.Next(90) + 1;

do
{
	n2 = rng.Next(90) + 1;
} while (n1 == n2);
do
{
	n3 = rng.Next(90) + 1;
} while (n1 == n3 || n1 == n3);
do
{
	n4 = rng.Next(90) + 1;
} while (n1 == n4 || n2 == n4 || n3 == n4);
do
{
	n5 = rng.Next(90) + 1;
} while (n1 == n5 || n2 == n5 || n3 == n5 || n4 == n5);


Console.WriteLine($"{n1} {n2} {n3} {n4} {n5}");