namespace ClasseCerchio
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");

			Cerchio c1 = new Cerchio();

			Console.Write("Raggio: ");

			c1.SetRaggio(double.Parse(Console.ReadLine())); //manca sanitizzazione

			string msg =
$@"Dati del cerchio
Raggio={c1.GetRaggio()}
Diametro={c1.Circonferenza()}
Circonferenza={c1.Circonferenza()}
Area={c1.Area()}"
;
			Console.WriteLine(msg);

		}
	}
}
