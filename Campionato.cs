﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GestioneCampionato
{
	internal class Campionato
	{
		private List<Persona> persone = new List<Persona>();
		List<String> nomiSquadre = new List<String>();
		//List<String> codiceFischiato = new List<String>(); // :)					FabrizioZampetti
		public List<Squadra> squadre = new List<Squadra>();
		Boolean trovato;       

		

		public void GetPersone()
        {
			StreamReader SR = new StreamReader("DB_Giocatori.txt");
			String[] persona;
			for (int i = 0; !SR.EndOfStream; i++)
			{
				persona = SR.ReadLine().Split(',');
				persone.Add(new Persona(persona[1].Trim(), persona[0].Trim(), MakeCF(), Convert.ToDateTime(persona[2].Trim())));
				trovato = false;
				for (int j = 0; j < nomiSquadre.Count; j++)
				{
					if (nomiSquadre[j] == persona[3]) trovato = true;
				}
				if (!trovato) nomiSquadre.Add(persona[3]);
			}
			SR.Close();
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

		
		public void MakeSquadrePerfectMethod()
		{
			var read = new StreamReader("squadre.csv");
			string[] info;
			while (!read.EndOfStream)
			{
				info = read.ReadLine().Split(',');
				persone.Add(new Persona(info[5].Split(' ')[0], info[5].Split(' ')[1], MakeCF(), RandomBD()));
				persone.Add(new Persona(info[3].Split(' ')[0], info[3].Split(' ')[1], MakeCF(), Convert.ToDateTime(info[4])));
				squadre.Add(new Squadra(info[0], persone[persone.Count - 2], persone[persone.Count - 1], info[2], GetPlayerFromTeam(info[0])));
			}
		}
		public Persona[] GetPlayerFromTeam(string _nomeSquadra)
		{
			Persona[] giocatori = new Persona[30];
			var read = new StreamReader("DB_Giocatori.txt");
			string[] info;
			int count = 0;
			while (!read.EndOfStream & count < 30)
			{
				info = read.ReadLine().Split(',');
				if (info[3].ToLower().Trim() == _nomeSquadra.ToLower().Trim())
				{
					giocatori[count] = new Persona(info[1], info[0], MakeCF(), Convert.ToDateTime(info[2]));
					count++;
				}
			}
			return giocatori;
		}
		public void MakeSquadre()
        {
			StreamReader SR = new StreamReader("DB_Giocatori.txt");
			List<Persona> giocatori = new List<Persona>();
			Persona[] arrayGiocatori = new Persona[30];
			foreach (String nomeSquadra in nomiSquadre)
            {
				String[] persona = new String[10];
				for (int i = 0; !SR.EndOfStream; i++)
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
			SR.Close();
        }

		DateTime RandomBD()
        {
			Random random = new Random();
			String bd_string = (random.Next(1, 28)).ToString() + "/" + random.Next(1,13) + "/" + random.Next(1960, 1991);
			DateTime dt = Convert.ToDateTime(bd_string);
			return dt;
		}
		public string[] GetNomeSquadre(List<Squadra> _squadre)
		{
			string[] sq = new string[_squadre.Count + 1];
			for (int i = 0; i < _squadre.Count; i++) sq[i] = _squadre[i].Nome;
			sq[_squadre.Count] = "exit";
			return sq;
		}


		public void UpdateGiocatori()
        {
			StreamWriter SW = new StreamWriter("DB_Giocatori.txt");
            foreach (Squadra squadra in squadre)
            {
                foreach (Persona giocatore in squadra.Giocatori)
                {
					SW.WriteLine(giocatore.Cognome + "," + giocatore.Nome + "," + giocatore.DataNascita + "," + squadra.Nome);
                }
            }

			SW.Close();
        }
	}
}
