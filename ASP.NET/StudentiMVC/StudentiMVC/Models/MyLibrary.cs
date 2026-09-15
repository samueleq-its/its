namespace StudentiMVC.Models
{
    public class MyLibrary
    {

        const int MATRICOLA = 0;
        const int NOME = 1;
        const int COGNOME = 2;
        const int EMAIL = 3;
        const int CLASSE = 4;

        static public List<Studente> LeggiStudenti(string percorsoFile)
        {
            var studenti = new List<Studente>();

            using (var reader = new StreamReader(percorsoFile))
            {

                while (!reader.EndOfStream)
                {
                    String line = reader.ReadLine()!;
                    String[] datiStudente = line.Split(";");

                    try
                    {
                        studenti.Add(new Studente
                        {
                            Matricola = int.Parse(datiStudente[MATRICOLA]),
                            Nome = datiStudente[NOME],
                            Cognome = datiStudente[COGNOME],
                            Email = datiStudente[EMAIL],
                            Classe = datiStudente[CLASSE]
                        });
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }

            return studenti;
        }

        static public void ScriviStudenti(string percorsoFile, List<Studente> studenti)
        {
            using (var writer = new StreamWriter(percorsoFile))
            {
                foreach (var s in studenti)
                {
                    string line = $"{s.Matricola};{s.Nome};{s.Cognome};{s.Email};{s.Classe}";
                    writer.WriteLine(line);
                }
            }
        }




    }
}