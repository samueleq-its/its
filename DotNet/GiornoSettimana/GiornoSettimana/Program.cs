/* Dato in input un numero intero appartenente all'intervallo [1,7]
 * visualizzare il corrispondente nome del giorno della settiamna 
 * 1 => Lunedi
 * ...
 * 7 => Domenica
 * 
 * qualsiasi altro valore => errore
 * 
 * implementare con SWITCH/CASE */

Console.Write("n: ");
int n = int.Parse(Console.ReadLine());

string msg = string.Empty;
switch (n)
{
	case 1:
		msg = "Lunedì";
		break;
	case 2:
		msg = "Martedì";
		break;
	case 3:
		msg = "Mercoledì";
		break;
	case 4:
		msg = "Giovedì";
		break;
	case 5:
		msg = "Venerdì";
		break;
	case 6:
		msg = "Sabato";
		break;
	case 7:
		msg = "Domenica";
		break;
	default:
		msg = "Errore";
		break;
}

Console.Write(msg);