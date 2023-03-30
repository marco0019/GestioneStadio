using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MySql.Data.MySqlClient;

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
		public void InserimentoSquadre()
		{
			var conn = new MySqlConnection("Server=aws.connect.psdb.cloud;Database=players;user=m9l5amgnhb6nxze1b2r2;password=pscale_pw_L1PrTdNrUnkgGrdfV9yQWivaLrdo4tuWLiLCdmuxxFS;SslMode=VerifyFull;");
			var query = new MySqlCommand("SELECT * FROM team;", conn);
			var res = query.ExecuteReader();
			for(int i = 0; i < 20 & res.Read(); i++)
			{
				Squadre[i] = new Squadra(res.GetString("name"), res.GetString("stadio"),
					new Persona(res.GetString("president").Split(' ')[0], res.GetString("president").Split(' ')[1], makeCF(), RandomDate()),
					new Persona(res.GetString("mister").Split(' ')[0], res.GetString("mister").Split(' ')[1], makeCF(), res.GetDateTime("birthdate_mister")));
			}
		}
		public DateTime RandomDate() => new DateTime(1960 + new Random().Next(0, 41), new Random().Next(1, 13), new Random().Next(0, 29));
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
