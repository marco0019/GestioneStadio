

using Postgrest.Attributes;

namespace GestioneCampionato.Modelli;

[Table("squadre")]
public class Squadra
{
	[PrimaryKey("Id")]
	public int Id { get; set; }

	[Column("nome")]
	public string Name { get; set; }

	[Column("stadio")]
	public string Stadio { get; set; }

	[Column("punteggio")]
	public int Punteggio { get; set; }

	[Column("presidente")]
	public int IDPresidente { get; set; }

	[Column("allenatore")]
	public int IDAllenatore { get; set; }
}