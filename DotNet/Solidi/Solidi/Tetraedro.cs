using System;
using System.Collections.Generic;
using System.Text;

namespace Solidi
{
	internal class Tetraedro : Cubo
	{
		public Tetraedro(double lato, Materiale materiale) : base(lato, materiale)
		{
		}

		public override double Volume()
		{
			return Math.Pow(Lato, 3) * Math.Sqrt(2) / 12;
		}

		public override string ToString()
		{
			return base.ToString() +
			$", {nameof(Lato)}={Lato.ToString()}";
		}
	}
}
