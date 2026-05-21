namespace GestioneImmobili
{
	internal class Villa : Appartamento
	{
		public int SuperficieGiardino { get; set; } // m^3

		public Villa(string codice, string indirizzo, string cap, string citta, int superfice, double prezzo, int numVani, int numBagni, int superficieGiardino) : base(codice, indirizzo, cap, citta, superfice, prezzo, numVani, numBagni)
		{
			SuperficieGiardino = superficieGiardino;
		}

		public override string ToString()
		{
			return base.ToString() + $"{nameof(SuperficieGiardino)}={SuperficieGiardino.ToString()}";
		}
	}
}
