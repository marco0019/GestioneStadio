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
		public void Visualizza()
		{

		}
	}
}
