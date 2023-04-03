using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.SqlServer.Server;

namespace GestioneCampionato
{
	class Program
	{
		static void Main(string[] args)
		{
			int index = 0;

			Campionato objCampionato = new Campionato();
			objCampionato.GetPersone();
			objCampionato.MakeSquadrePerfectMethod();
			DateTime pr = new DateTime(2005, 9, 21);
			Console.WriteLine(pr.CompareTo(DateTime.Now));
			var m = new Persona("kaleb", "okoli", "", pr);
			Console.WriteLine(m.MakeCF(m));
			Console.ReadKey();
			while (true)
			{
				Graphic.WindowSize(51, 28);
				Graphic.Clear();
				Graphic.Switcher("Campionato", 0, 0, objCampionato. GetNomeSquadre(objCampionato.squadre), ref index, 0, 1, false, true);
				if (index < objCampionato.squadre.Count) objCampionato.squadre[index].Menu();
				else break;
			}
			Graphic.Clear();
			Console.WriteLine("Stagione finita");
			Console.ReadKey();
		}
	}

}

