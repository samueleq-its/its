namespace Matite
{
	internal class MatitaConGommino : Matita
	{
		public int Gommino { get; private set; } = 10;

		public void Cancella()
		{
			if (Gommino > 0)
			{
				Gommino--;
			}
		}

		public override string ToString()
		{
			return base.ToString() + $"{{{nameof(Gommino)}={Gommino.ToString()}}}";
		}
	}
}
