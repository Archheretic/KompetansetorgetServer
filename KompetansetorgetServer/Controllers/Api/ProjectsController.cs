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

    public class ProjectsController : ApiController
    {
        private KompetansetorgetServerContext db = new KompetansetorgetServerContext();

        // [HttpGet, Route("api/projects")]
        // Activates the correct method based on query string parameters.
        // At the moment you can only use a combination of different strings if not combined with sortBy.
        /// Due to a realisation of need, all projects will be returned with fields clogo and cname regardless of if the call ask for it or not
        public IQueryable Get(string types = "", [FromUri] string[] studyGroups = null, [FromUri] string[] fields = null, string courses = "",
            string titles = "", string sortBy = "")
        {

            if ((studyGroups.Length != 0 && !types.IsNullOrWhiteSpace()) || 
                (studyGroups.Length != 0 && !courses.IsNullOrWhiteSpace()) || 
                (!types.IsNullOrWhiteSpace() && !courses.IsNullOrWhiteSpace()))
            {
                IQueryable<Project> projects = GetProjectsByMultiFilter(types, studyGroups, courses);
                if (fields.Length == 2)
                {
                    if (!fields[0].Equals("cname") || !fields[1].Equals("clogo"))
                    {
                        return GetSerializedWithFields(projects);
                    }
                }
                return GetProjectsSerialized(projects);
            }

            if (!types.IsNullOrWhiteSpace())
            {
                IQueryable<Project> projects = GetProjectsByType(types);
                if (sortBy.Equals("published") || sortBy.Equals("-published"))
                {
                    return GetProjectsSorted(projects, sortBy);
                }

                return GetProjectsSerialized(projects);

            }

            if (studyGroups.Length != 0)
            {
                int i = studyGroups.Length;
                IQueryable<Project> projects = GetProjectsByStudy(studyGroups);
                if (sortBy.Equals("published") || sortBy.Equals("-published"))
                {
                    return GetProjectsSorted(projects, sortBy);
                }
                return GetProjectsSerialized(projects);
            }

            if (!courses.IsNullOrWhiteSpace())
            {
                IQueryable<Project> projects = GetProjectsByCourse(courses);
                if (sortBy.Equals("published") || sortBy.Equals("-published"))
                {
                    return GetProjectsSorted(projects, sortBy);
                }
                return GetProjectsSerialized(projects);
            }

            if (!titles.IsNullOrWhiteSpace())
            {
                IQueryable<Project> projects = GetProjectsByTitle(titles);
                if (sortBy.Equals("published") || sortBy.Equals("-published"))
                {
                    return GetProjectsSorted(projects, sortBy);
                }
                return GetProjectsSerialized(projects);
            }

            if (fields.Length == 2)
            {
                if (!fields[0].Equals("cname") || !fields[1].Equals("clogo"))
                {
                    return GetProjects();
                }
                // int i = studyGroups.Length;
                return GetProjectsWithFields(fields);
            }

            if (sortBy.Equals("published") || sortBy.Equals("-published"))
            {
                return GetProjectsSorted(sortBy);
            }

            return GetProjects();
        }

        // GET: api/Projects
        //public IQueryable<Project> GetProjects()
        /// <summary>
        /// This method is called if no query strings are presented
        /// </summary>
        /// <returns></returns>
        private IQueryable GetProjects()
        {
            var projects = from project in db.projects select project;
            return GetProjectsSerialized(projects);
        }

        // GET: api/Projects/5
        // Example: /api/projects/    2c70edff-edbe-4d6d-8e79-10a47f330feb
        [HttpGet, Route("api/v1/projects/{id}")]
        [ResponseType(typeof(Project))]
        public async Task<IHttpActionResult> GetProject(string id, string minNot = "")
        {
            Project project = await db.projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            if (!minNot.Equals("true"))
            {
                return Ok(new
                {
                    project.uuid,
                    project.title,
                    //project.description,
                    project.webpage,
                    project.linkedInProfile,
                    project.stepsToApply,
                    project.created,
                    project.published,
                    project.modified,
                    project.status,
                    project.tutor,
                    companies = project.companies.Select(c => new { c.id, c.name, c.logo }),
                    contacts = project.contacts.Select(c => new {c.id}),
                    courses = project.courses.Select(c => new {c.id}),
                    approvedCourses = project.approvedCourses.Select(c => new {c.id}),
                    degrees = project.degrees.Select(d => new {d.id}),
                    jobTypes = project.jobTypes.Select(jt => new {jt.id}),
                    studyGroups = project.studyGroups.Select(st => new {st.id})
                });
            }
            else
            {
                return Ok(new
                {
                    project.uuid,
                    project.title,
                    project.webpage,              
                    project.published,
                    companies = project.companies.Select(c => new { c.id, c.name, c.logo })
                });
            }
        }

        [HttpGet, Route("api/v1/project/lastmodifed")]
        [ResponseType(typeof(Project))]
        public async Task<IHttpActionResult> GetLastModified()
        {
            //var lastModified = (from j in db.jobs where MAX(j.modified) select j);
            Project project = db.projects.OrderByDescending(p => p.modified).First();

            return Ok(new
            {
                project.uuid,
                project.modified
            });
        }

        /// <summary>
        /// Lists all projects that contains that spesific Course. 
        /// GET: api/projects?courses=IS-202
        /// GET: api/projects?courses=IS-304
        /// </summary>
        /// <param name="courses">the courses identificator</param>
        /// <returns></returns> 
        private IQueryable<Project> GetProjectsByCourse(string courses = "")
        {
            var projects = from project in db.projects
                       where project.courses.Any(c => c.id.Equals(courses))
                       select project;

            return projects;
        }

        private IQueryable<Project> GetProjectsByMultiFilter(string types = "", [FromUri] string[] studyGroups = null, string courses = "")
        {
            IQueryable<Project> projects = null;
            if (studyGroups != null && !types.IsNullOrWhiteSpace() && !courses.IsNullOrWhiteSpace())
            {
                projects = from project in db.projects
                           where project.studyGroups.Any(s => studyGroups.Contains(s.id))
                           where project.courses.Any(c => c.id.Equals(courses))
                           where project.jobTypes.Any(jt => jt.id.Equals(types))
                           select project;
            }

            else if (!types.IsNullOrWhiteSpace() && !courses.IsNullOrWhiteSpace())
            {
                projects = from project in db.projects
                           where project.courses.Any(c => c.id.Equals(courses))
                           where project.jobTypes.Any(jt => jt.id.Equals(types))
                           select project;
            }

            else if (studyGroups != null && !courses.IsNullOrWhiteSpace())
            {
                projects = from project in db.projects
                           where project.studyGroups.Any(s => studyGroups.Contains(s.id))
                           where project.courses.Any(c => c.id.Equals(courses))
                           select project;
            }

            else if (studyGroups != null && !types.IsNullOrWhiteSpace())
            {
                projects = from project in db.projects
                           where project.studyGroups.Any(s => studyGroups.Contains(s.id))
                           where project.jobTypes.Any(jt => jt.id.Equals(types))
                           select project;
            }

            return projects;
        }

        /// <summary>
        /// Lists all projects that contains that spesific StudyGroup. 
        /// GET: api/projects?studyGroups=datateknologi
        /// GET: api/projects?studyGroups=idrettsfag
        /// Also supports combinations:
        /// GET: api/projects/?studygroups=idrettsfag&studygroups=lærerutdanning
        /// </summary>
        /// <param name="studyGroups">the StudyGroup identificator</param>
        /// <returns></returns> 
       // [HttpGet, Route("api/projects")]
        private IQueryable<Project> GetProjectsByStudy(string[] studyGroups = null)
        {
            var projects = from project in db.projects
                       where project.studyGroups.Any(s => studyGroups.Contains(s.id))
                       select project;

            return projects;
        }

        /// <summary>
        /// List all projects that contain that exact title (could be improved upon)
        /// 
        /// GET: api/projects?titles=Morseffekter+på+eggstørrelse+hos+hummer
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        private IQueryable<Project> GetProjectsByTitle(string titles)
        {
            // White space delimiter + replaced.
            titles = titles.Replace("+", " ");
            var projects = from project in db.projects
                       where project.title.Equals(titles)
                       select project;

            return projects;
        }


        /// <summary>
        /// Lists all projects that contains that spesific ProjectType (full time and part time projects). 
        /// GET: api/projects?types=heltid
        /// GET: api/projects?types=deltid
        /// </summary>
        /// <param name="types">the jobTypes identificator</param>
        /// <returns></returns> 
        // [HttpGet, Route("api/projects")]
        private IQueryable<Project> GetProjectsByType(string types = "")
        {
            var projects = from project in db.projects
                       where project.jobTypes.Any(jt => jt.id.Equals(types))
                       select project;

            return projects;
        }

        /// <summary>
        /// Serializes Projects ands companies names and logo. 
        /// GET: api/projects?fields=cname&fields=clogo
        /// </summary>
        private IQueryable GetSerializedWithFields(IQueryable<Project> projects)
        {

            return projects.Select(p => new
            {
                p.uuid,
                p.title,
                //p.description,  // No need for this field atm, + very much data
                p.webpage,
                p.linkedInProfile,
                p.stepsToApply,
                p.created,
                p.published,
                p.modified,
                p.status,
                p.tutor,
                companies = p.companies.Select(c => new { c.id, c.name, c.logo }),
                courses = p.courses.Select(l => new { l.id }),
                approvedCourses = p.approvedCourses.Select(c => new { c.id }),
                degrees = p.degrees.Select(d => new { d.id }),
                jobTypes = p.jobTypes.Select(jt => new { jt.id }),
                studyGroups = p.studyGroups.Select(st => new { st.id })
            });

        }

        /// <summary>
        /// Lists all projects with the respective companies names and logo. 
        /// GET: api/projects?fields=cname&fields=clogo
        /// </summary>
        private IQueryable GetProjectsWithFields(String[] fields)
        {
            var projects = from project in db.projects select project;

            return projects.Select(p => new
            {
                p.uuid,
                p.title,
                //p.description,  // No need for this field atm, + very much data
                p.webpage,
                p.linkedInProfile,
                p.stepsToApply,
                p.created,
                p.published,
                p.modified,
                p.status,
                p.tutor,
                companies = p.companies.Select(c => new { c.id, c.name, c.logo }),
                courses = p.courses.Select(l => new { l.id }),
                approvedCourses = p.approvedCourses.Select(c => new { c.id }),
                degrees = p.degrees.Select(d => new { d.id }),
                jobTypes = p.jobTypes.Select(jt => new { jt.id }),
                studyGroups = p.studyGroups.Select(st => new { st.id })
            });

        }


        /// <summary>
        /// Serializes the project object for json.
        /// </summary>
        /// <param name="projects"></param>
        /// <returns></returns> 
        private IQueryable GetProjectsSerialized(IQueryable<Project> projects)
        {
            return projects.Select(p => new
            {
                p.uuid,
                p.title,
                //p.description,  // No need for this field atm, + very much data
                p.webpage,
                p.linkedInProfile,
                p.stepsToApply,
                p.created,
                p.published,
                p.modified,
                p.status,
                p.tutor,
                companies = p.companies.Select(c => new { c.id, c.name, c.logo }),
                courses = p.courses.Select(l => new { l.id }),
                approvedCourses = p.approvedCourses.Select(c => new { c.id }),
                degrees = p.degrees.Select(d => new { d.id }),
                jobTypes = p.jobTypes.Select(jt => new { jt.id }),
                studyGroups = p.studyGroups.Select(st => new { st.id })
            });
        }

        /// <summary>
        /// List projects in a ascending or descending order based on sortBy parameter.
        /// Examples for use:
        /// GET: api/projects/?course=IS-202&sortby=published   descending (oldest to newest)
        /// GET: api/projects/?course=IS-202&sortby=-published  ascending (newest to oldest)
        /// </summary>
        /// <param name="queryResult">A result of a query in table Projects</param>
        /// <param name="orderBy">asc = ascending 
        ///                       desc = descending</param>
        /// <param name="sortBy">published = the date a project was published
        ///                      expirydate = the last date to apply for the project</param>
        /// <returns></returns>
        private IQueryable GetProjectsSorted(IQueryable<Project> queryResult, string sortBy = "")
        {
            var projects = queryResult.Select(p => new
            {
                p.uuid,
                p.title,
                //p.description,  // No need for this field atm, + very much data
                p.webpage,
                p.linkedInProfile,
                p.stepsToApply,
                p.created,
                p.published,
                p.modified,
                p.status,
                p.tutor,
                companies = p.companies.Select(c => new { c.id, c.name, c.logo }),
                courses = p.courses.Select(l => new { l.id }),
                approvedCourses = p.approvedCourses.Select(c => new { c.id }),
                degrees = p.degrees.Select(d => new { d.id }),
                jobTypes = p.jobTypes.Select(jt => new { jt.id }),
                studyGroups = p.studyGroups.Select(st => new { st.id })
            });

            switch (sortBy)
            { 
                case "published":
                projects = projects.OrderByDescending(j => j.published);
                return projects;

                case "-published":
                    projects = projects.OrderBy(j => j.published);
                    return projects;

                default:
                return GetProjects();
            }
            /*
            if (orderBy.Equals("desc"))
            {
                switch (sortBy)
                {
                    case "published":
                        projects = projects.OrderByDescending(j => j.published);
                        return projects;

                    default:
                        return GetProjects();
                }
            }

            switch (sortBy)
            {
                case "published":
                    projects = projects.OrderBy(j => j.published);
                    return projects;

                default:
                    return GetProjects();
            }

            */
        }

        /// <summary>
        /// List projects in a ascending or descending order based on sortBy parameter.
        /// GET: api/projects/?orderby=sortby=-published  ascending (newest to oldest)
        /// GET: api/projects/?orderby=sortby=published   descending (oldest to newest)
        /// 
        /// </summary>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        private IQueryable GetProjectsSorted(string sortBy = "")
        {

            var queryResult = from project in db.projects select project;

            // Won't work due to incompatible return type.
            //GetProjectsSerialized(projects1)

            var projects = queryResult.Select(p => new
            {
                p.uuid,
                p.title,
                //p.description,  // No need for this field atm, + very much data
                p.webpage,
                p.linkedInProfile,
                p.stepsToApply,
                p.created,
                p.published,
                p.modified,
                p.status,
                p.tutor,
                companies = p.companies.Select(c => new { c.id, c.name, c.logo }),
                courses = p.courses.Select(l => new { l.id }),
                approvedCourses = p.approvedCourses.Select(c => new { c.id }),
                degrees = p.degrees.Select(d => new { d.id }),
                jobTypes = p.jobTypes.Select(jt => new { jt.id }),
                studyGroups = p.studyGroups.Select(st => new { st.id })
            });

            switch (sortBy)
            {
                case "published":
                    projects = projects.OrderByDescending(j => j.published);
                    return projects;

                case "-published":
                    projects = projects.OrderBy(j => j.published);
                    return projects;

                default:
                    return GetProjects();
            }
        }


        // PUT: api/Projects/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProject(string id, Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != project.uuid)
            {
                return BadRequest();
            }

            db.Entry(project).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
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

        // POST: api/Projects
        [ResponseType(typeof(Project))]
        public async Task<IHttpActionResult> PostProject(Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.projects.Add(project);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProjectExists(project.uuid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = project.uuid }, project);
        }

        // DELETE: api/Projects/5
        [ResponseType(typeof(Project))]
        public async Task<IHttpActionResult> DeleteProject(string id)
        {
            Project project = await db.projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            db.projects.Remove(project);
            await db.SaveChangesAsync();

            return Ok(project);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProjectExists(string id)
        {
            return db.projects.Count(e => e.uuid == id) > 0;
        }
    }
}