// dati in input due numeri interi, calcolare la loro somma e visualizzare il risultato

//dichiarazione variabili
int n1, n2, somma;

//input
Console.Write("n1: ");
string tmp = Console.ReadLine();
n1 = int.Parse(tmp);

Console.Write("n2: ");
tmp = Console.ReadLine();
n2 = int.Parse(tmp);

//calcoli
somma = n1 + n2;

//output
Console.WriteLine(somma);
Console.WriteLine("Somma = "+somma); // da sintassi Java
Console.WriteLine("Somma = {0}",somma); // uso i segnaposti
Console.WriteLine(n1 +"+"+ n2 +"="+ somma);
Console.WriteLine("{0}+{1}={2}", n1, n2, somma);
Console.WriteLine($"{n1}+{n2}={somma}");

