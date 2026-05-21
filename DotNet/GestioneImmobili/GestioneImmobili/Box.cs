namespace GestioneImmobili
{
	internal class Box : Immobile
	{
		public int PostiAuto { get; set; }

		public Box(string codice, string indirizzo, string cap, string citta, int superfice, double prezzo, int postiAuto) : base(codice, indirizzo, cap, citta, superfice, prezzo)
		{
			PostiAuto = postiAuto;
		}

		public override string ToString()
		{
			return base.ToString() + $"{nameof(PostiAuto)}={PostiAuto.ToString()}";

		}
	}
}
