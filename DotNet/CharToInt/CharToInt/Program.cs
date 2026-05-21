/*
Esercizio - CharToInt
Dato in input un carattere, visualizzare la posizione intera corrispondente in ASCII standard
*/

/*
Console.Write("Digita un tasto da tastiera: ");
int posizioneAscii = (int)Console.Read();
Console.WriteLine(posizioneAscii);
*/

char c = char.Parse(Console.ReadLine());
int posizioneAscii = (int)c;

Console.WriteLine(posizioneAscii);