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
using System.Web.UI.WebControls.WebParts;
using KompetansetorgetServer.Models;
using Microsoft.Ajax.Utilities;

namespace KompetansetorgetServer.Controllers.Api
{
    public class JobsController : ApiController
    {
        private KompetansetorgetServerContext db = new KompetansetorgetServerContext();

        // [HttpGet, Route("api/jobs")]
        // Activates the correct method based on query string parameters.
        // At the moment you can not use a combination of different strings (other then orderBy and sortBy)
        public IQueryable Get(string types = "", [FromUri] string[] studyGroups = null, string locations = "",
            string titles = "", string orderBy = "", string sortBy = "", [FromUri] string[] fields = null)
        {
            if (!types.IsNullOrWhiteSpace())
            {
                IQueryable<Job> jobs = GetJobsByType(types);
                if (orderBy.Equals("desc") || orderBy.Equals("asc"))
                {
                   return GetJobsSorted(jobs, orderBy, sortBy);
                }
                return GetJobsSerialized(jobs);

            }

            if (studyGroups.Length != 0)
            {
               // int i = studyGroups.Length;
                IQueryable<Job> jobs = GetJobsByStudy(studyGroups);
                if (orderBy.Equals("desc") || orderBy.Equals("asc"))
                    {
                    return GetJobsSorted(jobs, orderBy, sortBy);
                }
                return GetJobsSerialized(jobs);
            }

            if (fields.Length == 2)
            {
                if (!fields[0].Equals("cname") || !fields[1].Equals("clogo"))
                {
                    return GetJobs();
                }
                // int i = studyGroups.Length;
                return GetJobsWithFields(fields);
            }

            if (!locations.IsNullOrWhiteSpace())
            {
                IQueryable<Job> jobs = GetJobsByLocation(locations);
                if (orderBy.Equals("desc") || orderBy.Equals("asc"))
                {
                    return GetJobsSorted(jobs, orderBy, sortBy);
                }
                return GetJobsSerialized(jobs);
            }

            if (!titles.IsNullOrWhiteSpace())
            {
                IQueryable<Job> jobs = GetJobsByTitle(titles);
                if (orderBy.Equals("desc") || orderBy.Equals("asc"))
                {
                    return GetJobsSorted(jobs, orderBy, sortBy);
                }
                return GetJobsSerialized(jobs); 
            }

            if (orderBy.Equals("desc") || orderBy.Equals("asc"))
                {
                return GetJobsSorted(orderBy, sortBy);
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
            var jobs = from job in db.jobs select job;
            return GetJobsSerialized(jobs);
        }

        // GET: api/Jobs/5
        // Example: /api/jobs/2c70edff-edbe-4d6d-8e79-10a47f330feb
        [HttpGet, Route("api/v1/jobs/{id}")]
        [ResponseType(typeof (Job))]
        public async Task<IHttpActionResult> GetJob(string id, string minNot = "")
        {
            Job job = await db.jobs.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }


            if (!minNot.Equals("true"))
            {
                //return Ok(job);
                return Ok(new
                {
                    job.uuid,
                    job.title,
                    job.description,
                    job.webpage,
                    job.linkedInProfile,
                    job.expiryDate,
                    job.stepsToApply,
                    job.created,
                    job.published,
                    job.modified,
                    companies = job.companies.Select(c => new {c.id}),
                    contacts = job.contacts.Select(c => new {c.id}),
                    locations = job.locations.Select(l => new {l.id}),
                    jobTypes = job.jobTypes.Select(jt => new {jt.id}),
                    studyGroups = job.studyGroups.Select(st => new {st.id})
                });
            }
            else
            {
                return Ok(new
                {
                    job.uuid,
                    job.title,
                    job.webpage,
                    job.published,
                    companies = job.companies.Select(c => new {c.id, c.name, c.logo})
                });
            }
        }

        /// <summary>
        /// Lists all jobs that contains that spesific Location. 
        /// GET: api/jobs?locations=vestagder
        /// GET: api/jobs?locations=austagder
        /// </summary>
        /// <param name="locations">the locations identificator</param>
        /// <returns></returns> 
        private IQueryable<Job> GetJobsByLocation(string locations = "")
        {
            var jobs = from job in db.jobs
                       where job.locations.Any(l => l.id.Equals(locations))
                       select job;

            return jobs;
        }

