using System;
using System.Collections.Generic;
using System.Text;

namespace Persone
{
	internal class Docente:Persona
	{
		public string Materia { get; set; }

		public override string ToString()
		{
			return base.ToString() + $"{{{nameof(Materia)}={Materia}}}";
		}
	}
}
