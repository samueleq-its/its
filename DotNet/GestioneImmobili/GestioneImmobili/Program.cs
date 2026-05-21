namespace GestioneImmobili
{
	internal class Program
	{
		static void Main(string[] args)
		{
         int scelta;

			do
			{
				Console.WriteLine("Gestione Immobili");
				Console.WriteLine("1. Visualizzazione del numero di immobili");
				Console.WriteLine("2. Visualizzazione dell'elenco degli immobili");
				Console.WriteLine("3. Visualizzazione dell'elenco di appartamenti");
				Console.WriteLine("4. Visualizzazione dell'elenco delle ville");
				Console.WriteLine("5. Visualizzazione dell'elenco dei box");
				Console.WriteLine("6. Visualizzazione dell'elenco degli immobili ubicati in una certa citta'");
				Console.WriteLine("7. Visualizzazione della scheda di dettaglio di un certo immobile individuato tramite codice");
				Console.WriteLine("8. Produzione di un elenco degli immobili su file csv");
				Console.WriteLine("9. Termina il programma");
				Console.Write("Seleziona un'opzione: ");

				if (!int.TryParse(Console.ReadLine(), out scelta))
				{
					Console.WriteLine("Scelta non valida.");
					continue;
				}

				switch (scelta)
				{
					case 1:
						Console.WriteLine("Opzione non implementata.");
						break;
					case 2:
						Console.WriteLine("Opzione non implementata.");
						break;
					case 3:
						Console.WriteLine("Opzione non implementata.");
						break;
					case 4:
						Console.WriteLine("Opzione non implementata.");
						break;
					case 5:
						Console.WriteLine("Opzione non implementata.");
						break;
					case 6:
						Console.WriteLine("Opzione non implementata.");
						break;
					case 7:
						Console.WriteLine("Opzione non implementata.");
						break;
					case 8:
						Console.WriteLine("Opzione non implementata.");
						Console.WriteLine("File disponibili: ElencoBox.csv | ElencoVille.csv | ElencoAppartamenti.csv");
						Console.Write("Inserisci il nome del file: ");
						var nomeFile = Console.ReadLine();
						Console.Write("Inserisci la data: ");
						var data = Console.ReadLine();
						Console.WriteLine($"Richiesta acquisita per {nomeFile} in data {data}.");
						break;
					case 9:
						Console.WriteLine("Terminazione programma.");
						break;
					default:
						Console.WriteLine("Scelta non valida.");
						break;
				}

				if (scelta != 9)
				{
					Console.WriteLine();
				}
			}
			while (scelta != 9);
		}
	}
}
