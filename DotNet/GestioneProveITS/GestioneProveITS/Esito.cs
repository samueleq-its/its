namespace GestioneProveITS
{
    internal class Esito
    {
        public string Studente { get; set; }
        public int Teorico { get; set; }
        public int Pratico { get; set; }
        public int Orale { get; set; }

        public Esito(string studente, int teorico, int pratico, int orale)
        {
            Studente = studente;
            Teorico = teorico;
            Pratico = pratico;
            Orale = orale;
        }

        public int VotoFinale() {
            return Teorico + Pratico + Orale;
        }

        public override string ToString()
        {
            return $"{nameof(Studente)}={Studente}, {nameof(Teorico)}={Teorico.ToString()}, {nameof(Pratico)}={Pratico.ToString()}, {nameof(Orale)}={Orale.ToString()}, {nameof(VotoFinale)}={VotoFinale()}";
        }
    }
}
