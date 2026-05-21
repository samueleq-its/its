namespace ClasseAuto
{
	internal class Auto
	{
		//attributi marca, modello, cilindrata, carburante, colore

		//proprietà
		private string marca;
		public string Marca
		{
			get { return marca; }
			set { marca = value; }
		}

		private string modello;
		public string Modello
		{
			get { return modello; }
			set { modello = value; }
		}

		private Tipocarburante carburante;
		public Tipocarburante Carburante
		{
			get { return carburante; }
			set { carburante = value; }
		}

		private int cilindrata;
		public int Cilindrata
		{
			get { return cilindrata; }
			set { cilindrata = value; }
		}

		private string colore;
		public string Colore
		{
			get { return colore; }
			set { colore = value; }
		}

		//metodo
		public int VelocitaMax()
		{
			int v = cilindrata / 10;

			switch (carburante)
			{
				case Tipocarburante.BENZINA: v += 30; break;
				case Tipocarburante.DIESEL: v += 20; break;
				case Tipocarburante.GPL: v -= 10; break;
				case Tipocarburante.METANO: v -= 30; break;
			}

			return v;
		}

		//metodi usa e getta
		public string formatLineare()
		{
			return $"marca={marca}" +
				$" modello={modello}" +
				$" cilindrata={cilindrata}" +
				$" carburante={carburante}" +
				$" colore={colore}" +
				$" velocita' max={VelocitaMax()}"
				;
		}

		public string formatDettaglio()
		{
			return $"marca={marca}" +
				$"modello={modello}" +
				$"\ncilindrata={cilindrata}" +
				$"\ncarburante={carburante}" +
				$"\ncolore={colore}" +
				$"\nvelocita' max={VelocitaMax()}"
				;
		}

	}
}
