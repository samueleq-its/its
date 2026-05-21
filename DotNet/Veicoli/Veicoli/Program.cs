namespace Veicoli
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Veicoli!");

			Auto auto1 = new Auto(5, TipoCambio.MANUALE, "Fiat", "Panda", Tipocarburante.GPL, 1000, "Rosa");
			Console.WriteLine(auto1.ToString());
			Auto auto2 = new Auto(3, TipoCambio.AUTOMATICO, "Fiat", "500", Tipocarburante.BENZINA, 1500, "Arancione");
			Console.WriteLine(auto2.ToString());

			Scooter scooter1 = new Scooter(3, "Piaggio", "Liberti", Tipocarburante.BENZINA, 300, "Arancione");
			Console.WriteLine(scooter1.ToString());
			Scooter scooter2 = new Scooter(2, "Yamaha", "Tmax", Tipocarburante.BENZINA, 560, "Rosa");
			Console.WriteLine(scooter2.ToString());
		}
	}
}
