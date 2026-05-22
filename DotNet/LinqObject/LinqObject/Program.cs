namespace LinqObject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LInq Objects");

            var clienti = new List<Cliente> {
                new Cliente("VRDFBA76A01L219J","Verdi","Fabio",DateTime.Parse("01/01/1976")),
                new Cliente("BNCMRA80L15C627M","Bianchi","Mario",DateTime.Parse("15/07/1980")),
                new Cliente("MNNLRA91G52F335K","Mannino","Laura",DateTime.Parse("12/06/1991")),
                new Cliente("RMTNTN58B05E050T","Romito","Antonio",DateTime.Parse("05/02/1958"))
            };

            Console.WriteLine($"Clienti:\n{string.Join("\n", clienti)}");

            var codiciFiscali = from cliente in clienti select cliente.CodiceFiscale;
            //clienti.Select((cliente, i) => cliente.CodiceFiscale);
            Console.WriteLine($"Codici fiscali:\n{string.Join(", ", codiciFiscali)}");

            var dopoAnno = from cliente in clienti where cliente.DataNascita.Year >= 1980 select cliente;
            //clienti.Where(cliente => cliente.DataNascita.Year >= 1980);
            Console.WriteLine("Nominativi di clienti nati dopo il 1980");
            foreach( var cliente in dopoAnno )
            {
                Console.WriteLine(cliente.Cognome + " " + cliente.Nome);
            }
        }
    }
}
