/// CORSO: SWD_25-27
/// PROGRAMMAZIONE .NET FRAMEWORK / C#
/// QUERIO SAMUELE
/// 27/04/2026

namespace Querio_Esercitazione1
{
	internal class Program
	{

		static void Main(string[] args)
		{
			Console.WriteLine("Querio_Esercitazione1!");

			Meccanico meccanico = new Meccanico
			{
				Nome = "Marco",
				Cognome = "Rossi",
				Stipendio = 1800,
				Tipologia = Tipologia.MECCANICA
			};

			Venditore venditore = new Venditore
			{
				Nome = "Luca",
				Cognome = "Bianchi",
				Stipendio = 1700,
				Settore = TipoSettore.AUTO
			};

			ResponsabileVenditori responsabile = new ResponsabileVenditori
			{
				Nome = "Anna",
				Cognome = "Verdi",
				Stipendio = 2200,
				Settore = TipoSettore.MOTO,
				venditoriSottoposti = new List<Venditore> { venditore }
			};

			Prodotto prodotto1 = new Prodotto { Codice = "P001", NomeProdotto = "Filtro olio", Descrizione = "Filtro olio motore", Prezzo = 15.5 };
			Prodotto prodotto2 = new Prodotto { Codice = "P002", NomeProdotto = "Candele", Descrizione = "Set candele accensione", Prezzo = 32.0 };
			Prodotto prodotto3 = new Prodotto { Codice = "P003", NomeProdotto = "Pastiglie freno", Descrizione = "Pastiglie freno anteriori", Prezzo = 48.9 };
			Prodotto prodotto4 = new Prodotto { Codice = "P004", NomeProdotto = "Batteria", Descrizione = "Batteria 12V", Prezzo = 120.0 };
			Prodotto prodotto5 = new Prodotto { Codice = "P005", NomeProdotto = "Lampadine LED", Descrizione = "Kit lampadine LED", Prezzo = 25.0 };

			Ordine ordine = Service.CreaOrdine(DateTime.Now, new List<(Prodotto prodotto, int quantita)>
			{
				(prodotto1, 2),
				(prodotto3, 1),
				(prodotto5, 4)
			},
			venditore
			);

			Service.Ordini.Add(ordine);

			CapoOfficina capoOfficina = new CapoOfficina
			{
				Nome = "Paolo",
				Cognome = "Neri",
				Stipendio = 2400,
				Tipologia = Tipologia.CARROZZERIA,
				OrdiniDaGestire = new List<Ordine> { ordine }
			};

			Service.Dipendenti.AddRange(new Persona[] { meccanico, venditore, responsabile, capoOfficina });
			Service.Prodotti.AddRange(new Prodotto[] { prodotto1, prodotto2, prodotto3, prodotto4, prodotto5 });

			Console.WriteLine(meccanico);
			Console.WriteLine(venditore);
			Console.WriteLine(responsabile);
			Console.WriteLine(capoOfficina);
			foreach (var prodotto in Service.Prodotti)
			{
				Console.WriteLine($"{prodotto.Codice} - {prodotto.NomeProdotto} - {prodotto.Prezzo}");
			}

			ordine.StampaOrdine();
		}
	}
}
