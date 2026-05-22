namespace GestioneProveITS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Gestione Prove ITS");

            var biz = new Biz();

            biz.Esiti.AddRange(
                new List<Esito>
                {
                    new Esito("Rossi Mario", 25, 35, 28),
                    new Esito("Bianchi Luca", 20, 30, 25),
                    new Esito("Verdi Giulia", 30, 40, 30),
                    new Esito("Neri Paola", 15, 20, 18),
                    new Esito("Gialli Marco", 28, 38, 29)
                }
            );

            Console.WriteLine("Elenco risultati:");
            Console.WriteLine(String.Join("\n", biz.Esiti));

            Console.WriteLine("media esami sostenuti");
            var q1 = biz.Esiti.Average(e => e.VotoFinale());
            Console.WriteLine(String.Join("\n", q1));

            Console.WriteLine(" graduatoria in ordine decrescente per voto");
            var q2 = biz.Esiti.OrderByDescending(e => e.VotoFinale());
            Console.WriteLine(String.Join("\n", q2));

        }
    }
}
