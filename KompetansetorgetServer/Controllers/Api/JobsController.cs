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
using Microsoft.Ajax.Utilities;

namespace KompetansetorgetServer.Controllers.Api
{
    public class JobsController : ApiController
    {
        private KompetansetorgetServerContext db = new KompetansetorgetServerContext();

        // [HttpGet, Route("api/jobs")]
        public IQueryable Get(string types = "", string study_group = "", string locations = "")
        {
            if (!types.IsNullOrWhiteSpace())
            {
                return GetJobByType(types);
            }

            if (!study_group.IsNullOrWhiteSpace())
            {
                return GetJobByStudy(study_group);
            }

            if (!locations.IsNullOrWhiteSpace())
            {
                return GetJobByLocation(locations);
            }

            return GetJobs();
        }

        // GET: api/Jobs
        //public IQueryable<Job> GetJobs()
        /// <summary>
        /// This method is called if no query strings are presented
        /// </summary>
        /// <returns></returns>
        private IQueryable GetJobs()
        {
            //return db.Jobs;
            return db.Jobs.Select(s => new
            {
                s.Uuid,
                s.Description,
                s.Webpage,
                s.Expiry_date,
                s.Steps_to_apply,
                s.Created,
                s.Published,
                s.Modified,
                s.IdContact,
                s.IdJobType,
                s.IdLocation,
                s.IdCompany,
                Study_groups = s.Study_groups.Select(st => new { st.IdStudy_group })
            });
        }

        // GET: api/Jobs/5
        // Example: /api/jobs/2c70edff-edbe-4d6d-8e79-10a47f330feb
        [ResponseType(typeof(Job))]
        public async Task<IHttpActionResult> GetJob(string id)
        {
            Job job = await db.Jobs.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }

            //return Ok(job);
            return Ok(new
            {
                job.Uuid,
                job.Description,
                job.Webpage,
                job.Expiry_date,
                job.Steps_to_apply,
                job.Created,
                job.Published,
                job.Modified,
                job.IdContact,
                job.IdJobType,
                job.IdLocation,
                job.IdCompany,
                Study_groups = job.Study_groups.Select(st => new { st.IdStudy_group })
            });
        }

        /// <summary>
        /// Lists all jobs that contains that spesific Study_group. 
        /// GET: api/jobs?study_group=datateknologi
        /// GET: api/jobs?study_group=idrettsfag
        /// </summary>
        /// <param name="study_group">the Study_group identificator</param>
        /// <returns></returns> 
       // [HttpGet, Route("api/jobs")]
        private IQueryable GetJobByStudy(string study_group = "")
        {
            if (study_group.IsNullOrWhiteSpace())
            {
                return GetJobs();
            }

            var jobs = from job in db.Jobs               //IdStudy_group is a string primary key
                       where job.Study_groups.Any(s => s.IdStudy_group.Equals(study_group))
                       select job;

            return jobs.Select(s => new
            {
                s.Uuid,
                s.Description,
                s.Webpage,
                s.Expiry_date,
                s.Steps_to_apply,
                s.Created,
                s.Published,
                s.Modified,
                s.IdContact,
                s.IdJobType,
                s.IdLocation,
                s.IdCompany,
                Study_groups = s.Study_groups.Select(st => new { st.IdStudy_group })
            });
        }


        /// <summary>
        /// Lists all jobs that contains that spesific Type (full time and part time jobs). 
        /// GET: api/jobs?types=heltid
        /// GET: api/jobs?types=deltid
        /// </summary>
        /// <param name="types">the JobTypes identificator</param>
        /// <returns></returns> 
       // [HttpGet, Route("api/jobs")]
        private IQueryable GetJobByType(string types = "")
        {
            if (types.IsNullOrWhiteSpace())
            {
                return GetJobs();
            }

            var jobs = from job in db.Jobs               //IdStudy_group is a string primary key
                       where job.IdJobType.Equals(types)
                       select job;

            return jobs.Select(s => new
            {
                s.Uuid,
                s.Description,
                s.Webpage,
                s.Expiry_date,
                s.Steps_to_apply,
                s.Created,
                s.Published,
                s.Modified,
                s.IdContact,
                s.IdJobType,
                s.IdLocation,
                s.IdCompany,
                Study_groups = s.Study_groups.Select(st => new { st.IdStudy_group })
            });
        }


        /// <summary>
        /// Lists all jobs that contains that spesific Location. 
        /// GET: api/jobs?locations=vestagder
        /// GET: api/jobs?locations=austagder
        /// </summary>
        /// <param name="locations">the Locations identificator</param>
        /// <returns></returns> 
        private IQueryable GetJobByLocation(string locations = "")
        {
            if (locations.IsNullOrWhiteSpace())
            {
                return GetJobs();
            }

            var jobs = from job in db.Jobs               //IdStudy_group is a string primary key
                       where job.IdLocation.Equals(locations)
                       select job;

            return jobs.Select(s => new
            {
                s.Uuid,
                s.Description,
                s.Webpage,
                s.Expiry_date,
                s.Steps_to_apply,
                s.Created,
                s.Published,
                s.Modified,
                s.IdContact,
                s.IdJobType,
                s.IdLocation,
                s.IdCompany,
                Study_groups = s.Study_groups.Select(st => new { st.IdStudy_group })
            });
        }


        // PUT: api/Jobs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutJob(string id, Job job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != job.Uuid)
            {
                return BadRequest();
            }

            db.Entry(job).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobExists(id))
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

        // POST: api/Jobs
        [ResponseType(typeof(Job))]
        public async Task<IHttpActionResult> PostJob(Job job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Jobs.Add(job);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (JobExists(job.Uuid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = job.Uuid }, job);
        }

        // DELETE: api/Jobs/5
        [ResponseType(typeof(Job))]
        public async Task<IHttpActionResult> DeleteJob(string id)
        {
            Job job = await db.Jobs.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }

            db.Jobs.Remove(job);
            await db.SaveChangesAsync();

            return Ok(job);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JobExists(string id)
        {
            return db.Jobs.Count(e => e.Uuid == id) > 0;
        }
    }
}