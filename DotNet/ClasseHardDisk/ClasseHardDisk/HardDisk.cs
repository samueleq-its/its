namespace ClasseHardDisk
{
	internal class HardDisk
	{
		public string Marca { get; set; }
		public int Velocita { get; set; } //RPM
		public double TempoAccesso { get; set; } //millisecondi
		public int Capacita { get; set; } //GigaByte

		public double Punteggio() {
			double punteggio = 0;
			punteggio += Velocita * 1;
			punteggio += TempoAccesso * -200;
			punteggio += Capacita * 500;
			return punteggio;
		}

		public string Stampa(){
			return Stampa("\n") ;
		}

		public string Stampa(string separatore){
			string output = $"Marca: {Marca}" +
			$"{separatore}Velocità: {Velocita}" +
			$"{separatore}Tempo di accesso: {TempoAccesso}" +
			$"{separatore}Capacita: {Capacita}" +
			$"{separatore}Punteggio: {Punteggio()}"
			;
			return output ;
		}

		public override string ToString()
		{
			return $"{{{nameof(Marca)}={Marca}, {nameof(Velocita)}={Velocita.ToString()}, {nameof(TempoAccesso)}={TempoAccesso.ToString()}, {nameof(Capacita)}={Capacita.ToString()}}}";
		}
	}
}
