using Postgrest.Attributes;
using Postgrest.Models;

namespace GestioneCampionato.Modelli;

[Table("persone")]
public class Persona : BaseModel
{
	[PrimaryKey("id")]
	public int Id { get; set; }

	[Column("nome")]
	public string Nome { get; set; }

	[Column("cognome")]
	public string Cognome { get; set; }

	[Column("data_nascita")]
	public DateTime DataNascita { get; set; }
	[Column("luogo_nascita")]
	public string LuogoNascita { get; set; }
	public void Visualizza()
	{
		Console.WriteLine(Nome + " " + Cognome);
	}
}