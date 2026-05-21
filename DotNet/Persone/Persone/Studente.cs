namespace Persone
{
	internal class Studente : Persona
	{
		public string Corso { get; set; }

		public override string ToString()
		{
			return base.ToString()+ $"{{{nameof(Corso)}={Corso}}}";
		}
	}
}
