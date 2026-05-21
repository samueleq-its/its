using System.Security.Cryptography.X509Certificates;

namespace Polimorfismo
{
	internal class Program
	{


		static void Main(string[] args)
		{
			Console.WriteLine("Polimorfismo");


			List<Dipendente> dipendenti = new List<Dipendente>();

			dipendenti.Add(new Amministrativo
			{
				Nome = "Pietro",
				Cognome = "Smusi",
				PagaOraria = 20,
				OreLavorate = 160,
				Mansione = TipoMansione.DIRETTORE
			});

			dipendenti.Add(new Amministrativo
			{
				Nome = "Elena",
				Cognome = "Bianchi",
				PagaOraria = 20,
				OreLavorate = 160,
				Mansione = TipoMansione.CONTABILE
			});

			dipendenti.Add(new Amministrativo
			{
				Nome = "Alberto",
				Cognome = "Rossi",
				PagaOraria = 20,
				OreLavorate = 160,
				Mansione = TipoMansione.RISORSEUMANE
			});

			dipendenti.Add(new Operaio
			{
				Nome = "Giada",
				Cognome = "Turing",
				PagaOraria = 20,
				OreLavorate = 160,
				Settore = TipoSettore.MANUTENTORE
			});

			dipendenti.Add(new Operaio
			{
				Nome = "Antonio",
				Cognome = "Facaldo",
				PagaOraria = 20,
				OreLavorate = 160,
				Settore = TipoSettore.INSTALLATORE
			});

			dipendenti.Add(new OperaioSpecializzato
			{
				Nome = "Rebecca",
				Cognome = "Zumwalt",
				PagaOraria = 20,
				OreLavorate = 160,
				Settore = TipoSettore.INSTALLATORE,
				IndennitaMissione = 200,
				NumeroMissioni = 2
			});

			dipendenti.Add(new OperaioSpecializzato
			{
				Nome = "Timothée ",
				Cognome = "Chalamet",
				PagaOraria = 20,
				OreLavorate = 160,
				Settore = TipoSettore.MANUTENTORE,
				IndennitaMissione = 150,
				NumeroMissioni = 3
			});

			string menu = "1. Visualizzare l'elenco dei dipendenti con tutti i loro dati" +
			"\n2. Visualizzare l'elenco degli amministrativi" +
			"\n3. Visualizzare l'elenco degli operai" +
			"\n4. Visualizzare l'elenco degli operai specializzati" +
			"\n5. Visualizzare l'elenco degli operai che hanno stipendio superiore a 2000,00 euro" +
			"\n6. Visualizzare l'elenco degli operai manutentori" +
			"\n7. Visualizzare la scheda in dettaglio del direttore amministrativo" +
			"\n8. Visualizzare il totale degli stipendi da pagare" +
			"\n0. Uscire dal programma" +
			"\nInserisci il numero corrispondente alla scelta: ";

			while (true)
			{

				Console.WriteLine(menu);
				string choice = Console.ReadKey().KeyChar.ToString(); // eccezione se non è un numero

				Console.Clear();

				switch (choice)
				{
					case "1": MostraDipendenti(dipendenti); break;
					case "2": MostraAmministrativi(dipendenti); break;
					case "3": MostraOperai(dipendenti); break;
					case "4": MostraOperaiSpecializzati(dipendenti); break;
					case "5": MostraPagatiTroppo(dipendenti); break;
					case "6": MostraManutentori(dipendenti); break;
					case "7": MostraDirettore(dipendenti); break;
					case "8": MostraTotaleStipendi(dipendenti); break;
					case "0": return;
					default: Console.WriteLine("Opzione errata"); break;
				}

				Console.WriteLine("\n\nPremere un tasto per continuare...");
				Console.ReadKey();
				Console.Clear();
			}
		}

		public static void MostraDipendenti(List<Dipendente> dipendenti)
		{
			foreach (Dipendente dipendente in dipendenti)
			{
				Console.WriteLine(dipendente.ToString());
			}
		}
		public static void MostraAmministrativi(List<Dipendente> dipendenti)
		{
			foreach (Dipendente dipendente in dipendenti)
			{
				if (dipendente is Amministrativo)
				{
					Console.WriteLine(dipendente.ToString());
				}
			}
		}
		public static void MostraOperai(List<Dipendente> dipendenti)
		{
			foreach (Dipendente dipendente in dipendenti)
			{
				if (dipendente is Operaio)
				{
					Console.WriteLine((dipendente as Operaio).ToString());
				}
			}
		}
		public static void MostraOperaiSpecializzati(List<Dipendente> dipendenti)
		{
			foreach (Dipendente dipendente in dipendenti)
			{
				if (dipendente is OperaioSpecializzato opSpecializzato)
				{
					Console.WriteLine(opSpecializzato.ToString());
				}
			}
		}
		private const double stipendioAlto = 2000.00;
		private static void MostraPagatiTroppo(List<Dipendente> dipendenti)
		{
			dipendenti.ForEach(x =>
			{
				if (x is Operaio operaio && operaio.Stipendio() > stipendioAlto)
				{
					Console.WriteLine(operaio);
				}
			});
		}
		private static void MostraManutentori(List<Dipendente> dipendenti)
		{
			dipendenti.ForEach(x =>
			{
				if (x is Operaio operaio && operaio.Settore == TipoSettore.MANUTENTORE)
				{
					Console.WriteLine(operaio);
				}
			});
		}
		private static void MostraDirettore(List<Dipendente> dipendenti)
		{
			Console.WriteLine(dipendenti.Find(x => { return x is Amministrativo am && am.Mansione == TipoMansione.DIRETTORE; }));
		}
		private static void MostraTotaleStipendi(List<Dipendente> dipendenti)
		{
			double totale = 0;
			dipendenti.ForEach((x) => { totale += x.Stipendio(); });
			Console.WriteLine($"Totale Stipendi: {totale:0.00} Euro");
		}
	}
}
