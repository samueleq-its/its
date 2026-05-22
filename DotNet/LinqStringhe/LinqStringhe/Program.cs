namespace LinqStringhe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LInq!");

            //array qui
            string[] nomi = {
                "Alessandro", "Beatrice", "Carlo", "Daniela", "Edoardo",
                "Francesca", "Giovanni", "Elena", "Igor", "Laura",
                "Marco", "Martina", "Nicola", "Paola", "Riccardo",
                "Silvia", "Tommaso", "Valentina", "Umberto", "Zoe"
            };

            // visualizzare numero nomi
            Console.WriteLine($"Numero di nomi trovati: {nomi.Count()}");

            // visualizzare tutti i nomi presenti
            var query1 = from nome in nomi select nome;
            Console.WriteLine($"Elenco nomi: {string.Join(", ", query1)}");

            // nomi nomi che iniziano per A
            var query2 = from nome in nomi where nome.Substring(0, 1).Equals("A") select nome;
            Console.WriteLine($"Nomi per A:{query2.Count()} - {string.Join(", ", query2)}");

            // nomi in ordine crescente
            var query3 = from nome in nomi orderby nome select nome;
            Console.WriteLine($"Nomi ordinati crescente: {string.Join(", ", query3)}");

            // nomi in ordine decrescente
            var query4 = from nome in nomi orderby nome descending select nome;
            Console.WriteLine($"Nomi ordinati decrescente: {string.Join(", ", query4)}");

            // nomi di lunghezza 7 in ordine decrescente
            var query5 = from nome in nomi where nome.Length == 7 orderby nome descending select nome;
            Console.WriteLine($"Nomi lunghezza 7 in ordine decrescente:");
            Console.WriteLine($" {string.Join(", ", query5)}");
            
            // elenco nomi in maiuscolo
            var query6 = from nome in nomi orderby nome select nome.ToUpper();
            Console.WriteLine("nomi in maiuscolo:");
            Console.WriteLine(string.Join(", ", query6));

            
            // Console.WriteLine():
        }
    }
}
