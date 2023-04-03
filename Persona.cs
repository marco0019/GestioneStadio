using System;
using System.Linq;

namespace GestioneCampionato
{
	class Persona
	{
		public string Nome { get; private set; }
		public string Cognome { get; private set; }
		public string CodiceFiscale { get; private set; }
		public DateTime DataNascita { get; private set; }
		public Persona(string nome, string cognome, string codiceFiscale, DateTime dataNascita)
		{
			Nome = nome;
			Cognome = cognome;
			DataNascita = dataNascita;
			CodiceFiscale = MakeCF(this);
		}
		public void Visualizza(string ruolo = "sfigato", bool key = true)
		{
			Graphic.Clear();
			Graphic.WindowSize(72, 16);
			Graphic.Word(24, 1, ruolo, 1);
			Graphic.Rect(0, 1, text:@"
        _____
       \ *** \     
     \ ******* \   
    \ ********* \  
   /\* ### ### */\
   |    @ / @    |
   \/\    ^    /\/
      \  ===  /   
       \_____/    
        _|_|_     
     *$$$$$$$$$*   ", setBG:false, fg:ConsoleColor.White);
			Graphic.Corner(0, 0, 70, 15, ConsoleColor.White);
			Graphic.Corner(1, 1, 20, 12, ConsoleColor.White);
			Graphic.Rect(24, 5, "NOME: ", setBG: false, fg: ConsoleColor.White);
			Graphic.Rect(41, 5, $"{Nome}", setBG:false, fg:ConsoleColor.White);
			Graphic.Rect(24, 7, "COGNOME: ", setBG: false, fg: ConsoleColor.White);
			Graphic.Rect(41, 7, $"{Cognome}", setBG: false, fg:ConsoleColor.White);
			Graphic.Rect(24, 9, "DATA DI NASCITA: ", setBG: false, fg: ConsoleColor.White);
			Graphic.Rect(41, 9, $"{DataNascita.ToString("dd/MM/yyyy")}", setBG:false, fg:ConsoleColor.White);
			Graphic.Rect(24, 11, "CODICE FISCALE: ", setBG: false, fg: ConsoleColor.White);
			Graphic.Rect(41, 11, $"{CodiceFiscale}", setBG:false, fg:ConsoleColor.White);
			if (key)
			{
				Graphic.Rect(1, 14, "PRESS ANY KEY TO COME BACK", setBG: false, fg: ConsoleColor.White);
				Console.ReadKey();
			}
		}

		public void ModificaPersona()
        {
			Console.Write("Cognome: ");
			this.Cognome = Console.ReadLine().Trim();
			Console.Write("Nome: ");
			this.Nome = Console.ReadLine().Trim();
			Console.Write("Data di nascita: ");
			this.DataNascita = Convert.ToDateTime(Console.ReadLine().Trim());
			CodiceFiscale = MakeCF(this);
        }
		public string MakeCF(Persona persona)
		{
			string mese = "ABCDEHLMPRST";

			int[,] codici = { { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }, { 1, 0, 5, 7, 9, 13, 15, 17, 19, 21, 1, 0, 5, 7, 9, 13, 15, 17, 19, 21, 2, 4, 18, 20, 11, 3, 6, 8, 12, 14, 16, 10, 22, 25, 24, 23 } };
			// Nome e cognome
			string cf = GetName(persona.Cognome) + GetName(persona.Nome);
			// Anno
			cf += persona.DataNascita.ToString("yy");
			// Mese in lettera
			cf += mese[Convert.ToInt16(persona.DataNascita.ToString("MM")) - 1];
			// Giorno
			cf += persona.DataNascita.ToString("dd");
			// Comune di nascita estratto casualmente
			string alfabeto = "abcdefghijklmn";
			cf += alfabeto[new Random().Next(0, alfabeto.Length)].ToString();
			cf += new Random().Next(100, 1000).ToString();
			// Codice di verifica
			int contains(char charapter)
			{
				string lettere = "0123456789abcdefghijklmnopqrstuvwxyz";
				for (int i = 0; i < lettere.Length; i++) if (charapter.ToString().ToLower() == lettere[i].ToString().ToLower()) return i;
				return 0;
			}
			int count = 0;
			for (int i = 0; i < cf.Length; i++) count += codici[i % 2, contains(cf[i])];
			cf += alfabeto[count % alfabeto.Length].ToString();
			return cf.ToUpper();
		}
		string GetName(string name)
		{
			name = name.Trim();
			string result = "";
			if (name.Length < 3)
			{
				for (int i = 0; i < name.Length; i++) result += name[i];
				result = formatWithX(result);
			}
			else
			{
				// Mette tutte le vocali
				string consonanti = GetWord(name);
				string vocali = GetWord(name, false);
				if (consonanti.Length >= 3) result = consonanti.Substring(0, 3);
				else if(vocali.Length >= 3 - consonanti.Length)result = consonanti + vocali.Substring(0, 3 - consonanti.Length);
				else result = formatWithX(consonanti + vocali);
			}
			string formatWithX(string word)// Aggiunge le X se il nome dovesse essere troppo corto
			{
				for (int i = 0; i <= 3 - word.Length; i++) word += "X";
				return word;
			}
			return result;
		}
		string GetWord(string name, bool consonanti = true)
		{
			string vocali = "aeiouhy ";
			var result = "";
			if (consonanti) { for (int i = 0; i < name.Length; i++) if (!vocali.Contains(name[i])) result += name[i].ToString(); }
			else for (int i = 0; i < name.Length; i++) if (vocali.Contains(name[i])) result += name[i].ToString();
			return result;
		}
	}
}
