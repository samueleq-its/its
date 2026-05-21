using System;
using System.Collections.Generic;
using System.Text;

namespace Solidi
{
	internal class Cilindro : Solido
	{
		public double Altezza {  get; set; }
		public double Raggio { get; set; }

		public Cilindro(double altezza, double raggio, Materiale materiale) : base(materiale)
		{
			Altezza = altezza;
			Raggio = raggio;
		}

		public override double Volume()
		{
			return Math.Pow(Raggio, 2) * Math.PI * Altezza;
		}

		public override string ToString()
		{
			return base.ToString() + 
			$", {nameof(Altezza)}={Altezza.ToString()}, {nameof(Raggio)}={Raggio.ToString()}";
		}
	}
}
