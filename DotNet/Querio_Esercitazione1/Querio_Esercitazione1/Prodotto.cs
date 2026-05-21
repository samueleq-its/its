/// CORSO: SWD_25-27
/// PROGRAMMAZIONE .NET FRAMEWORK / C#
/// QUERIO SAMUELE
/// 27/04/2026

namespace Querio_Esercitazione1
{
	internal class Prodotto
	{
		public string Codice { get; set; }
		public string NomeProdotto { get; set; }
		public string Descrizione { get; set; }
		public double Prezzo { get; set; }

		public override string ToString()
		{
			return $"{{{nameof(Codice)}={Codice}, {nameof(NomeProdotto)}={NomeProdotto}, {nameof(Descrizione)}={Descrizione}, {nameof(Prezzo)}={Prezzo.ToString()}}}";
		}
	}
}
