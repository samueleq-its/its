namespace ListaStudenti
{
	internal class Studente : Persona
	{
		public int Matricola { get; set; }
		public string Email { get; set; }
		public string Classe { get; set; }
		public string Corso { get; set; }

		public override string ToString()
		{
			return base.ToString()+ $"{{{nameof(Corso)}={Corso}}}";
		}
	}
}
