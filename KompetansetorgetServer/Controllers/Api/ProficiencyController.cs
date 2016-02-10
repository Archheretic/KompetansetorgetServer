using System;
using System.Web.Http;
using KompetansetorgetServer.ContextDbs;
using KompetansetorgetServer.Models;
using System.Linq;
using System.Web.Http.Description;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Net;

namespace KompetansetorgetServer
{
	public class ProficiencyController : ApiController
	{
		private KompetanseContext db;

		public ProficiencyController ()
		{
			this.db = new KompetanseContext();
		}

		public IQueryable<Proficiency> GetProficiencys()
		{
			return db.Proficiencies;
		}

		// GET: api/Proficiencys/5
		[ResponseType(typeof(Proficiency))]
		public IHttpActionResult GetProficiency(int id)
		{
			Proficiency proficiency = db.Proficiencies.Find(id);
			if (proficiency == null)
			{
				return NotFound();
			}

			return Ok(proficiency);
		}

		// PUT: api/Proficiencys/5
		[ResponseType(typeof(void))]
		public IHttpActionResult PutProficiency(int id, Proficiency proficiency)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id != proficiency.Id)
			{
				return BadRequest();
			}

			db.Entry(proficiency).State = EntityState.Modified;

			try
			{
				db.SaveChanges();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ProficiencyExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return StatusCode(HttpStatusCode.NoContent);
		}

		private bool ProficiencyExists(int id)
		{
			return db.Proficiencies.Count(e => e.Id == id) > 0;
		}
	}
}
