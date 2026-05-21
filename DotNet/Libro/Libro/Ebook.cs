namespace LibroAutoriEditore
{
	internal class Ebook:Libro
	{
		public double DimensioneMB { get; set; }

		public override string StampaDettaglio()
		{
			return base.StampaDettaglio()
			+ $",\nDimensione MB = {DimensioneMB}"
			;
		}
	}
}
