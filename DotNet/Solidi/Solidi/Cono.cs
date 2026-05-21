using System;
using System.Collections.Generic;
using System.Text;

namespace Solidi
{
	internal class Cono : Cilindro
	{
		public Cono(double altezza, double raggio, Materiale materiale) : base(altezza, raggio, materiale)
		{
		}

		public override double Volume()
		{
			return Math.PI * Math.Pow(Raggio, 2) * Altezza / 3;
		}
	}
}
