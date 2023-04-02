using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		public string Nome { get => nome;}
		public string Stadio { get => stadio; }
		public Squadra(String _nome, Persona _presidente, Persona _allenatore,String _stadio, Persona[] _giocatori)
		{
			this.nome = _nome[0].ToString().ToUpper() + _nome.Substring(1).ToString().ToLower();
			this.Presidente = _presidente;
			this.Allenatore = _allenatore;
			this.stadio = _stadio;
			this.Giocatori = _giocatori;
			this.NumeroGiocatori = _giocatori.Length;
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
			this.Presidente.Visualizza("presidente");
			Console.WriteLine("Allenatore: ");
			this.Allenatore.Visualizza("allenatore");
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("Stadio: " + this.Stadio);
			Console.WriteLine();
			Console.WriteLine("Rosa: ");
            for (int i = 0; i < NumeroGiocatori; i++)
            {
				if (Giocatori[i] == null) continue;
				Console.Write(this.Giocatori[i].Cognome + " " + this.Giocatori[i].Nome + " || ");
				if (i % 2 == 0) Console.WriteLine();
            }
			Console.ReadKey();
		}
		public void Visualizza1()
		{
			int index = 0, indexCopy;
			var persone = new List<Persona>() { Presidente, Allenatore };
			foreach(var giocatore in Giocatori)persone.Add(giocatore);
			Console.Clear();
			persone[0].Visualizza("presidente", false);
			var key = ConsoleKey.B;
			do
			{
				indexCopy = index;
				if (Console.KeyAvailable)
				{
					key = Console.ReadKey(true).Key;
					if (key == ConsoleKey.W | key == ConsoleKey.UpArrow) index = index - 1 < 0 ? persone.Count - 1 : index - 1;
					else if (key == ConsoleKey.S | key == ConsoleKey.DownArrow) index = index + 1 > persone.Count - 1 ? 0 : index + 1;
				}
				if (indexCopy != index)
				{
					Console.Clear();
					persone[index].Visualizza(index == 0 ? "presidente" : index == 1 ? "allenatore" : "giocatore", false);
				}
			} while (key != ConsoleKey.Enter & key != ConsoleKey.Escape);
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

		public void ModificaGiocatore(String _CF)
        {
			if (this.Presidente.CodiceFiscale == _CF) { this.Presidente.Visualizza(); this.Presidente.ModificaPersona(); }
			else if (this.Allenatore.CodiceFiscale == _CF) { this.Allenatore.Visualizza(); this.Allenatore.ModificaPersona(); }
			else
            {
                foreach (Persona giocatore in this.Giocatori)
                {
					if (giocatore.CodiceFiscale == _CF) {giocatore.Visualizza(); giocatore.ModificaPersona(); }
                }
            }
        }
	}
}
