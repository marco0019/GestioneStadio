using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneCampionato
{
	class Persona
	{
		private string nome, cognome, codiceFiscale;
		private DateTime dataNascita;
		public string Nome { get=>nome; }
		public string Cognome { get => cognome; }
		public string CodiceFiscale { get => codiceFiscale; }
		public DateTime DataNascita { get => dataNascita; }
		public Persona(string nome, string cognome, string codiceFiscale, DateTime dataNascita)
		{
			this.nome = nome;
			this.cognome = cognome;
			this.codiceFiscale = codiceFiscale;
			this.dataNascita = dataNascita;
		}
	}
}
