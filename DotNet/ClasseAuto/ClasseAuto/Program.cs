namespace ClasseAuto
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");

			Auto auto1 = new Auto();
			auto1.Modello = "Panda";
			auto1.Marca = "Fiat";
			auto1.Carburante = Tipocarburante.GPL;
			auto1.Cilindrata = 1200;

			Auto auto2 = new Auto()
			{
				Marca = "BMW",
				Modello = "X5",
				Cilindrata = 2000,
				Carburante = Tipocarburante.DIESEL,
				Colore = "Nero"
			};

			Console.WriteLine(auto1.formatLineare());
			Console.WriteLine(auto2.formatDettaglio());
		}
	}
}
