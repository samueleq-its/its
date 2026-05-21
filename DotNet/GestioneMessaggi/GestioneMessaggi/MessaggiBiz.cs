using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneMessaggi
{
	internal class MessaggiBiz
	{
		public List<Messaggio> ElencoMessaggi { get; set; }

		public MessaggiBiz(List<Messaggio> elencoMessaggi){
			ElencoMessaggi = elencoMessaggi;
		}

		public List<Messaggio> CercaMittente(string mittente)
		{
			var messaggiTrovati = new List<Messaggio>();
			foreach (var messaggio in ElencoMessaggi)
			{
				if (messaggio.Mittente == mittente)
				{
					messaggiTrovati.Add(messaggio);
				}
			}
			return messaggiTrovati;
		}

		public List<Messaggio> CercaDestinatario(string destinatario)
		{
			var messaggiTrovati = new List<Messaggio>();
			foreach (var messaggio in ElencoMessaggi)
			{
				if (messaggio.Destinatario == destinatario)
				{
					messaggiTrovati.Add(messaggio);
				}
			}
			return messaggiTrovati;
		}

		public List<Messaggio> MessaggiDopoData(DateTime data)
		{
			var messaggiTrovati = new List<Messaggio>();
			foreach (var messaggio in ElencoMessaggi)
			{
				if (messaggio.Data > data)
				{
					messaggiTrovati.Add(messaggio);
				}
			}
			return messaggiTrovati;
		}

		public void AggiungiMessaggio(Messaggio messaggio) {
			ElencoMessaggi.Add(messaggio);
		}
	}
}
