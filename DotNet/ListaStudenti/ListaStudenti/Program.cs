using System.Reflection.Metadata.Ecma335;

namespace ListaStudenti
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Lista Studenti");

			List<Studente> elenco = new List<Studente>() {
				new Studente(){Matricola=12346,Nome="Diego", Cognome="De Lillo", Email="diego.delillo@its.net", Classe="Mobile Developer"},
				new Studente(){Matricola=12356,Nome="Marta", Cognome="De Paoli", Email="marta.depaoli@its.net", Classe="Mobile Developer"},
				new Studente(){Matricola=12126,Nome="Carlo", Cognome="De Carlo", Email="carlo.decarlo@its.net", Classe="Mobile Developer"},
				new Studente(){Matricola=12345,Nome="Pietro", Cognome="De Lillo", Email="pietro.delillo@its.net", Classe="Cloud Specialist"},
				new Studente(){Matricola=12350,Nome="Laura", Cognome="De Paoli", Email="laura.depaoli@its.net", Classe="Backend Developer"},
				new Studente(){Matricola=12121,Nome="Giulia", Cognome="De Carlo", Email="giulia.decarlo@its.net", Classe="Cloud Specialist"},
				new Studente(){Matricola=11123,Nome="Roberto", Cognome="Di Freud", Email="roberto.difreud@its.net", Classe="Backend Developer"},
				new Studente(){Matricola=10256,Nome="Andrea", Cognome="Di Leo", Email="andrea.dileo@its.net", Classe="Cloud Specialist"},
				new Studente(){Matricola=11345,Nome="Laura", Cognome="De Laurentis", Email="laura.delaurentis@its.net", Classe="Backend Developer"},
				new Studente(){Matricola=11350,Nome="Laura", Cognome="De Giovanni", Email="laura.degiovanni@its.net", Classe="Cloud Specialist"},
				new Studente(){Matricola=10121,Nome="Roberto", Cognome="Vigna", Email="roberto.vigna@its.net", Classe="Cloud Specialist"},
				new Studente(){Matricola=13123,Nome="Roberto", Cognome="Di Pinto", Email="roberto.dipinto@its.net", Classe="Backend Developer"},
				new Studente(){Matricola=11256,Nome="Andrea", Cognome="Scotto", Email="andrea.scotto@its.net", Classe="Cloud Specialist"}
			};

			string menu = "1. Stampa Elenco" +
			"\n2. Cerca studente da matricola" +
			"\n3. Cerca studenti con cognome uguale" +
			"\n4. Cerca studenti per classe" +
			"\n0. Esci" +
			"\n\nPremi il numero corrispondente all'opzione scelta: ";

			while (true)
			{

				Console.Write(menu);
				int choice = int.Parse(Console.ReadKey().KeyChar.ToString()); // si rompe se non è int
				Console.Clear();
				switch (choice)
				{
					case 1:
						StampaElenco(elenco);
						break;
					case 2:
						Console.Write("inserisci il numero di matricola da cercare: ");
						int matricola = int.Parse(Console.ReadLine()); // si rompe se non è int
						DettaglioDaMatricola(elenco, matricola); // si rompe se matricola non ce?
						break;
					case 3:
						Console.Write("inserisci il cognome da cercare: ");
						string cognome = Console.ReadLine(); // si rompe
						StampaFiltraCognome(elenco, cognome);
						break;
					case 4:
						Console.Write("inseriscila classe da visualizzare: ");
						string classe = Console.ReadLine(); // si rompe
						StampaFiltraClasse(elenco, classe);
						break;
					case 0: return;
					default: { Console.WriteLine("opzione non valida"); break; }
				}
				Console.WriteLine("\n\nPremi un tasto per continuare...");
				Console.ReadKey();
				Console.Clear();
			}


		}

		public static void StampaElenco(List<Studente> studenti)
		{
			Console.WriteLine("Elenco Studenti:");
			foreach (var item in studenti)
			{
				Console.WriteLine(item);
			}
		}

		public static void DettaglioDaMatricola(List<Studente> studenti, int matricola)
		{
			Console.WriteLine($"{studenti.Find(x => x.Matricola == matricola)}");
		}

		public static void StampaFiltraCognome(List<Studente> studenti, string cognome)
		{
			studenti.ForEach(x =>
			{
				if (x.Cognome == cognome) { Console.WriteLine(x); }
			});
		}

		public static void StampaFiltraClasse(List<Studente> studenti, string classe)
		{
			studenti.ForEach(x =>
			{
				if (x.Classe == classe) { Console.WriteLine(x); }
			});
		}
	}
}
