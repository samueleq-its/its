namespace GestioneImmobili
{
	internal abstract class Immobile
	{

		public string Codice { get; set; }
		public string Indirizzo { get; set; }
		public string Cap { get; set; }
		public string Citta { get; set; }
		public int Superfice { get; set; }
		public double Prezzo { get; set; }

		protected Immobile(string codice, string indirizzo, string cap, string citta, int superfice, double prezzo)
		{
			this.Codice = codice;
			this.Indirizzo = indirizzo;
			this.Cap = cap;
			this.Citta = citta;
			this.Superfice = superfice;
			this.Prezzo = prezzo;
		}

		public override string ToString()
		{
			return $"{GetType().Name}" +
			$"{nameof(Codice)}={Codice}" +
			$", {nameof(Indirizzo)}={Indirizzo}" +
			$", {nameof(Cap)}={Cap}" +
			$", {nameof(Citta)}={Citta}" +
			$", {nameof(Superfice)}={Superfice.ToString()}" +
			$", {nameof(Prezzo)}={Prezzo.ToString()}";
		}
	}
}
