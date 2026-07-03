using System;
using System.Collections.Generic;
using System.Text;

namespace AnagraficaGUI
{
    internal class Studente
    {
        public int Matricola { get; set; }
        public required string Nome { get; set; }
        public required string Cognome { get; set; }
        public required string Email { get; set; }
        public required string Classe { get; set; }

        public string StampaDettaglio()
        {
            return $"{nameof(Matricola)}={Matricola.ToString()}" +
                $"\n{nameof(Nome)}={Nome}" +
                $"\n{nameof(Cognome)}={Cognome}" +
                $"\n{nameof(Email)}={Email}" +
                $"\n{nameof(Classe)}={Classe}";
        }

        public override string ToString()
        {
            return $"{{{nameof(Matricola)}={Matricola.ToString()}, {nameof(Nome)}={Nome}, {nameof(Cognome)}={Cognome}, {nameof(Email)}={Email}, {nameof(Classe)}={Classe}}}";
        }
    }
}
