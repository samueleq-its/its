/// CORSO: SWD_25-27
/// PROGRAMMAZIONE .NET FRAMEWORK / C#
/// QUERIO SAMUELE
/// 27/04/2026

namespace Querio_Esercitazione1
{
	internal sealed class Ordine
	{
		public string CodiceOrdine { get; set; } //TODO: generato, lunghezza 8 caratteri fissi, univoco
		public DateTime Data { get; set; }
		public List<(Prodotto prodotto, int quantita)> ElencoProdotti { get; set; }
		public Venditore Venditore { get; set; }

		public Ordine(string codiceOrdine, DateTime data, List<(Prodotto prodotto, int quantita)> elencoProdotti, Venditore venditore)
		{
			CodiceOrdine = codiceOrdine;
			Data = data;
			ElencoProdotti = elencoProdotti;
			Venditore = venditore;
		}

		public int NumeroProdotti()
		{
			return ElencoProdotti.Count;
		}

		public double Totale()
		{
			double totale = 0;
			ElencoProdotti.ForEach(item =>
			{
				totale += item.prodotto.Prezzo * item.quantita;
			});
			return totale;
		}

		public void StampaOrdine()
		{
			string path = "../../../";
			StreamWriter sw = new StreamWriter(path + CodiceOrdine + ".txt");

			string testo = ToString();
			ElencoProdotti.ForEach(item =>
			{
				testo += "\n" + item.prodotto.ToString() + ", Quantità=" + item.quantita + ", Subtotale=" + (item.prodotto.Prezzo * item.quantita);
			});

			sw.WriteLine(testo);
			sw.Close();


		}


		public override string ToString()
		{
			return $"{nameof(CodiceOrdine)}={CodiceOrdine}" +
			$", {nameof(Data)}={Data}" +
			$", {nameof(Venditore)}={Venditore}" +
			$", {nameof(Totale)}={Totale()}"
			//$", {nameof(ElencoProdotti)}={ElencoProdotti}"
			;
		}
		//TODO: verificare stampa elenco prodotti
	}
}
