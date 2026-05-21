namespace FileTesto_Lettura
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Lettura da file di testo!");

			string path = @"C:\Users\samuele.querio\Desktop\Frase.txt";

			//accesso al file in modalità lettura
			StreamReader sr = new StreamReader(path);

			//lettura dei dati
			string frase = sr.ReadToEnd();

			//rilascio della risorsa
			sr.Close();

			Console.WriteLine($"La frase del giorno è: {frase}");
		}
	}
}