        /// <summary>
        /// Lists all jobs that contains that spesific StudyGroup. 
        /// GET: api/jobs?studyGroups=datateknologi
        /// GET: api/jobs?studyGroups=idrettsfag
        /// Also supports combinations:
        /// GET: api/jobs/?studygroups=idrettsfag&studygroups=lærerutdanning
        /// </summary>
        /// <param name="studyGroups">the StudyGroup identificator</param>
        /// <returns></returns> 
       // [HttpGet, Route("api/jobs")]
        private IQueryable<Job> GetJobsByStudy(string[] studyGroups = null)
        {
            var jobs = from job in db.jobs               
                       where job.studyGroups.Any(s => studyGroups.Contains(s.id))
                       select job;

            return jobs;
        }

        /// <summary>
        /// List all jobs that contain that exact title (could be improved upon)
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        private IQueryable<Job> GetJobsByTitle(string titles)
        {
            // Delimiter % should be reviewed for change.
            titles = titles.Replace("%", " ");
            var jobs = from job in db.jobs               
                       where job.title.Equals(titles)
                       select job;
            
            return jobs;
        }
    

        /// <summary>
        /// Lists all jobs that contains that spesific JobType (full time and part time jobs). 
        /// GET: api/jobs?types=heltid
        /// GET: api/jobs?types=deltid
        /// </summary>
        /// <param name="types">the jobTypes identificator</param>
        /// <returns></returns> 
       // [HttpGet, Route("api/jobs")]
        private IQueryable<Job> GetJobsByType(string types = "")
        {
            var jobs = from job in db.jobs               
                       where job.jobTypes.Any(jt => jt.id.Equals(types))
                       select job;

            return jobs;
        }

        /// <summary>
        /// Lists all jobs with the respective companies names and logo. 
        /// GET: api/jobs?fields=cname&fields=clogo
        /// </summary>
        private IQueryable GetJobsWithFields(String[] fields)
        {
            var jobs = from job in db.jobs select job;

            return jobs.Select(j => new
            {
                j.uuid,
                j.title,
                j.description,
                j.webpage,
                j.linkedInProfile,
                j.expiryDate,
                j.stepsToApply,
                j.created,
                j.published,
                j.modified,
                companies = j.companies.Select(c => new { c.id, c.name, c.logo }),
                locations = j.locations.Select(l => new { l.id }),
                jobTypes = j.jobTypes.Select(jt => new { jt.id }),
                studyGroups = j.studyGroups.Select(st => new { st.id })
            });

        }

        /// <summary>
        /// Serializes the job object for json.
        /// </summary>
        /// <param name="jobs"></param>
        /// <returns></returns> 
        private IQueryable GetJobsSerialized(IQueryable<Job> jobs)
        {
            return jobs.Select(j => new
            {
                j.uuid,
                j.title,
                j.description,
                j.webpage,
                j.linkedInProfile,
                j.expiryDate,
                j.stepsToApply,
                j.created,
                j.published,
                j.modified,
                companies = j.companies.Select(c => new { c.id }),
                locations = j.locations.Select(l => new { l.id }),
                jobTypes = j.jobTypes.Select(jt => new { jt.id }),
                studyGroups = j.studyGroups.Select(st => new { st.id })
            });
        }

        /// <summary>
        /// List jobs in a ascending or descending order based on sortBy parameter.
        /// Examples for use:
        /// GET: api/jobs/?location=vestagder&orderby=asc&sortby=published
        /// GET: api/jobs/?type=deltid&orderby=desc&sortby=expirydate

