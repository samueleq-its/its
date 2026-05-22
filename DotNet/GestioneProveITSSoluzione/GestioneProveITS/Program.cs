namespace GestioneProveITS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Gestione esami ITS!");

            var esami = new List<Esame> { };

            EsamiBiz biz;
            try
            {
                biz = new EsamiBiz(esami);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            
            string mnu = "\n\nScegliere una tra le seguenti operazioni: " +
                "\n1 - Stampa elenco studenti e valutazioni" +
                "\n2 - Stampa media degli esami" +
                "\n3 - Stampa graduatoria" +
                "\n4 - Esci dal programma" +
                "\n\nScelta: ";
            int scelta;

            do { 
            
                Console.Write(mnu);
                scelta=Convert.ToInt32(Console.ReadLine());

                switch (scelta)
                {
                    case 1: Console.WriteLine(biz.StampaElenco()); break;
                    case 2: Console.WriteLine($"Media esami: {biz.MediaEsami()}"); break;
                    case 3: Console.WriteLine(string.Join("\n", biz.Graduatoria())); break;
                    case 4: Console.WriteLine("Programma terminato"); break;
                    default: Console.WriteLine("Errore! Scelta non valida"); break;
                }            
            }
            while (scelta!=4); 
        }
    }
}
