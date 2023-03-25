using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneCampionato
{
	class Partita
	{
		private Squadra casa, ospite;
		private int goalCasa, goalOspite;
		private Persona arbitro;
		public Squadra SquadraCasa { get => casa; }
		public Squadra SquadraOspite { get => ospite; }
		public Persona Arbitro { get => arbitro; }
		public int GoalCasa { get => goalOspite; }
		public int GoalOspite { get => goalOspite; }

	}
}
