using System;
using System.Collections.Generic;
using System.Text;

namespace Prodotti
{
	internal class Prodotto
	{
		public string Nome {  get; set; }

		public override string ToString()
		{
			return $"{{{GetType().Name}: {nameof(Nome)}={Nome}}}";
		}
	}
}
