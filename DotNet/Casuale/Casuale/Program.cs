/*
 generare un numero casuale
*/

Console.WriteLine("Lancio di un D6");

Random rng = new Random();

int casuale = rng.Next();
int dado = casuale % 6 + 1;

Console.WriteLine($"Dado: {dado}");