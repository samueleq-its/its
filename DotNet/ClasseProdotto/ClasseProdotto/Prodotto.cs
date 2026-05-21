/*
Esercizio - ClasseProdotto
Di un prodotto si conoscono le seguenti caratteristiche: codice di tipo numerico, denominazione di tipo stringa, 
descrizione di tipo stringa, prezzo di tipo double, giacenza di tipo intero (scorta a magazzino).
Si richiede la possibilità di sapere se un prodotto è in scorta ovvero se la sua giacenza è compresa tra 1 e 9 pezzi
oppure se il prodotto è esaurito ovvero la giacenza è pari a zero.
Si vuole anche avere due metodi per formattare l'output di stampa del prodotto.
I due metodi sono StampaLineare e StampaDettaglio.
Istanziare due oggetti di tipo Prodotto nel main della classe Program e utilizzare per uno dei due metodi di stampa proposti per i due prodotti.
*/

namespace ClasseProdotto
{
	internal class Prodotto
	{
		public int Codice { get; set; }
		public string Denominazione { get; set; }
		public string Descrizione { get; set; }
		public double Prezzo { get; set; }
		public int Giacenza { get; set; }

		public bool IsScorta()
		{
			return Giacenza >= 1 && Giacenza <= 9;
		}

		public bool IsEsaurito()
		{
			return Giacenza <= 0;
		}

		public string StampaLineare()
		{
			return Stampa(" ");
		}

		public string StampaDettaglio()
		{
			return Stampa("\n");
		}

		public string Stampa(string separatore){
			return $"Codice:{Codice}" +
				$"{separatore}Denominazione: {Denominazione}" +
				$"{separatore}Descrizione: {Descrizione}" +
				$"{separatore}Prezzo {Prezzo}€" +
				$"{separatore}Giacenza: {Giacenza}" +
				$"{separatore}Stato: {(IsEsaurito() ? "ESAURITO" : IsScorta() ? "SCORTA" : "")}"
				;
		}

		public override string ToString()
		{
			return $"{{{nameof(Codice)}={Codice.ToString()}, {nameof(Denominazione)}={Denominazione}, {nameof(Descrizione)}={Descrizione}, {nameof(Prezzo)}={Prezzo.ToString()}, {nameof(Giacenza)}={Giacenza.ToString()}}}";
		}
	}
}
