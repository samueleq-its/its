using System;
using System.Collections.Generic;
using System.Text;

namespace Solidi
{
	internal class Toro : Solido
	{
		public double RaggioToro { get; set; }
		public double RaggioTubo { get; set; }

		public Toro(double raggioToro, double raggioTubo, Materiale materiale) : base(materiale)
		{
			RaggioToro = raggioToro;
			RaggioTubo = raggioTubo;
		}

		public override double Volume()
		{
			return 2 * Math.Pow(Math.PI,2) * RaggioTubo * Math.Pow(RaggioToro, 2);
		}

		public override string ToString()
		{
			return base.ToString() +
			$", {nameof(RaggioToro)}={RaggioToro.ToString()}, {nameof(RaggioTubo)}={RaggioTubo.ToString()}";
		}
	}
}
