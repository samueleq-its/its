namespace ClasseEmail
{
	internal class Email
	{

		public string Da { get; set; }
		public string A { get; set; } = "";
		public string Cc { get; set; } = "";
		public string Bcc { get; set; } = "";
		public string Oggetto { get; set; }
		public string Messaggio { get; set; }
		public DateTime Data { get; set; } = DateTime.Now;
		public Priorita Priorita { get; set; } = Priorita.NORMALE;

		 

		public override string ToString()
		{
			return $"{{{nameof(Da)}={Da}, {nameof(A)}={A}, {nameof(Cc)}={Cc}, {nameof(Bcc)}={Bcc}, {nameof(Oggetto)}={Oggetto}, {nameof(Messaggio)}={Messaggio}, {nameof(Data)}={Data.ToString()}, {nameof(Priorita)}={Priorita.ToString()}}}";
		}
	}
}
