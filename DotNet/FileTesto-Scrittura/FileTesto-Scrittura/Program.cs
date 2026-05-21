namespace FileTesto_Scrittura
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Scrittura su file di testo!");

			string path = @"C:\Users\samuele.querio\Desktop\Frase.txt";

			Console.Write("inserisci la frase del giorno: ");
			string frase = Console.ReadLine();

			//accesso al file di testo - modalità scrittura
			StreamWriter sw = new StreamWriter(path);

			//scrittura su file
			sw.Write(frase);

			//rilascio risorsa
			sw.Close();

			Console.WriteLine("Operazione avvenuta con successo!");
		}
	}
}
