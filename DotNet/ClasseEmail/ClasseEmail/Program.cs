namespace ClasseEmail
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Classe Email");


			Email em1 = new Email()
			{
				Da = "samuele.querio@edu-its.it",
				A = "info@ictpiemonte.it",
				Priorita = Priorita.ALTA
			};

			Email em2 = new Email()
			{
				Da = "info@ictpiemonte.it",
				A = "swd_25-27@edu-its.it",
				Cc = "info@ictpiemonte.it",
				Priorita = Priorita.BASSA,
				Data = new DateTime(2025, 2, 18)
			};

			Email em3 = new Email()
			{
				Da = "info@ictpiemonte.it",
				Bcc = "samuele.querio@edu-its.it",
				Priorita = Priorita.BASSA,
				Data = new DateTime(2025, 1, 30)
			};

			Console.WriteLine(em1);
			Console.WriteLine(em2);
			Console.WriteLine(em3);
		}
	}
}
