using System;
using System.Collections.Generic;
using System.Text;

namespace Quadrilateri
{
	internal class Rettangolo : Quadrilatero
	{
		public Rettangolo(double @base, double altezza) : base(@base, altezza, @base, altezza) { }
		
		public double Area() {
			return base.lato1 * base.lato2; // in questo caso base non è necessario, è messo solo per evidenziare l'ereditarieta delle proprietà (sono accessibili perchè sono public o protected)
		}

		public double Diagonale() {
			return Math.Sqrt(Math.Pow(lato1,2) + Math.Pow(lato2,2));
		}


		public override string ToString()
		{
			return $"{GetType().Name}: Base={lato1.ToString()}, Altezza={lato2.ToString()}, Perimetro={Perimetro().ToString()}, Area={Area().ToString()}, Diagonale={Diagonale().ToString()}";
		}
	}
}
