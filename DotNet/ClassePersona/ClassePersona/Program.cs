namespace ClassePersona
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");

			Persona p1 = new Persona();
			Persona p2 = new Persona("Mario", "Rossi");
			Persona p3 = new Persona("Luigi", "Verdi", new DateTime(1990, 1, 1), "Roma");
			Persona p4 = new Persona("Giulia", "Bianchi", new DateTime(1995, 5, 20), "Milano", Sesso.FEMMINA);

			Console.WriteLine(p1.Stampa());
			Console.WriteLine(p2.Stampa());
			Console.WriteLine(p3.Stampa());
			Console.WriteLine(p4.Stampa());
		}
	}
}
