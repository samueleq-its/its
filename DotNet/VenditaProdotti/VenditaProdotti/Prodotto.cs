using System;
using System.Collections.Generic;
using System.Text;

namespace Prodotti
{
	internal abstract class Prodotto
	{
		public string Nome {  get; set; }
		public int Codice { get; set; }
		public double Prezzo { get; set; }
		public DateTime DataProduzione { get; set; }

		public override string ToString()
		{
			return $"{nameof(Nome)}={Nome}, {nameof(Codice)}={Codice.ToString()}, {nameof(Prezzo)}={Prezzo.ToString()}, {nameof(DataProduzione)}={DataProduzione.ToString()}";
		}
	}
}
