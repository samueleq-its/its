/// CORSO: SWD_25-27
/// PROGRAMMAZIONE .NET FRAMEWORK / C#
/// QUERIO SAMUELE
/// 27/04/2026

namespace Querio_Esercitazione1
{
	internal abstract class Persona
	{
		public string Nome { get; set; }
		public string Cognome { get; set; }
		public double Stipendio { get; set; }

		public abstract double Tredicesima();

		public override string ToString()
		{
			return $"{nameof(Nome)}={Nome}" +
			$", {nameof(Cognome)}={Cognome}" +
			$", {nameof(Stipendio)}={Stipendio}" +
			$", {nameof(Tredicesima)}={Tredicesima()}";
		}
	}
}
