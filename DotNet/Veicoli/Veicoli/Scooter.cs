using System;
using System.Collections.Generic;
using System.Text;

namespace Veicoli
{
	internal class Scooter:Veicolo
	{
		public int NumRuote {  get; set; }
		public Scooter(int numRuote, string marca, string modello, Tipocarburante carburante, int cilindrata, string colore) : base(marca, modello, carburante, cilindrata, colore)
		{
			NumRuote = numRuote;
		}

		public override string ToString()
		{
			return base.ToString() + $"{{{nameof(NumRuote)}={NumRuote.ToString()}}}";
		}
	}
}
