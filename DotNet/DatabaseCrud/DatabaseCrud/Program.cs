namespace DatabaseCrud
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Database Crud");

            StudentiDAL dal = new();

            dal.Elenco().ForEach(e => Console.WriteLine(e));

            Console.WriteLine("inserisci la matricola dello studente da cercare");
            int matricola = int.Parse(Console.ReadLine());
            Console.WriteLine(dal.Dettaglio(matricola).StampaDettaglio());

            //var s = new Studente
            //{
            //    Matricola = 12000,
            //    Nome = "Dario",
            //    Cognome = "Destro",
            //    Email = "destro@edu-its.it",
            //    Classe = "1A"
            //};

            var s1 = new Studente
            {
                Matricola = 12001,
                Nome = "Giulia",
                Cognome = "De'stro",
                Email = "destro@edu-its.it",
                Classe = "1A"
            };

            dal.Nuovo(s1);

            var s2 = new Studente
            {
                Matricola = 12000,
                Nome = "Dario",
                Cognome = "De'stro",
                Email = "destro@edu-its.it",
                Classe = "1A"
            };

            dal.Modifica(s2);

        }
    }
}
