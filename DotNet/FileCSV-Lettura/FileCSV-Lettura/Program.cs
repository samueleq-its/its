namespace FileCSV_Lettura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lettura da file CSV!");

            //scrittura del dato su file csv
            string path = @"C:\Users\samuele.querio\Desktop\Persone.csv";

            StreamReader sr = new StreamReader(path);
            string testo=sr.ReadToEnd();
            sr.Close();

            

            //split blocco testo
            string[] linee = testo.Split('\n');

            List<Persona> elenco = new List<Persona>();

            foreach (var linea in linee)
            {
                //creare oggetto Persona
                var p = new Persona();

                //split
                string[] dati = linea.Split(';');

                //configuro oggetto persona
                p.Cognome = dati[0];
                p.Nome = dati[1];
                p.DataNascita = DateTime.Parse(dati[2]);
                p.LuogoNascita = dati[3];
                switch (dati[4])
                {
                    case "ALTRO": p.Sesso = Sesso.ALTRO; break;
                    case "F": p.Sesso = Sesso.F; break;
                    case "M": p.Sesso = Sesso.M; break;
                }

                elenco.Add(p);
            }

           Console.WriteLine(string.Join("\n", elenco));

            /*
            Console.WriteLine($"Dati della persona: {p}");
            Console.WriteLine($"Età della persona: {p.Eta()}");
            */
        }
    }
}
