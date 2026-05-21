using System;
using System.Collections.Generic;
using System.Text;

namespace Polimorfismo
{
	internal abstract class Dipendente
	{
		public string Cognome { get; set; }
		public string Nome { get; set; }
		public int OreLavorate { get; set; }
		public double PagaOraria { get; set; }

		public virtual string FormatStampa(string separatore)
		{
			return $"{GetType().Name}" +
				$"{separatore}{nameof(Cognome)}={Cognome}" +
				$"{separatore}{nameof(Nome)}={Nome}" +
				$"{separatore}{nameof(OreLavorate)}={OreLavorate.ToString()}" +
				$"{separatore}{nameof(PagaOraria)}={PagaOraria.ToString()}" +
				$"{separatore}{nameof(Stipendio)}={Stipendio().ToString()}"
				;
		}

		public string Dettaglio()
		{
			return FormatStampa("\n");
		}

		public virtual double Stipendio()
		{
			return OreLavorate * PagaOraria;
		}

		public override string ToString()
		{
			return FormatStampa(", ");
		}
	}
}
