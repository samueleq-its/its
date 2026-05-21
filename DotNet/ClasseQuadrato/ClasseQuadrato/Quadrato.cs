using System.Security.Cryptography.X509Certificates;

namespace ClasseQuadrato
{
	internal class Quadrato
	{
		// caratteristiche
		public double lato;



		// azioni - funzionalità
		public double Perimetro()
		{
			return lato * 4;
		}

		public double Area()
		{
			return Math.Pow(lato, 2);
		}

		public double Diagonale()
		{
			return lato * Math.Sqrt(2);
		}

	}
}
