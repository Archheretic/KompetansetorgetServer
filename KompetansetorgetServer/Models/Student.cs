using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace KompetansetorgetServer.Models
{
	[Table("Student")]
	public class Student 
	{
		public Student()
		{
		}
		[Column("id")]
		public int Id { get; set; }

		[Column("firstName")]
		public string FirstName { get; set; }

		[Column("lastName")]
		public string LastName { get; set; }

		[Column("email")]
		public string Email { get; set; }
	}
}

