namespace ClasseQuadrato
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Istanze di Quadrato");

			Quadrato q = new Quadrato();
			q.lato = 1.25;

			Console.WriteLine($"lato={q.lato}\nperimentro={q.Perimetro()}\narea={q.Area()}\ndiagonale={q.Diagonale()}");
		}
	}
}
