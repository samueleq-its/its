namespace ClasseProdotto
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Esercizio Prodotti");

			Prodotto prod1 = new Prodotto()
			{
				Codice = 1,
				Denominazione = "RTX-5090",
				Descrizione = "Scheda Video Incendiaria",
				Prezzo = 4285.99,
				Giacenza = 5,
			};

			Prodotto prod2 = new Prodotto()
			{
				Codice = 2,
				Denominazione = "Ram-Corsair-16GB",
				Descrizione = "Ram da 16 GB DDR4 3200 MHz",
				Prezzo = 114.00,
				Giacenza = 0,
			};

			Console.WriteLine(prod1.StampaLineare());
			Console.WriteLine(prod2.StampaDettaglio());
		}
	}
}
