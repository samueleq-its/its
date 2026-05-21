// dati in input dividendo e divisore di tipo intero
// calcolare il quoziente intero, il resto , il quoziente reale
// visualizzare i risultati

// input
int dividendo, divisore, qi, r;
double qr;

Console.Write("Dividendo: ");
dividendo = int.Parse(Console.ReadLine());

Console.Write("Divisore: ");
divisore = int.Parse(Console.ReadLine());

// calcoli
qi = dividendo / divisore;
r = dividendo % divisore;
qr = (double)dividendo / divisore;

// output
string msg = $"Risultati:" +
	$"\n quoziente intero = {qi}" +
	$"\n resto = {r}" +
	$"\n quoziente reale = {qr}";

Console.WriteLine(msg);