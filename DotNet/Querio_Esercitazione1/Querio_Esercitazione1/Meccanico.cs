/// CORSO: SWD_25-27
/// PROGRAMMAZIONE .NET FRAMEWORK / C#
/// QUERIO SAMUELE
/// 27/04/2026

namespace Querio_Esercitazione1
{
	internal class Meccanico : Persona
	{
		public Tipologia Tipologia { get; set; }
		public override double Tredicesima()
		{
			return Stipendio * 1.93;
		}

		public override bool Equals(object? other)
		{
			return (
			other is Meccanico meccanico &&
			meccanico.Nome == Nome &&
			meccanico.Cognome == Cognome &&
			meccanico.Stipendio == Stipendio &&
			meccanico.Tipologia == Tipologia
			);
		}

		public override string ToString()
		{
			return base.ToString() + ", " +
			$"{nameof(Tipologia)}={Tipologia}";
		}
	}
}
