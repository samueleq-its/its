namespace Matite
{
	internal class Matita
	{
		public string Marca { get; set; }
		public string Modello { get; set; }
		public double Lunghezza { get; set; } = 20;

		public void Tempera()
		{
			Lunghezza -= 0.5;
			// cosa fare se lunghezza == 0?
		}

		public override string ToString()
		{
			return $"{{{GetType().Name}:{nameof(Marca)}={Marca}, {nameof(Modello)}={Modello}, {nameof(Lunghezza)}={Lunghezza.ToString()}}}";
		}
	}
}
