/// CORSO: SWD_25-27
/// PROGRAMMAZIONE .NET FRAMEWORK / C#
/// QUERIO SAMUELE
/// 27/04/2026

namespace Querio_Esercitazione1
{
	internal class CapoOfficina : Meccanico
	{
		public List<Ordine> OrdiniDaGestire { get; set; }
		public override double Tredicesima()
		{
			return Stipendio * 2;
			// TODO bonus 5% dell’importo di ogni ordine da gestire
		}

		public override string ToString()
		{
			return base.ToString();
		}
		//TODO: stampare elenco?
	}
}
