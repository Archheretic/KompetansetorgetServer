using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using KompetansetorgetServer.Models;
using System.Text;

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
                jt.name,
                jt.type
            });
        }

        [HttpGet, Route("api/v1/jobtypes/hash")]
        //[ResponseType(typeof(JobType))]
        public async Task<IHttpActionResult> GetLocationsHash()
        {
            var result = from jobType in db.jobTypes select jobType;
            List<JobType> jobTypeList = result.OrderBy(jt => jt.id).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var jobType in jobTypeList)
            {
                sb.Append(jobType.id);
            }
            string hash = CalculateMD5Hash(sb.ToString());

            return Ok(new
            {
                hash
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
                jobType.name,
                jobType.type
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

        /// <summary>
        /// Used to create a 32 bit hash of all the projects uuid,
        /// used as part of the cache strategy.
        /// This is not to create a safe encryption, but to create a hash that im
        /// certain that the php backend can replicate.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string CalculateMD5Hash(string input)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}