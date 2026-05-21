/*
Esercizio - CharToInt
Dato in input un numero, visualizzare il carattere corrispondente in ASCII standard
*/

Console.Write("Digita un numero intero da tastiera [32 - 127]: ");
int posizioneAscii = int.Parse(Console.ReadLine());
char c = (char)posizioneAscii;


Console.WriteLine($"alla posizione Ascii n. {posizioneAscii} corrisponde il carattere {c}");

