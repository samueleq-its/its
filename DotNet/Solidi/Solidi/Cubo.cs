using System;
using System.Collections.Generic;
using System.Text;

namespace Solidi
{
	internal class Cubo : Solido
	{
		public double Lato { get; set; }

		public Cubo(Double lato, Materiale materiale) : base(materiale)
		{
			this.Lato = lato;
		}

		public override double Volume()
		{
			return Math.Pow(Lato,3);
		}

		public override string ToString()
		{
			return base.ToString() +
			$", {nameof(Lato)}={Lato.ToString()}";
		}
	}
}
