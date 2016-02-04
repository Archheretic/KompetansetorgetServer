using System;
using System.Data.Entity;
using System.Data.Common;
using KompetansetorgetServer.Models;
using MySql.Data.Entity;

namespace KompetansetorgetServer.ContextDbs
{
	public class StudentContext : DbContext
	{
		public StudentContext () : base("connStr")
		{
		}
		public StudentContext (DbConnection existingConnection, bool contextOwnsConnection)
			: base(existingConnection, contextOwnsConnection)
		{
			
		}

		public DbSet<Student> Students { get; set; }
	}
}
