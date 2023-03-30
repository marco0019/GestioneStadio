﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace GestioneCampionato
{
	class Squadra
	{
		private Persona[] giocatori = new Persona[30];
		private Persona presidente;
		private Persona allenatore;
		private string nome, stadio;
		public int NumeroGiocatori { get; set; }
		public Persona[] Giocatori { get => giocatori; set => giocatori = value; }
		public Persona Allenatore { get => allenatore; set=> allenatore = value; }
		public Persona Presidente { get => presidente; set => presidente = value; }
		public string Nome { get => nome; set => nome = value; }
		public string Stadio { get => stadio; set => stadio = value; }
		public Squadra(String _nome, Persona _presidente, Persona _allenatore,String _stadio, Persona[] _giocatori)
		{
			this.nome = _nome[0].ToString().ToUpper() + _nome.Substring(1).ToString().ToLower();
			this.Presidente = _presidente;
			this.Allenatore = _allenatore;
			this.stadio = _stadio;
			this.Giocatori = _giocatori;
			this.NumeroGiocatori++;
		}
		public Squadra(string _nome, string _stadio, Persona _presidente, Persona _allenatore)
		{
			Nome = _nome;
			Stadio = _stadio;
			Presidente = _presidente;
			Allenatore = _allenatore;
			InserimentoGiocatori();
		}
		public void InserimentoGiocatori()
		{
			var conn = new MySqlConnection("Server=aws.connect.psdb.cloud;Database=players;user=m9l5amgnhb6nxze1b2r2;password=pscale_pw_L1PrTdNrUnkgGrdfV9yQWivaLrdo4tuWLiLCdmuxxFS;SslMode=VerifyFull;");
			var query = new MySqlCommand("SELECT * FROM giocatori WHERE team = @team;", conn);
			query.Parameters.AddWithValue("@team", Nome);
			conn.Open();
			var res = query.ExecuteReader();
			for(int i = 0; i < Giocatori.Length & res.Read(); i++)
			{
				Giocatori[i] = new Persona(res.GetString("name"), res.GetString("surname"), res.GetString("fiscalcode"), res.GetDateTime("birthdate"));
				NumeroGiocatori = i;
			}
			conn.Close();
		}
		public void Inserimento(Persona _persona, String _ruolo = "giocatore")
        {
            switch (_ruolo.ToLower())
            {
				case "giocatore":
					this.Giocatori[this.NumeroGiocatori] = _persona;
					this.NumeroGiocatori++;
					break;
				case "presidente":
					this.Presidente = _persona;
					break;
				case "allenatore":
					this.Allenatore = _persona;
					break;
			}
        }

		public void Visualizza()
		{
			Console.WriteLine(this.Nome);
			Console.WriteLine("Presidente: ");
			this.Presidente.Visualizza();
			Console.WriteLine("Allenatore: ");
			this.Allenatore.Visualizza();
			Console.WriteLine("Stadio: " + this.Stadio);
			Console.WriteLine();
			Console.WriteLine("Rosa: ");
            for (int i = 0; i < this.NumeroGiocatori; i++)
            {
				Console.Write(this.Giocatori[i].Cognome + " " + this.Giocatori[i].Nome);
				if (i % 2 == 0) Console.WriteLine(); 
            }
		}

		public void Sostituisci(String _ruolo, Persona _old, Persona _new)
        {
            switch (_ruolo.ToLower())
            {
				case "presidente":
					this.Presidente = _new;
					break;
				case "allenatore":
					this.Allenatore = _new;
					break;
				case "giocatore":
                    for (int i = 0; i < NumeroGiocatori; i++)
                    {
						if (Giocatori[i].CodiceFiscale == _old.CodiceFiscale) Giocatori[i] = _new;
                    }
					break;
			}
        }

		public void EliminaGioatore(Persona _persona)
        {
			for (int i = 0; i < NumeroGiocatori; i++)
			{
				if (Giocatori[i].CodiceFiscale == _persona.CodiceFiscale)
                {
                    for (int j = i; j < this.NumeroGiocatori - i; j++)
                    {
						this.Giocatori[j] = this.Giocatori[j + 1];
                    }
                }
			}
			this.Giocatori[this.NumeroGiocatori - 2] = null;
			this.NumeroGiocatori--;
		}
	}
}
