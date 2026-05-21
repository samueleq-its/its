/// CORSO: SWD_25-27
/// PROGRAMMAZIONE .NET FRAMEWORK / C#
/// QUERIO SAMUELE
/// 27/04/2026

namespace Querio_Esercitazione1
{
	internal class ResponsabileVenditori : Venditore
	{
		public List<Venditore> venditoriSottoposti;

		private int giorniLavorativi = 26;
		private double percentualeBonus = 0.15;

		public override double Tredicesima()
		{
			double bonus = 0;
			venditoriSottoposti.ForEach(venditore =>
			{
				bonus += venditore.Stipendio / giorniLavorativi * percentualeBonus;
			});

			return Stipendio * 2 + bonus;
		}

		public override string ToString()
		{
			return base.ToString();
		}
		//TODO: stampare elenco?
	}
}
