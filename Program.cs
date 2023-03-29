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
		public static List<Squadra> squadre = new List<Squadra>();
		public static List<String> nomiSquadre = new List<String>();
		public static List<String[]> listaGiocatori = new List<String[]>();
		public static StreamReader SR = new StreamReader("DB_Giocatori.txt");
		public static List<String[]> giocatoriSplitted = new List<String[]>();
		static void Main(string[] args)
		{
			List<Persona> giocatori = new List<Persona>();
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





			//		DA DECIDERE SE LASCIARE SU PROGRAM O SPOSTARE SU CAMPIONATO

			

			void getSquadre()
            {
				List<String> giocatoriLetti = new List<String>();

				for (int i = 0; !SR.EndOfStream; i++)
				{
					giocatoriLetti.Add(SR.ReadLine());
				}

                for(int i = 0; i < giocatoriLetti.Count; i++)
                {
                    giocatoriSplitted.Add(giocatoriLetti[i].Split(','));
					findSquadre(giocatoriSplitted[i][3]);
                }
            }

			void popolaSquadra(String _nome, Persona _presidente, Persona _allenatore, String _stadio)
            {
				getGiocatori(_nome);
				Persona[] parametroGiocatori = new Persona[30];
                for (int i = 0; i < 30; i++)
                {
					parametroGiocatori[i] = giocatori[i];
                }
				squadre.Add(new Squadra(_nome, _presidente, _allenatore, _stadio, parametroGiocatori));
            }

			void getGiocatori(String _nomeSquadra)
            {
				listaGiocatori.Clear();
				foreach (String[] player in giocatoriSplitted)
				{
					if (_nomeSquadra == player[3]) listaGiocatori.Add(player);
				}

				foreach (String[] pl in listaGiocatori)
				{
					giocatori.Add(new Persona(pl[1], pl[0], makeCF(), Convert.ToDateTime(pl[2])));	
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

			void findSquadre(String _nomeSquadra)
            {
				Boolean trovato = false;
                foreach (String nome in nomiSquadre)
                {
					if (nome == _nomeSquadra) trovato = true;
                }

				if (!trovato) nomiSquadre.Add(_nomeSquadra);
            }
		}
	}
}
