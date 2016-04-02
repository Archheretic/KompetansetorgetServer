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
    public class JobTypesController : ApiController
    {
        private KompetansetorgetServerContext db = new KompetansetorgetServerContext();

        // GET: api/jobTypes
        public IQueryable GetJobTypes() { 
            return db.jobTypes.Select(jt => new
            {
                jt.id,
                jt.name
            });
        }

        // GET: api/jobTypes/5
        [ResponseType(typeof(JobType))]
        public async Task<IHttpActionResult> GetJobType(string id)
        {
            JobType jobType = await db.jobTypes.FindAsync(id);
            if (jobType == null)
            {
                return NotFound();
            }

            return Ok( new {
                jobType.id,
                jobType.name
            });
        }

        // PUT: api/jobTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutJobType(string id, JobType jobType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jobType.id)
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

        // POST: api/jobTypes
        [ResponseType(typeof(JobType))]
        public async Task<IHttpActionResult> PostJobType(JobType jobType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.jobTypes.Add(jobType);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (JobTypeExists(jobType.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = jobType.id }, jobType);
        }

        // DELETE: api/jobTypes/5
        [ResponseType(typeof(JobType))]
        public async Task<IHttpActionResult> DeleteJobType(string id)
        {
            JobType jobType = await db.jobTypes.FindAsync(id);
            if (jobType == null)
            {
                return NotFound();
            }

            db.jobTypes.Remove(jobType);
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
            return db.jobTypes.Count(e => e.id == id) > 0;
        }
    }
}