namespace Veicoli
{
	internal class Veicolo
	{
		//attributi marca, modello, cilindrata, carburante, colore

		//proprietà
		protected string marca;

		protected string modello;

		protected Tipocarburante carburante;

		protected int cilindrata;

		protected string colore;

		public Veicolo(string marca, string modello, Tipocarburante carburante, int cilindrata, string colore)
		{
			this.marca = marca;
			this.modello = modello;
			this.carburante = carburante;
			this.cilindrata = cilindrata;
			this.colore = colore;
		}

		public override string ToString()
		{
			return $"{{{GetType().Name}: {nameof(marca)}={marca}, {nameof(modello)}={modello}, {nameof(carburante)}={carburante.ToString()}, {nameof(cilindrata)}={cilindrata.ToString()}, {nameof(colore)}={colore}}}";
		}
	}
}
