namespace AutomaAuto
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Automa auto!");

			int limiteVelocità = 130;

			Auto auto = new Auto()
			{
				Marca = "Fiat",
				Modello = "Panda",
				Cilindrata = 1200,
				Carburante = Tipocarburante.BENZINA,
				Colore = "Grigio Topo"
			};

			int choice;
			while (true)
			{
				Console.WriteLine($"Velocità attuale: {auto.Velocita} Km/h");
				Console.Write("inserisci 1 per accellerare, 2 per rallentare, 0 per uscire: ");
				choice = int.Parse(Console.ReadLine());

				if (choice == 0) { break; }

				switch (choice)
				{
					case 0: return;
					case 1: auto.Accellera(); break;
					case 2: auto.Rallenta(); break;
					default: Console.WriteLine("opzione errata"); break;
				}


				Console.WriteLine($"Nuova velocità: {auto.Velocita} Km/h");
				if (auto.Velocita > limiteVelocità)
				{
					Console.WriteLine("Rallenta! Stai andando troppo forte");
				}
				Console.Write("Premi un tasto per continuare...");
				Console.ReadKey();
				Console.Clear();
			}
		}
	}
}
