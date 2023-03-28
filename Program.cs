using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneCampionato
{
	class Program
	{
		static void Main(string[] args)
		{
			int index = 0;
			Action[] metodi =
			{
				delegate(){ Console.WriteLine("metodo 1"); },
				delegate(){ Console.WriteLine("metodo 2"); },
				delegate(){ Console.WriteLine("metodo 3"); },
				delegate(){ Console.WriteLine("metodo 4"); },
				delegate(){ Console.WriteLine("metodo 5"); },
				delegate(){ Console.WriteLine("metodo 6"); },
				delegate(){ Console.WriteLine("metodo 7"); },
				delegate(){ Console.WriteLine("metodo 8"); },
			};
			Graphic.Switcher("menumolto lungo", 0, 0, new string[] { "partita", "campionato", "giocatori", "classifica", "giocatori", "arbitri", "allenatori", "exit" }, metodi, ref index, 0, 1, true, true);
			new Persona("fabrizio", "gay", "fbrgay10p05b114m", DateTime.Now).Visualizza();
			Console.ReadKey();
		}
	}
}
