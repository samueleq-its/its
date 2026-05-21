using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCSV_Scrittura
{
    internal class Persona
    {
        public string? Cognome { get; set; }
        public string? Nome { get; set; }
        public DateTime DataNascita { get; set; }
        public string? LuogoNascita { get; set; }
        public Sesso Sesso { get; set; }

        public int Eta()
        {
            return (int)(DateTime.Now - DataNascita).TotalDays / 365;
        }

        public string FormatStampaCSV()
        {
            return $"{Cognome}" +
                $";{Nome}" +
                $";{DataNascita.ToShortDateString()}" +
                $";{LuogoNascita}" +
                $";{Sesso.ToString()}";
        }

        public override string ToString()
        {
            return $"{{{nameof(Cognome)}={Cognome}, {nameof(Nome)}={Nome}, {nameof(DataNascita)}={DataNascita.ToString()}, {nameof(LuogoNascita)}={LuogoNascita}, {nameof(Sesso)}={Sesso.ToString()}}}";
        }
    }
}
