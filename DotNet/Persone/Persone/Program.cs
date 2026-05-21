namespace Persone
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Persone!");

			Studente studente = new Studente()
			{
				Nome = "Samuele",
				Cognome = "Querio",
				LuogoNascita = "Carmagnola",
				DataNascita = new DateTime(1996, 06, 27),
				Sesso = Sesso.MASCHIO,
				Corso = "SWD"
			};

			Console.WriteLine(studente.ToString());

			Persona persona = new Persona()
			{
				Nome = "Samuele",
				Cognome = "Querio",
				LuogoNascita = "Carmagnola",
				DataNascita = new DateTime(1996, 06, 27),
				Sesso = Sesso.MASCHIO
			};

			Console.WriteLine(persona.ToString());

		}
	}
}
