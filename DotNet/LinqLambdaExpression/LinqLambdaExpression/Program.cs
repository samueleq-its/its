namespace LinqLambdaExpression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region generazione lista 
            Console.WriteLine("LInq Lambda Expression");

            Random random = new Random();

            List<int> numeri = new List<int>();

            int inf = random.Next(-100, 100);

            int sup;

            do
            {
                sup = random.Next(-100, 100);
            }
            while (inf >= sup);

            int tappo;
            do
            {

                Console.WriteLine($"inf: {inf}; sup {sup}");
                Console.WriteLine("Tappo terminatore: ");
                tappo = int.Parse(Console.ReadLine());

                if (tappo < inf || tappo > sup)
                {
                    Console.WriteLine("Tappo non valido, deve essere compreso tra inf e sup");
                }
            }
            while (tappo < inf || tappo > sup);

            int numero;
            do
            {
                numero = random.Next(inf, sup + 1);

                numeri.Add(numero);

            } while (numero != tappo);
            #endregion

            Console.WriteLine($"Numeri generati: {numeri.Count}");
            Console.WriteLine($"Numeri generati. {string.Join(", ", numeri)}");

            var max = numeri.Max();
            Console.WriteLine($"Max: {max}");

            var min = numeri.Max();
            Console.WriteLine($"Max: {min}");

            var somma = numeri.Sum();
            Console.WriteLine($"Somma: {somma}");

            var sommaPositivi = numeri.Where(n => n >= 0).Sum();
            Console.WriteLine($"Somma numeri positivi: {sommaPositivi}");

            var dispari = from n in numeri where n % 2 != 0 select n;
            Console.WriteLine($"Numeri dispari: {string.Join(", ", dispari)}");

            var mult3 = from n in numeri where n % 3 == 0 select n;
            Console.WriteLine($"Numeri multipli di 3: {string.Join(", ", mult3)}");


            Console.WriteLine();
        }
    }
}
