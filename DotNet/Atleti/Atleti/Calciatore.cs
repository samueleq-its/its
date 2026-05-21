using System;
using System.Collections.Generic;
using System.Text;

namespace Atleti
{
	internal class Calciatore : Atleta, ICloneable, IComparable
	{
		public int PartiteGiocate { get; set; }
		public int GoalSegnati { get; set; }

		public double MediaGoalSegnati()
		{
			return (double)GoalSegnati / PartiteGiocate;
		}

		public override bool Equals(object? obj)
		{
			return obj is Calciatore calciatore
				&& base.Equals(obj)
				&& calciatore.PartiteGiocate == this.PartiteGiocate
				&& calciatore.GoalSegnati == this.GoalSegnati;
		}

		public object Clone()
		{
			if (PartiteGiocate == 0)
			{
				throw new Exception("Operazione fallita! numero partite giocate non valido");
			}
			return this.MemberwiseClone();
		}

		public int CompareTo(object? obj)
		{
			// 1 this > other
			// -1 this < other
			// 0 in tutti gli altri casi (non vuol dire eguale)
			if (obj is Calciatore other)
				if (MediaGoalSegnati() > other.MediaGoalSegnati())
				{
					return 1;
				}
				else if (MediaGoalSegnati() < other.MediaGoalSegnati())
				{
					return -1;
				}
			return 0;

		}

		public override int GetHashCode()
		{
			return HashCode.Combine(base.GetHashCode(), Cognome, Nome, NumeroPettorina, Disciplina, PartiteGiocate, GoalSegnati);
		}
	}
}
