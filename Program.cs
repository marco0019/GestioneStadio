using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GestioneCampionato
{
	class Program
	{
		static void Main(string[] args)
		{
			int index = 0;

			Action[] metodi =
			{
				delegate () { Console.WriteLine("metodo 1"); },
				delegate () { Console.WriteLine("metodo 2"); },
				delegate () { Console.WriteLine("metodo 3"); },
				delegate () { Console.WriteLine("metodo 4"); },
				delegate () { Console.WriteLine("metodo 5"); },
				delegate () { Console.WriteLine("metodo 6"); },
				delegate () { Console.WriteLine("metodo 7"); },
				delegate () { Console.WriteLine("metodo 8"); },
			};

			Campionato objCampionato = new Campionato();
			objCampionato.GetPersone();
			objCampionato.MakeSquadre();
			//objCampionato.VisualizzaPersona();
			//objCampionato.VisualizzaNomiSquadre();
			objCampionato.VisualizzaSquadre();
			Console.ReadKey();
		}
	}
}
