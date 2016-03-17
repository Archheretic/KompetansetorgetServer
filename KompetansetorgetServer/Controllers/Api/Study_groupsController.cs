using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using KompetansetorgetServer.Models;

namespace KompetansetorgetServer.Controllers.Api
{
    public class Study_groupsController : ApiController
    {
        private KompetansetorgetServerContext db = new KompetansetorgetServerContext();

        // GET: api/Study_groups
        public IQueryable<Study_group> GetStudy_group()
        {
            return db.Study_group;
        }

        // GET: api/Study_groups/5
        [ResponseType(typeof(Study_group))]
        public async Task<IHttpActionResult> GetStudy_group(string id)
        {
            Study_group study_group = await db.Study_group.FindAsync(id);
            if (study_group == null)
            {
                return NotFound();
            }

            return Ok(study_group);
        }

        // PUT: api/Study_groups/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStudy_group(string id, Study_group study_group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != study_group.IdStudy_group)
            {
                return BadRequest();
            }

            db.Entry(study_group).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Study_groupExists(id))
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

        // POST: api/Study_groups
        [ResponseType(typeof(Study_group))]
        public async Task<IHttpActionResult> PostStudy_group(Study_group study_group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Study_group.Add(study_group);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Study_groupExists(study_group.IdStudy_group))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = study_group.IdStudy_group }, study_group);
        }

        // DELETE: api/Study_groups/5
        [ResponseType(typeof(Study_group))]
        public async Task<IHttpActionResult> DeleteStudy_group(string id)
        {
            Study_group study_group = await db.Study_group.FindAsync(id);
            if (study_group == null)
            {
                return NotFound();
            }

            db.Study_group.Remove(study_group);
            await db.SaveChangesAsync();

            return Ok(study_group);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Study_groupExists(string id)
        {
            return db.Study_group.Count(e => e.IdStudy_group == id) > 0;
        }
    }
}