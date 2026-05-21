namespace GestioneImmobili
{
	internal class Service
	{
		public List<Immobile> ListaImmobili { get; set; }
		
		public Service(List<Immobile> listaImmobili){
			ListaImmobili = listaImmobili;
		}

		public int NumeroImmobili()
		{
			return ListaImmobili.Count;
		}

		public List<Appartamento> GetAppartamenti()
		{
			var listaAppartamenti = new List<Appartamento>();
			foreach (var immobile in ListaImmobili)
			{
				if (immobile is Appartamento appartamento && appartamento is not Villa)
				{
					listaAppartamenti.Add(appartamento);
				}
			}
			return listaAppartamenti;
		}

		public List<Villa> GetVille()
		{
			var listaVille = new List<Villa>();
			foreach (var immobile in ListaImmobili)
			{
				if (immobile is Villa villa)
				{
					listaVille.Add(villa);
				}
			}
			return listaVille;
		}

		public List<Box> GetBox()
		{
			var listaBox = new List<Box>();
			foreach (var immobile in ListaImmobili)
			{
				if (immobile is Box box)
				{
					listaBox.Add(box);
				}
			}
			return listaBox;
		}

		public List<Immobile> GetImmobiliInCitta(string citta)
		{
			var lista = new List<Immobile>();
			ListaImmobili.ForEach(imm =>
			{
				if (imm.Citta == citta)
				{
					lista.Add(imm);
				}
			});
			return lista;
		}

		public Immobile? DettaglioImmobile(string codice) {
			return ListaImmobili.Find(x => x.Codice.Equals(codice));
		}

		public void ToFile(List<Immobile> lista, string nomeFile){
			string path = @".\File\" + nomeFile;
			StreamWriter sw = new StreamWriter(path);
			sw.Write(String.Join<Immobile>("\n", lista).Replace(",",";"));
			sw.Close();
		}

	}
}
