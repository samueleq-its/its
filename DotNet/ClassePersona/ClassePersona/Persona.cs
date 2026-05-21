namespace ClassePersona
{
	internal class Persona
	{
		public string Nome { get; set; }
		public string Cognome { get; set; }
		public DateTime DataNascita { get; set; }
		public string LuogoNascita { get; set; }
		public Sesso Sesso { get; set; }


		public Persona()
		{
			DataNascita = new DateTime();
		}

		public Persona(string nome, string cognome)
		{
			this.Nome = nome;
			this.Cognome = cognome;
		}

		public Persona(string nome, string cognome, DateTime dataNascita, string luogoNascita) : this(nome, cognome)
		{
			this.DataNascita = dataNascita;
			this.LuogoNascita = luogoNascita;
		}

		public Persona(string nome, string cognome, DateTime dataNascita, string luogoNascita, Sesso sesso) : this(nome, cognome, dataNascita, luogoNascita)
		{
			this.Sesso = sesso;
		}

		public int Eta()
		{
			return DataNascita.Year - DateTime.Now.Year;
		}

		public string Stampa(string separatore = " ")
		{
			return (
			(Nome != null ? $"{nameof(Nome)}={Nome},"  : "") +
			(Cognome!= null ? $"{separatore}{nameof(Cognome)}={Cognome}," : "") +
			$"{separatore}{nameof(DataNascita)}={DataNascita.ToString()}," +
			(LuogoNascita != null ? $"{separatore}{nameof(LuogoNascita)}={LuogoNascita}," : "")+
			(Sesso != null ? $"{separatore}{nameof(Sesso)}={Sesso.ToString()}" : "")
			);
		}

		public string StampaDettaglio()
		{
			return Stampa("\n");
		}


		public override string ToString()
		{
			return $"{{{nameof(Nome)}={Nome}, {nameof(Cognome)}={Cognome}, {nameof(DataNascita)}={DataNascita.ToString()}, {nameof(LuogoNascita)}={LuogoNascita}, {nameof(Sesso)}={Sesso.ToString()}}}";
		}
	}
}
