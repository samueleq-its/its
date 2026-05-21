namespace GestioneImmobili
{
	internal class Appartamento : Immobile
	{
		public int NumVani { get; set; }
		public int NumBagni { get; set; }

		public Appartamento(string codice, string indirizzo, string cap, string citta, int superfice, double prezzo, int numVani, int numBagni) : base(codice, indirizzo, cap, citta, superfice, prezzo)
		{
			NumVani = numVani;
			NumBagni = numBagni;
		}

		public override string ToString()
		{
			return base.ToString() + $"{nameof(NumVani)}={NumVani.ToString()}, {nameof(NumBagni)}={NumBagni.ToString()}";
		}
	}
}
