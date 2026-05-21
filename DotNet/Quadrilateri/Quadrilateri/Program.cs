namespace Quadrilateri
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Qudralateri!");


			Quadrilatero q1 = new Quadrilatero(1.5, 2.3, 3.2, 1.7);
			Console.WriteLine(q1);
			
			Quadrilatero q2 = new Rettangolo(1.5, 2.5);
			Console.WriteLine(q2);

			Quadrilatero q3 = new Quadrato(1.5);
			Console.WriteLine(q3);
			

		}
	}
}
