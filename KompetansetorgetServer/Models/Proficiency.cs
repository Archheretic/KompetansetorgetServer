using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KompetansetorgetServer.Models
{
	[Table("Proficiency")]
	public class Proficiency
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("administasjon")]
		public bool Administasjon { get; set; }

		[Column("datateknologi")]
		public bool Datateknologi { get; set; }

		[Column("helse")]
		public bool Helse { get; set; }

		[Column("historie")]
		public bool Historie { get; set; }

		[Column("ingenior")]
		public bool Ingenior { get; set; }

		[Column("idrettsfag")]
		public bool Idrettsfag { get; set; }

		[Column("kunstfag")]
		public bool Kunstfag { get; set; }

		[Column("lerer")]
		public bool Lerer { get; set; }

		[Column("medie")]
		public bool Medie { get; set; }

		[Column("musikk")]
		public bool Musikk { get; set; }

		[Column("realfag")]
		public bool Realfag { get; set; }

		[Column("samfunnsfag")]
		public bool Samfunnsfag { get; set; }

		[Column("sprak")]
		public bool Sprak { get; set; }

		[Column("okonomi")]
		public bool Okonomi { get; set; }

		[Column("uspesifisert")]
		public bool Uspesifisert { get; set; }
	}
}