namespace Atleti
{
	internal class Atleta : IAtleta, ITennista, INuotatore, IAtletaUniversale
	{
		public string Cognome { get; set; }
		public string Nome { get; set; }
		public int NumeroPettorina { get; set; }
		public string Disciplina { get; set; }

		public string Corro()
		{
			return "sto correndo ...";
		}

		public string Salto()
		{
			return "sto saltando ...";
		}

		public string Dritto()
		{
			throw new NotImplementedException();
		}

		public string Rovescio()
		{
			throw new NotImplementedException();
		}

		public string Dorso()
		{
			throw new NotImplementedException();
		}

		public string Rana()
		{
			throw new NotImplementedException();
		}

		public string Mangio()
		{
			throw new NotImplementedException();
		}

		public string Bevo()
		{
			throw new NotImplementedException();
		}

		public override string ToString()
		{
			return $"{{{nameof(Cognome)}={Cognome}, {nameof(Nome)}={Nome}, {nameof(NumeroPettorina)}={NumeroPettorina.ToString()}, {nameof(Disciplina)}={Disciplina}}}";
		}

		public override bool Equals(object? obj)
		{
			return obj is Atleta atleta &&
				   Cognome == atleta.Cognome &&
				   Nome == atleta.Nome &&
				   NumeroPettorina == atleta.NumeroPettorina &&
				   Disciplina == atleta.Disciplina;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Cognome, Nome, NumeroPettorina, Disciplina);
		}
	}

}
