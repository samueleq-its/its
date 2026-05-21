using System;
using System.Collections.Generic;
using System.Text;

namespace QuadrilateriEquivalenti
{
	internal class Quadrato : Rettangolo
	{
		public Quadrato(double lato) : base(lato, lato) {}

		public override string ToString()
		{
			return $"{GetType().Name}: Lato={lato1.ToString()}, Perimetro={Perimetro().ToString()}, Area={Area().ToString()}, Diagonale={Diagonale().ToString()}";
		}
	}
}
