namespace Prodotti
{
	internal class NonAlimentare:Prodotto
	{
		public string Materiale { get; set; }

		public override string ToString()
		{
			return base.ToString() + $"{{{nameof(Materiale)}={Materiale}}}";
		}
	}
}
