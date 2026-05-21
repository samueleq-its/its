namespace Prodotti
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Prodotti!");

			Prodotto[] ElencoProdotti = [
				new Alimentare(){
					Nome = "Pizza",
					Scadenza = new DateTime(2026,04,06)
				},
				new Alimentare(){
					Nome = "Gelato",
					Scadenza = new DateTime(2026,04,10)
				},
				new Alimentare(){
					Nome = "Yogurt",
					Scadenza = new DateTime(2026,05,02)
				},
				new NonAlimentare(){
					Nome = "Carta igienica",
					Materiale = "carta"
				},
				new NonAlimentare(){
					Nome = "Penna",
					Materiale = "plastica"
				}
			];


			foreach (Prodotto prodotto in ElencoProdotti)
			{
				Console.WriteLine(prodotto.ToString());
			}
		}
	}
}
