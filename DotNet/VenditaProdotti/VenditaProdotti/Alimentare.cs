namespace Prodotti
{
	internal class Alimentare:Prodotto
	{
		public DateTime Scadenza { get; set; }

		public override string ToString()
		{
			return base.ToString() + $"{nameof(Scadenza)}={Scadenza.ToString()}";
		}
	}
}
