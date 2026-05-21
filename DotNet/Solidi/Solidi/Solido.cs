using System;
using System.Collections.Generic;
using System.Text;

namespace Solidi
{
	internal abstract class Solido
	{
	public Materiale Materiale { get; set; }

		public Solido(Materiale materiale)
		{
			Materiale = materiale;
		}

		public abstract double Volume();

		public double Peso() {
			return Volume() * Materiale.PesoSpecifico;
		}

		public override string ToString()
		{
			return $"{GetType().Name}:{Materiale.ToString()}" +
			$", Volume={Volume()} dm^3" +
			$", Peso={Peso()} Kg"
			;
		}
	}
}
