using System;
using System.Data.Entity;
using System.Data.Common;
using KompetansetorgetServer.Models;
using MySql.Data.Entity;

namespace KompetansetorgetServer.ContextDbs
{
	public class KompetanseContext : DbContext
	{
		public KompetanseContext () : base("connStr")
		{
		}
		public KompetanseContext (DbConnection existingConnection, bool contextOwnsConnection)
			: base(existingConnection, contextOwnsConnection)
		{
			
		}

		public DbSet<Student> Students { get; set; }
		public DbSet<Proficiency> Proficiencies { get; set; }
	}
}
