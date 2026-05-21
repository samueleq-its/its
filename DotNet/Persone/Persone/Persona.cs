namespace Persone
{
	internal class Persona
	{
		public string Nome { get; set; }
		public string Cognome { get; set; }
		public DateTime DataNascita { get; set; }
		public string LuogoNascita { get; set; }
		public Sesso Sesso { get; set; }

		public override string ToString()
		{
			return $"{{{GetType().Name}: {nameof(Nome)}={Nome}, {nameof(Cognome)}={Cognome}, {nameof(DataNascita)}={DataNascita.ToString()}, {nameof(LuogoNascita)}={LuogoNascita}, {nameof(Sesso)}={Sesso.ToString()}}}";
		}
	}
}
