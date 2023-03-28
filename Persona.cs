using System;

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
			CodiceFiscale = codiceFiscale;
			DataNascita = dataNascita;
		}
		public void Visualizza(string ruolo = "sfigato")
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
			Graphic.Corner(1, 1, 20, 12, ConsoleColor.White, 1);
			Graphic.Rect(24, 5, "NOME: ", setBG: false, fg: ConsoleColor.White);
			Graphic.Rect(41, 5, $"{Nome}", setBG:false, fg:ConsoleColor.White);
			Graphic.Rect(24, 7, "COGNOME: ", setBG: false, fg: ConsoleColor.White);
			Graphic.Rect(41, 7, $"{Cognome}", setBG: false, fg:ConsoleColor.White);
			Graphic.Rect(24, 9, "DATA DI NASCITA: ", setBG: false, fg: ConsoleColor.White);
			Graphic.Rect(41, 9, $"{DataNascita.ToString("dd/MM/yyyy")}", setBG:false, fg:ConsoleColor.White);
			Graphic.Rect(24, 11, "CODICE FISCALE: ", setBG: false, fg: ConsoleColor.White);
			Graphic.Rect(41, 11, $"{CodiceFiscale}", setBG:false, fg:ConsoleColor.White);
			Graphic.Rect(1, 14, "PRESS ANY KEY TO COME BACK", setBG: false, fg: ConsoleColor.White);
			Console.ReadKey();
		}
	}
}
