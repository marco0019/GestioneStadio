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
			new Persona("fabrizio", "gay", "fbrgay10p05b114m", DateTime.Now).Visualizza();
			Console.ReadKey();
		}
	}
}
