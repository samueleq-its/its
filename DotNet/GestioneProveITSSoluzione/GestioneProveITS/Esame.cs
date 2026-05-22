using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneProveITS
{
    internal class Esame
    {
        public string Studente { get; set; }=string.Empty;
        public int ProvaTeorica { get; set; }
        public int ProvaPratica { get; set; }
        public int Colloquio { get; set; }

        public int VotoFinale() => ProvaTeorica + ProvaPratica + Colloquio;

        public override string ToString()
        {
            return $"{{{nameof(Studente)}={Studente}, {nameof(ProvaTeorica)}={ProvaTeorica.ToString()}, {nameof(ProvaPratica)}={ProvaPratica.ToString()}, {nameof(Colloquio)}={Colloquio.ToString()}, Voto Finale={VotoFinale()}}}";
        }
    }
}
