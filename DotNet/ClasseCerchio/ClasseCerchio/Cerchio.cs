namespace ClasseCerchio
{
	internal class Cerchio
	{
		//attributi
		//information hiding - regola oop
		private double raggio;

		//getters e setters
		public double GetRaggio()
		{
			return raggio;
		}

		public void SetRaggio(double raggio)
		{
			if (raggio <= 0.0)
			{
				throw new Exception("ERRORE! raggio negativo o nullo");
			}
			this.raggio = raggio;
		}

		public double Diametro()
		{
			return raggio * 2;
		}

		//metodi
		public double Circonferenza()
		{
			return Diametro() * Math.PI;
		}

		public double Area()
		{
			return Math.Pow(raggio, 2) * Math.PI;
		}
	}
}