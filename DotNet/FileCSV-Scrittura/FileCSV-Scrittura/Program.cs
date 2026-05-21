namespace FileCSV_Scrittura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Scrittura su file CSV!");

            //creare oggetto Persona
            var p = new Persona();

            //inizializzazione dell'oggetto
            Console.Write("Cognome: ");
            p.Cognome = Console.ReadLine();
            Console.Write("Nome: ");
            p.Nome = Console.ReadLine();
            Console.Write("Data di nascita [gg/mm/aaaa]: ");
            p.DataNascita = DateTime.Parse(Console.ReadLine());
            Console.Write("Luogo di nascita: ");
            p.LuogoNascita = Console.ReadLine();
            Console.Write("Sesso [0 - Altro, 1 - F, 2 - M]: ");
            p.Sesso = (Sesso)int.Parse(Console.ReadLine());

            //scrittura del dato su file csv
            string path = @"C:\Users\samuele.querio\Desktop\Persone.csv";

            StreamWriter sw = new StreamWriter(path);
            sw.Write(p.FormatStampaCSV());
            sw.Close();

            Console.WriteLine("Operazione eseguita con successo");
        }
    }
}
