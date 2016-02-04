using System;
using System.Data.Entity;
using System.Data.Common;
using KompetansetorgetServer.Models;
using MySql.Data.Entity;

namespace KompetansetorgetServer.ContextDbs
{
	public class ProficiencyContext : DbContext
	{
		public ProficiencyContext () : base("connStr")
		{
		}
		public ProficiencyContext (DbConnection existingConnection, bool contextOwnsConnection)
			: base(existingConnection, contextOwnsConnection)
		{

		}

		public DbSet<Proficiency> Proficiencies { get; set; }
	}
}

