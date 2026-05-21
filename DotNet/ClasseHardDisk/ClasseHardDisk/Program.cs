namespace ClasseHardDisk
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");
			HardDisk hdd1 = new HardDisk
			{
				Marca = "Western Digital",
				Velocita = 7200,
				Capacita = 1000,
				TempoAccesso = 2.22
			};
			HardDisk hdd2 = new HardDisk
			{
				Marca = "Western Digital",
				Velocita = 7200,
				Capacita = 6000,
				TempoAccesso = 2.61
			};
			HardDisk hdd3 = new HardDisk
			{
				Marca = "Seagate",
				Velocita = 10000,
				Capacita = 1800,
				TempoAccesso = 2.9
			};
			HardDisk hdd4 = new HardDisk
			{
				Marca = "Seagate",
				Velocita = 5400,
				Capacita = 4000,
				TempoAccesso = 11.11
			};
			HardDisk hdd5 = new HardDisk
			{
				Marca = "Toshiba",
				Velocita = 7200,
				Capacita = 4000,
				TempoAccesso = 5.56
			};

			HardDisk[] hddList = { hdd1, hdd2, hdd3, hdd4, hdd5 };
			foreach (HardDisk hdd in hddList)
			{
				Console.WriteLine(hdd.Stampa() + "\n");
			}


		}
	}
}
