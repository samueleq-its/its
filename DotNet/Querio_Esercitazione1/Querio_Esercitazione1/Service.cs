/// CORSO: SWD_25-27
/// PROGRAMMAZIONE .NET FRAMEWORK / C#
/// QUERIO SAMUELE
/// 27/04/2026

namespace Querio_Esercitazione1
{
	internal static class Service
	{
		public static List<Persona> Dipendenti = new List<Persona>();
		public static List<Prodotto> Prodotti = new List<Prodotto>();
		public static List<Ordine> Ordini = new List<Ordine>();

		public static Ordine CreaOrdine(DateTime data, List<(Prodotto prodotto, int quantita)> elencoProdotti, Venditore venditore)
		{
			string codiceOrdine = GeneraCodiceOrdine();
			Ordine ordine = new Ordine(codiceOrdine, data, elencoProdotti, venditore);
			return ordine;
		}


		private static string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
		private static int stringLength = 8;
		private static string GeneraCodiceOrdine()
		{
				char[] stringChars = new char[stringLength];
				var random = new Random();
			while (true)
			{
				for (int i = 0; i < stringChars.Length; i++)
				{
					stringChars[i] = chars[random.Next(chars.Length)];
				}
				string codice = new string(stringChars);
				if (!Ordini.Any(ordine => ordine.CodiceOrdine == codice))
				{
					break;
				}
			}
			return new String(stringChars);

		}
	}
}
