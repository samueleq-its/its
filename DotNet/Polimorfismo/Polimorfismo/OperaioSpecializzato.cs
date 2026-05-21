using System;
using System.Collections.Generic;
using System.Text;

namespace Polimorfismo
{
	internal class OperaioSpecializzato : Operaio
	{
		public double IndennitaMissione { get; set; }
		public int NumeroMissioni { get; set; }

		public override double Stipendio()
		{
			return base.Stipendio() + IndennitaMissione * NumeroMissioni;
		}

		public override string FormatStampa(string separatore)
		{
			return base.FormatStampa(separatore) +
			$"{separatore}{nameof(IndennitaMissione)}={IndennitaMissione}" +
			$"{separatore}{nameof(NumeroMissioni)}={NumeroMissioni}";
		}
	}
}
