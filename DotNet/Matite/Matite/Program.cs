
namespace Matite
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Matite!");

			Matita m1 = new Matita() { 
				Marca = "Carioca",
				Modello = "24 colori",
				Lunghezza = 18
			};

			Console.WriteLine(m1.ToString());
			m1.Tempera();
			Console.WriteLine(m1.ToString());

			MatitaConGommino mg1 = new MatitaConGommino() { 
				Marca = "BIC",
				Modello = "Evolution",
				Lunghezza = 15
			};

			Console.WriteLine(mg1.ToString());
			mg1.Tempera();
			mg1.Tempera();
			mg1.Cancella();
			Console.WriteLine(mg1.ToString());
			 
		}
	}
}
