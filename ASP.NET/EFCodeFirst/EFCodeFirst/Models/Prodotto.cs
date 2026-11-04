namespace EFCodeFirst.Models
{
    public class Prodotto
    {
        public int Id { get; set; }
        public required String Denominazione { get; set; }
        public String? Descrizione { get; set; }
        public double Prezzo { get; set; }
        public int Giacenza { get; set; }

    }
}