        /// </summary>
        /// <param name="queryResult">A result of a query in table Jobs</param>
        /// <param name="orderBy">asc = ascending 
        ///                       desc = descending</param>
        /// <param name="sortBy">published = the date a job was published
        ///                      expirydate = the last date to apply for the job</param>
        /// <returns></returns>
        private IQueryable GetJobsSorted(IQueryable<Job> queryResult, string orderBy = "", string sortBy = "")
        {
            var jobs = queryResult.Select(j => new
            {
                j.uuid,
                j.title,
                j.description,
                j.webpage,
                j.linkedInProfile,
                j.expiryDate,
                j.stepsToApply,
                j.created,
                j.published,
                j.modified,
                companies = j.companies.Select(c => new { c.id }),
                locations = j.locations.Select(l => new { l.id }),
                jobTypes = j.jobTypes.Select(jt => new { jt.id }),
                studyGroups = j.studyGroups.Select(st => new { st.id })
            });

            if (orderBy.Equals("desc"))
            {
                switch (sortBy)
                {
                    case "expirydate":
                        jobs = jobs.OrderByDescending(j => j.expiryDate);
                        return jobs;
                    case "published":
                        jobs = jobs.OrderByDescending(j => j.published);
                        return jobs;

                    default:
                        return GetJobs();
                }
            }

            switch (sortBy)
            {
                case "expirydate":
                    jobs = jobs.OrderBy(j => j.expiryDate);
                    return jobs;
                case "published":
                    jobs = jobs.OrderBy(j => j.published);
                    return jobs;

                default:
                    return GetJobs();
            }
        }

        /// <summary>
        /// List jobs in a ascending or descending order based on sortBy parameter.
        /// GET: api/jobs/?orderby=asc&sortby=published
        /// GET: api/jobs/?orderby=desc&sortby=expirydate
        /// 
        /// Deprecated, no longer working:
        /// GET: api/jobs/?orderby=desc&sortby=locations
        /// GET: api/jobs/?orderby=desc&sortby=studyGroups
        /// </summary>
        /// <param name="orderBy"></param>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        private IQueryable GetJobsSorted(string orderBy = "", string sortBy = "")
        {

            var queryResult = from job in db.jobs select job;

            // Won't work due to incompatible return type.
            //GetJobsSerialized(jobs1)

            var jobs = queryResult.Select(j => new
                {
                j.uuid,
                j.title,
                j.description,
                j.webpage,
                j.linkedInProfile,
                j.expiryDate,
                j.stepsToApply,
                j.created,
                j.published,
                j.modified,
                companies = j.companies.Select(c => new { c.id }),
                locations = j.locations.Select(l => new { l.id }),
                jobTypes = j.jobTypes.Select(jt => new { jt.id }),
                studyGroups = j.studyGroups.Select(st => new { st.id })
            });

            if (orderBy.Equals("desc"))
            {
                switch (sortBy)
                {
                    case "expirydate":
                        jobs = jobs.OrderByDescending(j => j.expiryDate);
                        return jobs;
                    case "published":
                        jobs = jobs.OrderByDescending(j => j.published);
                        return jobs;

                    /*
                    case "types":
                        jobs = jobs.OrderByDescending(j => j.uuid );
                        return jobs;
                    case "locations":
                        jobs = jobs.OrderByDescending(j => j.uuid);
                        return jobs;
                    case "studyGroups":

                        jobs = jobs.OrderByDescending(j => j.studyGroups.Select(sg => new { sg.id }));
                        //jobs = jobs.OrderByDescending(j => j.studyGroups.id);
                        //jobs = jobs.OrderByDescending(j => j.studyGroups.Select(sg => new { sg.id }));
                        return jobs; 
                        */
                    default:
                        return GetJobs();
                }
            }

            switch (sortBy)
            {
                case "expirydate":
                    jobs = jobs.OrderBy(j => j.expiryDate);
                    return jobs;
                case "published":
                    jobs = jobs.OrderBy(j => j.published);
                    return jobs;
                    
                // These are Not working anymore
                /*
                case "types":
                    jobs = jobs.OrderBy(j => j.jobTypes);
                    return jobs;
                case "locations":
                    jobs = jobs.OrderBy(j => j.locations);
                    return jobs;
                case "studygroups":
                    jobs = jobs.OrderBy(j => j.studyGroups);
                    return jobs;
                    */

                default:
                    return GetJobs();
            }      
        }


        // PUT: api/Jobs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutJob(string id, Job job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != job.uuid)
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

            db.jobs.Add(job);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (JobExists(job.uuid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = job.uuid }, job);
        }

        // DELETE: api/Jobs/5
        [ResponseType(typeof(Job))]
        public async Task<IHttpActionResult> DeleteJob(string id)
        {
            Job job = await db.jobs.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }

            db.jobs.Remove(job);
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
            return db.jobs.Count(e => e.uuid == id) > 0;
        }
    }
}