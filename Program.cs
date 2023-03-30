using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GestioneCampionato;

class Program
{
	static void Main(string[] args)
	{
		int index = 0;

		Campionato objCampionato = new Campionato();
		objCampionato.GetPersone();
		objCampionato.MakeSquadre();
		while (true)
		{
			Graphic.Clear();
			Graphic.Switcher("Campionato", 0, 0, GetNomeSquadre(), ref index, 0, 1, false, true);
			if (index < objCampionato.squadre.Count) objCampionato.squadre[index].Visualizza();
			else break;
		}
        Graphic.Clear();
		Console.WriteLine("Stagione finita");
        Console.ReadKey();
	}
    public static string[] GetNomeSquadre()
		{
			string[] sq = new string[squadre.Count + 1];
			for (int i = 0; i < squadre.Count; i++) sq[i] = squadre[i].Nome;
			sq[squadre.Count] = "exit";
			return sq;
		}
}
