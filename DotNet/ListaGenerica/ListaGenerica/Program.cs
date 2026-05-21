using System.Collections.Generic;

namespace ListaGenerica
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Lista Generica!");

			List<object> lista = new List<object>();

			Console.WriteLine($"Elementi Trovati: {lista.Count}");

			lista.Add(1);
			lista.Add(-7);
			lista.Add(17);
			lista.Add(1.25);
			lista.Add(-2.25f);
			lista.Add("Pino");
			lista.Add("Stringa piu corposa");
			lista.Add("Pitonico");
			lista.Add("Fantastico");
			lista.Add(true);

			Console.WriteLine($"Elementi Trovati: {lista.Count}");

			// lista.ForEach(x => Console.WriteLine(x));
			foreach (var item in lista)
			{
				Console.WriteLine(item);
			}

			foreach (var item in lista)
			{
				if (item is string s)
				{
					Console.WriteLine(s);
				}
			}

			// aggiungere un elemento numero reale in posizione 4
			double r = 11.45;
			lista.Insert(4, r);
			Console.WriteLine($"elemento {r} aggiunto in posizione 4");

			foreach (var item in lista)
			{
				Console.WriteLine(item);
			}

			// eliminazione elemento in posizione 4
			lista.RemoveAt(4); // rimuove l'elemento alla posiione 4
			lista.Remove(r); // rimuove l'elemento con quel valore
			Console.WriteLine("rimossolo l'elemento 4");

			foreach (var item in lista)
			{
				Console.WriteLine(item);
			}
		}
	}
}
