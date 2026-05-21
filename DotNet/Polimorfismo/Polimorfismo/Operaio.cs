using System;
using System.Collections.Generic;
using System.Text;

namespace Polimorfismo
{
	internal class Operaio : Dipendente
	{
		public TipoSettore Settore { get; set; }

		public override double Stipendio()
		{
			return base.Stipendio() + (Settore == TipoSettore.INSTALLATORE? 185 : 230 /* MANUTENTORE */ );
		}

		public override string FormatStampa(string separatore)
		{
			return base.FormatStampa(separatore) + 
			$"{separatore}{nameof(Settore)}={Settore}";
		}
	}
}
