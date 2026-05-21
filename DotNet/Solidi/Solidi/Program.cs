namespace Solidi
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Solidi!");

			Materiale acciaio = new Materiale { Denominazione=TipoMateriale.ACCIAIO, PesoSpecifico=7.85};
			Cubo c1 = new Cubo(12.5, acciaio);
			Console.WriteLine(c1);

			Materiale alluminio = new Materiale { Denominazione = TipoMateriale.ALLUMINIO, PesoSpecifico = 2.60 };
			Sfera s1 = new Sfera(5.5, alluminio);
			Console.WriteLine(s1);

			Materiale bronzo = new Materiale { Denominazione = TipoMateriale.BRONZO, PesoSpecifico = 7.4 };
			Tetraedro t1 = new Tetraedro(9, bronzo);
			Console.WriteLine(t1);

			Materiale zinco = new Materiale { Denominazione = TipoMateriale.ZINCO, PesoSpecifico = 7.1 };
			Cilindro c2 = new Cilindro(7.5, 5, zinco);
			Console.WriteLine(c2);

			Materiale stagno = new Materiale { Denominazione = TipoMateriale.STAGNO, PesoSpecifico = 7.28 };
			Cono c3 = new Cono(11.5, 8, stagno);
			Console.WriteLine(c3);

			Materiale nickel = new Materiale { Denominazione = TipoMateriale.NICKEL, PesoSpecifico = 8.60 };
			Toro t2 = new Toro(5.8, 2.3, nickel);
			Console.WriteLine(t2);

		}
	}
}
