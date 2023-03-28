using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneCampionato
{
	class Partita
	{
		public Squadra SquadraCasa { get; private set; }
		public Squadra SquadraOspite { get; private set; }
		public Persona Arbitro { get; private set; }
		public int GoalCasa { get; private set; }
		public int GoalOspite { get; private set; }
		public void Match()
		{
			GoalCasa = new Random().Next(new Random().Next(0, 2), new Random().Next(5, 10));
			GoalOspite = new Random().Next(new Random().Next(0, 2), new Random().Next(5, 10));
		}
		public void VisualizzaRisultato()
		{

		}
	}
}
