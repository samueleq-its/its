using System;

namespace GestioneAtleti
{
    internal class Atleta
    {
        public string Cognome { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public DateTime DataNascita { get; set; }
        public string Disciplina { get; set; } = string.Empty;
        public int NumeroPettorina { get; set; }
        public string Sesso { get; set; } = string.Empty;

        public int CalcolaEta()
        {
            var oggi = DateTime.Today;
            var eta = oggi.Year - DataNascita.Year;

            if (DataNascita.Date > oggi.AddYears(-eta))
            {
                eta--;
            }

            return eta;
        }

        public string CalcolaCategoria()
        {
            var eta = CalcolaEta();
            var sesso = Sesso.Trim().ToUpperInvariant();
            var prefisso = sesso == "F" ? "SF" : "SM";

            if (eta >= 6 && eta <= 11)
            {
                return "Esordienti";
            }

            if (eta >= 12 && eta <= 13)
            {
                return "Ragazzi";
            }

            if (eta >= 14 && eta <= 15)
            {
                return "Cadetti";
            }

            if (eta >= 16 && eta <= 17)
            {
                return $"A{prefisso[1]}";
            }

            if (eta >= 18 && eta <= 19)
            {
                return "Juniores";
            }

            if (eta >= 20 && eta <= 22)
            {
                return "Promesse";
            }

            if (eta >= 23 && eta < 35)
            {
                return "Seniores";
            }

            if (eta >= 35)
            {
                var fascia = (eta / 5) * 5;
                if (fascia > 95)
                {
                    fascia = 95;
                }

                return $"{prefisso}{fascia}";
            }

            return "Non classificata";
        }
    }
}
