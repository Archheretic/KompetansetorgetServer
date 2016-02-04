using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KompetansetorgetServer.Models
{
	[Table("Student")]
	public class Student 
	{
		public Student()
		{
		}
		[Key]
		[Column("username")]
		public string Username { get; set; }

		[Column("firstName")]
		public string FirstName { get; set; }

		[Column("lastName")]
		public string LastName { get; set; }

		[Column("email")]
		public string Email { get; set; }

		[Column("idProficiency")]
		[ForeignKey("Proficiency")]
		public int IdProficiency { get; set; }

		public Proficiency Proficiency { get; set; }
	}
}

