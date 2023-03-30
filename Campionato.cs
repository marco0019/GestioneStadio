using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GestioneCampionato
{
	internal class Campionato
	{
		private Squadra[] Squadre = new Squadra[20];
		private List<Persona> persone = new List<Persona>();





		private StreamReader SR = new StreamReader("DB_Giocatori.txt");

		public void GetPersone()
        {
			String[] persona = new String[10];
			for (int i = 0; !SR.EndOfStream; i++)
			{
				persona = SR.ReadLine().Split(',');
				persone.Add(new Persona(persona[1], persona[0], makeCF(), Convert.ToDateTime(persona[2])));
			}
		}

		public void VisualizzaPersona()
        {
            foreach (Persona persona in persone)
            {
				persona.Visualizza();
            }
        }

		String makeCF()
		{
			String alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			Random random = new Random();
			String CF = "";
			for (int i = 0; i < 6; i++) CF += alfabeto[random.Next(0, alfabeto.Length)];
			CF += random.Next(0, 10);
			CF += random.Next(0, 10);
			CF += alfabeto[random.Next(0, alfabeto.Length)];
			CF += random.Next(0, 10);
			CF += random.Next(0, 10);
			CF += alfabeto[random.Next(0, alfabeto.Length)];
			CF += random.Next(0, 10);
			CF += random.Next(0, 10);
			CF += random.Next(0, 10);
			CF += alfabeto[random.Next(0, alfabeto.Length)];
			return CF;
		}
		
	}
}
