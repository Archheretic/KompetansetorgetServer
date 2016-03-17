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
    public class TypesController : ApiController
    {
        private KompetansetorgetServerContext db = new KompetansetorgetServerContext();

        // GET: api/Types
        public IQueryable<JobType> GetJobTypes() { 
            return db.JobTypes;
        }

        // GET: api/Types/5
        [ResponseType(typeof(JobType))]
        public async Task<IHttpActionResult> GetJobType(string id)
        {
            JobType jobType = await db.JobTypes.FindAsync(id);
            if (jobType == null)
            {
                return NotFound();
            }

            return Ok(jobType);
        }

        // PUT: api/Types/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutJobType(string id, JobType jobType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jobType.IdJobType)
            {
                return BadRequest();
            }

            db.Entry(jobType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobTypeExists(id))
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

        // POST: api/Types
        [ResponseType(typeof(JobType))]
        public async Task<IHttpActionResult> PostJobType(JobType jobType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.JobTypes.Add(jobType);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (JobTypeExists(jobType.IdJobType))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = jobType.IdJobType }, jobType);
        }

        // DELETE: api/Types/5
        [ResponseType(typeof(JobType))]
        public async Task<IHttpActionResult> DeleteJobType(string id)
        {
            JobType jobType = await db.JobTypes.FindAsync(id);
            if (jobType == null)
            {
                return NotFound();
            }

            db.JobTypes.Remove(jobType);
            await db.SaveChangesAsync();

            return Ok(jobType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JobTypeExists(string id)
        {
            return db.JobTypes.Count(e => e.IdJobType == id) > 0;
        }
    }
}