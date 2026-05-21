/// CORSO: SWD_25-27
/// PROGRAMMAZIONE .NET FRAMEWORK / C#
/// QUERIO SAMUELE
/// 27/04/2026

namespace Querio_Esercitazione1
{
	internal class Venditore : Persona, ICloneable
	{
		public TipoSettore Settore { get; set; }

		public override double Tredicesima()
		{
			return Stipendio * 1.91;
		}
		public object Clone()
		{
			return new Venditore
			{
				Cognome = this.Cognome,
				Nome = this.Nome,
				Stipendio = this.Stipendio,
				Settore = this.Settore
			};
		}

		public override string ToString()
		{
			return base.ToString() + ", " +
			$"{nameof(Settore)}={Settore}";
		}
	}
}
