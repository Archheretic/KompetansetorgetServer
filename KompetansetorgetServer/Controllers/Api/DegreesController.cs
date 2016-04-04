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
    public class DegreesController : ApiController
    {
        private KompetansetorgetServerContext db = new KompetansetorgetServerContext();

        // GET: api/Degrees
        public IQueryable GetDegrees()
        {
            return db.degrees.Select(d => new
            {
                d.id,
                d.name
            });
        }

        // GET: api/Degrees/5
        [ResponseType(typeof(Degree))]
        public async Task<IHttpActionResult> GetDegree(string id)
        {
            Degree degree = await db.degrees.FindAsync(id);
            if (degree == null)
            {
                return NotFound();
            }

            return Ok(new {
                degree.id,
                degree.name
            });
        }

        // PUT: api/Degrees/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDegree(string id, Degree degree)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != degree.id)
            {
                return BadRequest();
            }

            db.Entry(degree).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DegreeExists(id))
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

        // POST: api/Degrees
        [ResponseType(typeof(Degree))]
        public async Task<IHttpActionResult> PostDegree(Degree degree)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.degrees.Add(degree);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DegreeExists(degree.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = degree.id }, degree);
        }

        // DELETE: api/Degrees/5
        [ResponseType(typeof(Degree))]
        public async Task<IHttpActionResult> DeleteDegree(string id)
        {
            Degree degree = await db.degrees.FindAsync(id);
            if (degree == null)
            {
                return NotFound();
            }

            db.degrees.Remove(degree);
            await db.SaveChangesAsync();

            return Ok(degree);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DegreeExists(string id)
        {
            return db.degrees.Count(e => e.id == id) > 0;
        }
    }
}