using System.ComponentModel.Design;

namespace Prodotti
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Prodotti!");

			List<Prodotto> elencoProdotti = new List<Prodotto>()
			{
			new Alimentare(){Codice=101,Nome="Pane",DataProduzione=DateTime.Parse("2025/04/28"),Prezzo=2.45,Scadenza=DateTime.Parse("20/04/2026")},
			new Alimentare(){Codice=102,Nome="Banane",DataProduzione=DateTime.Parse("2026/02/25"),Prezzo=3.99,Scadenza=DateTime.Parse("05/05/2026")},
			new NonAlimentare(){Codice=103,Nome="Sedia",DataProduzione=DateTime.Parse("2023/06/25"),Prezzo=3.99,Materiale="Legno:100%"},
			new NonAlimentare(){Codice=121,Nome="Maglietta",DataProduzione=DateTime.Parse("2023/06/25"),Prezzo=3.99,Materiale="Cotone:25%, Sintetico:75%"}
			};

			string menu = "1. Visualizza elenco prodotti" +
			"\n2. Visualizza elenco prodotti in scadenza" +
			"\n3. Visualizza elenco materie prime del prodotto" +
			"\n0. Esci" +
			"\n\nInserisci il numero corrispondente all'opzione scelta:";

			while (true)
			{
				Console.Write(menu);
				int choice = int.Parse(Console.ReadKey().KeyChar.ToString());
				Console.Clear();

				switch (choice)
				{
					case 1: elencoProdotti.ForEach(x => Console.WriteLine(x)); break;
					case 2:
						foreach (Prodotto prodotto in elencoProdotti)
						{
							if (prodotto is Alimentare alimento && alimento.Scadenza < DateTime.Now.AddDays(10))
							{ // stampa anche quelli già scaduti
								Console.WriteLine(alimento);
							}
						}
						break;
					case 3:
						foreach (Prodotto prodotto in elencoProdotti)
						{
							if (prodotto is NonAlimentare merce)
							{
								Console.WriteLine(merce.Nome + " " + merce.Materiale);
							}
						}
						break;
					case 0: return;
					default: Console.WriteLine("Opzione errata"); break;
				}

				Console.WriteLine("\n\nPremi un tasto per continuare...");
				Console.ReadKey();
				Console.Clear();

			}
		}
	}
}
