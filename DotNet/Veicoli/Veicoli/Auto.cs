namespace Veicoli
{
	internal class Auto : Veicolo
	{
		public int NumPorte { get; set; }
		public TipoCambio TipoCambio { get; set; }

		public Auto(int numPorte, TipoCambio tipoCambio, string marca, string modello, Tipocarburante carburante, int cilindrata, string colore) : base(marca, modello, carburante, cilindrata, colore)
		{
			NumPorte = numPorte;
			TipoCambio = tipoCambio;
		}

		public override string ToString()
		{
			return base.ToString() + $"{{{nameof(NumPorte)}={NumPorte}, {nameof(TipoCambio)}={TipoCambio}}}";
		}

	}
}
