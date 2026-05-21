/*
Esercizio - SequenzaData
Data in input una data del calendario gregoriano, verificare se è corretta.
Restituire come output: gg/mm/aaaa | errore
*/

Console.Write("inserisci in numero di un giorno: ");
int giorno = int.Parse(Console.ReadLine());
Console.Write("inserisci il numero di un mese: ");
int mese = int.Parse(Console.ReadLine());
Console.Write("inserisci un anno: ");
int anno = int.Parse(Console.ReadLine());


bool errore = false;

if (anno < 1582)
{
	//anno errato
	errore = true;
} else if (mese < 1 || mese > 12)
{
	//mese errato
	errore = true;
} else if (giorno < 1 || giorno > 31)
{
	//giorno errato
	errore= true;
} 
// non finito




Console.WriteLine($"{giorno}/{mese}/{anno}");