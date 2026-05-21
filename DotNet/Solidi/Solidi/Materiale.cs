using System;
using System.Collections.Generic;
using System.Text;

namespace Solidi
{
	internal class Materiale
	{
		public TipoMateriale Denominazione { get; set; }
		public double PesoSpecifico { get; set; }

		public override string ToString()
		{
			return $"Materiale={Denominazione.ToString()}, {nameof(PesoSpecifico)}={PesoSpecifico.ToString()}";
		}
	}
}
