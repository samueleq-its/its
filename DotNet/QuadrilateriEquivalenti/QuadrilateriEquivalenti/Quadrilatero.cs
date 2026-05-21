namespace QuadrilateriEquivalenti
{
	internal abstract class Quadrilatero
	{

		protected double lato1;
		protected double lato2;
		private double lato3;
		private double lato4;

		public Quadrilatero(double lato1, double lato2, double lato3, double lato4)
		{
			this.lato1 = lato1;
			this.lato2 = lato2;
			this.lato3 = lato3;
			this.lato4 = lato4;
		}

		public double Perimetro()
		{
			return lato1 + lato2 + lato3 + lato4;
		}

		public abstract double Area();

		public bool isEquivalente(Quadrilatero other)
		{
			return this.Area() == other.Area();
		}

		public override string ToString()
		{
			return $"{GetType().Name}: {nameof(lato1)}={lato1.ToString()}, {nameof(lato2)}={lato2.ToString()}, {nameof(lato3)}={lato3.ToString()}, {nameof(lato4)}={lato4.ToString()}, Perimetro={Perimetro()}";
		}
	}
}
