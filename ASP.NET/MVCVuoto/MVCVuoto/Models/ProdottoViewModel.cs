using System.ComponentModel;

namespace MVCVuoto.Models
{
    public class ProdottoViewModel
    {
        public int Codice { get; set; }
        public required string Denominazione { get; set; }
        public string? Decrizione { get; set; }
        public double Prezzo { get; set; }
        public int Giacenza { private get; set; }

        [DisplayName("Disponibilità")]
        public string MessaggioDisponibilita
        {
            get
            {
                if (Giacenza  <= 0)
                {
                    return "Non disponibile";
                }
                else if (Giacenza > 0 && Giacenza < 10)
                {
                    return "In esaurimento";
                }
                else 
                    return "Disponibile";
            }
        }

        public override string ToString()
        {
            return $"{{{nameof(Codice)}={Codice.ToString()}" +
                $", {nameof(Denominazione)}={Denominazione}" +
                $", {nameof(Decrizione)}={Decrizione}" +
                $", {nameof(Prezzo)}={Prezzo.ToString()}" +
                $", {nameof(Giacenza)}={Giacenza.ToString()}}}";
        }
    }
}
