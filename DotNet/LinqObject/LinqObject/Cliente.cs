namespace LinqObject
{
    internal class Cliente
    {
        public string CodiceFiscale { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascita { get; set; }

        public Cliente(string codiceFiscale, string cognome, string nome, DateTime dataNascita)
        {
            CodiceFiscale = codiceFiscale;
            Cognome = cognome;
            Nome = nome;
            DataNascita = dataNascita;
        }

        public override string ToString()
        {
            return $"{nameof(CodiceFiscale)}={CodiceFiscale}, {nameof(Cognome)}={Cognome}, {nameof(Nome)}={Nome}, {nameof(DataNascita)}={DataNascita.ToString()}";
        }
    }
}
