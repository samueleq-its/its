namespace GestioneMessaggi
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Gestione Messaggi!");

			MessaggiBiz messaggibiz = new MessaggiBiz(new List<Messaggio>
			{
			new Messaggio("Samuele", "Mattia", "Top", "Python is the best", new DateTime(2026,04,20,12,35,11),Priorita.NORMALE),
			new Messaggio("Mattia", "Samuele", "Risposta", "Concordo, ottima scelta!", new DateTime(2026,04,15,12,40,00), Priorita.ALTA),
			new Messaggio("Luca", "Samuele", "Aggiornamento", "Ho completato il task richiesto.", new DateTime(2026,02,27,13,05,15), Priorita.BASSA),
			new Messaggio("Giulia", "Mattia", "Promemoria", "Ricordati la riunione di domani.", new DateTime(2026,02,01,14,10,30), Priorita.ALTA),
			new Messaggio("Andrea", "Luca", "Info", "Ti mando il documento aggiornato.", new DateTime(2026,1,30,15,22,45), Priorita.NORMALE),
			new Messaggio("Francesca", "Giulia", "Saluto", "Ciao, come stai?", new DateTime(2026,01,05,16,00,00), Priorita.BASSA),
			new Messaggio("Samuele", "Andrea", "Bug", "Ho trovato un problema nel codice.", new DateTime(2025,12,20,16,45,10), Priorita.ALTA),
			new Messaggio("Elena", "Francesca", "Conferma", "La prenotazione è andata a buon fine.", new DateTime(2025,06,27,17,15,25), Priorita.NORMALE),
			new Messaggio("Davide", "Marco", "Urgente", "Serve una risposta entro stasera.", new DateTime(2025,12,20,18,05,50), Priorita.ALTA),
			new Messaggio("Sara", "Elena", "Nota", "Ho aggiornato i dettagli nel file.", new DateTime(2025,01,20,18,30,00), Priorita.BASSA),
			new Messaggio("Paolo", "Sara", "Fine", "Ci sentiamo domani.", new DateTime(2025,02,20,19,10,05), Priorita.NORMALE),
			});

			string menu = "1. inserire un nuovo messaggio" +
			"\n2. cercare un messaggio per mittente" +
			"\n3. cercare un messaggio per destinatario" +
			"\n4. contare quanti messaggi sono stati inseriti dopo una certa data" +
			"\n5. visualizzare l'elenco dei messaggi" +
			"\n0. Esci" +
			"\n\nscegli un opzione:";

			while (true)
			{
				Console.Write(menu);
				string? scelta = Console.ReadLine();
				Console.Clear();

				switch (scelta)
				{
					case "1":
						Messaggio msg = AggiungiMessaggio();
						messaggibiz.AggiungiMessaggio(msg);
						Console.WriteLine("Messaggio aggiunto");
						break;
					case "2":
						Console.Write("digita il mittente da cercare: ");
						string mittente = Console.ReadLine();
						Console.WriteLine(string.Join('\n', messaggibiz.CercaMittente(mittente)));
						break;
					case "3":
						Console.Write("digita il destinatario da cercare: ");
						string destinatario = Console.ReadLine();
						Console.WriteLine(string.Join('\n', messaggibiz.CercaDestinatario(destinatario)));
						break;
					case "4":
						Console.Write("inserisci la data: con formato aaaa/mm/gg: ");
						DateTime data = DateTime.Parse(Console.ReadLine());
						Console.WriteLine(string.Join('\n', messaggibiz.MessaggiDopoData(data)));
						break;
					case "5":
						Console.WriteLine(string.Join('\n', messaggibiz.ElencoMessaggi));
						break;
					case "0": return;
					default: Console.WriteLine("Opzione errata"); break;
				}

				Console.Write("Premi un tasto per continuare...");
				Console.ReadKey();
				Console.Clear();

			}
		}

		static Messaggio AggiungiMessaggio()
		{
			Console.WriteLine("Inserisci il mittente");
			string mittente = Console.ReadLine();

			Console.WriteLine("Inserisci il destinatario");
			string destinatario = Console.ReadLine();

			Console.WriteLine("Inserisci l'oggetto");
			string oggetto = Console.ReadLine();

			Console.WriteLine("Inserisci il testo");
			string testo = Console.ReadLine();

			Console.Write("Inserisci la data con formato aaaa/mm/gg: ");
			string giorno = Console.ReadLine();
			Console.Write("Inserisci l'ora con formato hh:mm:ss: ");
			string ora = Console.ReadLine();
			DateTime data = DateTime.Parse(giorno + " " + ora);

			Priorita priorita;
			while (true)
			{
				Console.WriteLine("Inserisci la priorita: BASSA, NORMALE, ALTA");
				string input = Console.ReadLine().ToUpper();
				try
				{
					priorita = Enum.Parse<Priorita>(input);
					break;
				}
				catch (ArgumentException)
				{
					Console.WriteLine("Valore Errato");
				}
			}
			return new Messaggio(mittente, destinatario, oggetto, testo, data, priorita);
		}


	}
}
