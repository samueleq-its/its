using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneMessaggi
{
	internal class Messaggio
	{
		public string Mittente { set; get; }
		public string Destinatario { set; get; }
		public string Oggetto { set; get; }
		public string Testo { set; get; }
		public DateTime Data { set; get; }
		public Priorita Priorita { set; get; }

		public Messaggio(string mittente, string destinatario, string oggetto, string testo, DateTime data, Priorita priorita)
		{
			Mittente = mittente;
			Destinatario = destinatario;
			Oggetto = oggetto;
			Testo = testo;
			Data = data;
			Priorita = priorita;
		}

		public override string ToString()
		{
			return $"{nameof(Mittente)}={Mittente}" +
			$", {nameof(Destinatario)}={Destinatario}" +
			$", {nameof(Oggetto)}={Oggetto}" +
			$", {nameof(Testo)}={Testo}" +
			$", {nameof(Data)}={Data.ToString()}" +
			$", {nameof(Priorita)}={Priorita.ToString()}";
		}
	}
}
