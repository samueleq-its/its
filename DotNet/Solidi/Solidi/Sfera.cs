using System;
using System.Collections.Generic;
using System.Text;

namespace Solidi
{
	internal class Sfera : Solido
	{
		public double Raggio { get; set; }

		public Sfera(Double raggio, Materiale materiale) : base(materiale)
		{
		this.Raggio = raggio;
		}

		public override double Volume()
		{
			return Math.Pow(Raggio, 3) * Math.PI * 4 / 3;
		}

		public override string ToString()
		{
			return base.ToString() +
			$", {nameof(Raggio)}={Raggio.ToString()}";
		}
	}
}
