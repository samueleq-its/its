using System;
using System.Collections.Generic;
using System.Text;

namespace Polimorfismo
{
	internal class Amministrativo : Dipendente
	{
		public TipoMansione Mansione;

		public override double Stipendio()
		{
			return base.Stipendio() + (Mansione == TipoMansione.CONTABILE ? 150 : Mansione == TipoMansione.RISORSEUMANE ? 75 : 250 /* DIRETTORE */);
		}

		public override string FormatStampa(string separatore)
		{
			return base.FormatStampa(separatore) +
				$"{separatore}{nameof(Mansione)}={Mansione}";
		}

	}
}
