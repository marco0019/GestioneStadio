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
		List<String> nomiSquadre = new List<String>();
		//List<String> codiceFischiato = new List<String>(); // :)					FabrizioZampetti
		public List<Squadra> squadre = new List<Squadra>();
		Boolean trovato;


		private StreamReader SR = new StreamReader("DB_Giocatori.txt");

		public void GetPersone()
        {
			String[] persona = new String[10];
			for (int i = 0; !SR.EndOfStream; i++)
			{
				persona = SR.ReadLine().Split(',');
				persone.Add(new Persona(persona[1], persona[0], MakeCF(), Convert.ToDateTime(persona[2])));
				trovato = false;
				for (int j = 0; j < nomiSquadre.Count; j++)
				{
					if (nomiSquadre[j] == persona[3]) trovato = true;
				}
				if (!trovato) nomiSquadre.Add(persona[3]);
			}
		}

		public void VisualizzaSquadre()
        {
            foreach (Squadra squad in squadre)
            {
				squad.Visualizza();
				Console.ReadKey();
            }
        }

		public void VisualizzaPersona()
        {
            foreach (Persona persona in persone)
            {
				persona.Visualizza();
            }
        }

		public void VisualizzaNomiSquadre()
        {
			Console.WriteLine("Squadre del campionato: ");
			Console.WriteLine();
			foreach(String nome in nomiSquadre)
            {
				Console.WriteLine(nome);
            }
        }

		String MakeCF()
		{
			String alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			Random random = new Random();
			String CF = "";
			//do
			//{				
			//	for (int i = 0; i < 6; i++) CF += alfabeto[random.Next(0, alfabeto.Length)];
			//	CF += random.Next(0, 10);
			//	CF += random.Next(0, 10);
			//	CF += alfabeto[random.Next(0, alfabeto.Length)];
			//	CF += random.Next(0, 10);
			//	CF += random.Next(0, 10);
			//	CF += alfabeto[random.Next(0, alfabeto.Length)];
			//	CF += random.Next(0, 10);
			//	CF += random.Next(0, 10);
			//	CF += random.Next(0, 10);
			//	CF += alfabeto[random.Next(0, alfabeto.Length)];				
			//}
			//while (ControlloCF(CF));

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
			//codiceFischiato.Add(CF);
			return CF;
		}

		//Boolean ControlloCF(String _cf)
  //      {
  //          foreach (String codiceF in codiceFischiato)
  //          {
		//		if (codiceF == _cf) return true;
  //          }
		//	return false;
  //      }


		public void MakeSquadre()
        {
			List<Persona> giocatori = new List<Persona>();
			Persona[] arrayGiocatori = new Persona[30];
			this.SR = new StreamReader("DB_Giocatori.txt");
			foreach (String nomeSquadra in nomiSquadre)
            {
				String[] persona = new String[10];
				for (int i = 0; !this.SR.EndOfStream; i++)
				{
					persona = SR.ReadLine().Split(',');
					if (persona[3] == nomeSquadra)
                    {
                        foreach (Persona pers in this.persone)
                        {
							if (persona[1] == pers.Nome & persona[0] == pers.Cognome && pers.DataNascita == Convert.ToDateTime(persona[2])) giocatori.Add(pers);
                        }
                    }
				}
				int n;
				if (giocatori.Count < 30) n = giocatori.Count;
				else n = 30;
                for (int i = 0; i < n; i++)
                {
					arrayGiocatori[i] = giocatori[i];
                }

				squadre.Add(new Squadra(nomeSquadra, new Persona("Nome Presidente " + nomeSquadra, "Cognome Presidente " + nomeSquadra, MakeCF(), RandomBD()), new Persona("Nome Allenatore " + nomeSquadra, "Cognome Allenatore " + nomeSquadra, MakeCF(), RandomBD()), "Stadio " + nomeSquadra, arrayGiocatori));
			}
        }


		DateTime RandomBD()
        {
			Random random = new Random();
			String bd_string = (random.Next(1, 28)).ToString() + "/" + random.Next(1,13) + "/" + random.Next(1960, 1991);
			DateTime dt = Convert.ToDateTime(bd_string);
			return dt;
        }
	}
}
