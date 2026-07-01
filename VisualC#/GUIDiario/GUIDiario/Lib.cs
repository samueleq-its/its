using System;
using System.Collections.Generic;
using System.Text;

namespace GUIDiario
{
    internal class Lib
    {
		private static Lib inst;

		public static Lib Inst
		{
			get { 
				if (inst == null)
				{
					inst = new Lib();
				}
				return inst;
			}
			//set { inst = value; }
		}

        public List<String> ElencoCommenti { get ; set; } = new List<string>();

		public void AggiungiCommento(String commento)
		{
			string id = ElencoCommenti.Count().ToString();
			string data = DateTime.Now.ToString();

            ElencoCommenti.Add($"{id} - {data} - {commento}");
		}

    }
}
