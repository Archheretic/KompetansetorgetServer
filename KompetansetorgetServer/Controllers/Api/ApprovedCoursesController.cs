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
    public class ApprovedCoursesController : ApiController
    {
        private KompetansetorgetServerContext db = new KompetansetorgetServerContext();

        // GET: api/ApprovedCourses
        public IQueryable GetApprovedCourses()
        {
            return db.approvedCourses.Select(c => new
            {
                c.id,
                c.name
            });

        }

        // GET: api/ApprovedCourses/5
        [ResponseType(typeof(ApprovedCourse))]
        public async Task<IHttpActionResult> GetApprovedCourse(string id)
        {
            ApprovedCourse approvedCourse = await db.approvedCourses.FindAsync(id);
            if (approvedCourse == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                approvedCourse.id,
                approvedCourse.name
            });
        }

        // PUT: api/ApprovedCourses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutApprovedCourse(string id, ApprovedCourse approvedCourse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != approvedCourse.id)
            {
                return BadRequest();
            }

            db.Entry(approvedCourse).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApprovedCourseExists(id))
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

        // POST: api/ApprovedCourses
        [ResponseType(typeof(ApprovedCourse))]
        public async Task<IHttpActionResult> PostApprovedCourse(ApprovedCourse approvedCourse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.approvedCourses.Add(approvedCourse);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ApprovedCourseExists(approvedCourse.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = approvedCourse.id }, approvedCourse);
        }

        // DELETE: api/ApprovedCourses/5
        [ResponseType(typeof(ApprovedCourse))]
        public async Task<IHttpActionResult> DeleteApprovedCourse(string id)
        {
            ApprovedCourse approvedCourse = await db.approvedCourses.FindAsync(id);
            if (approvedCourse == null)
            {
                return NotFound();
            }

            db.approvedCourses.Remove(approvedCourse);
            await db.SaveChangesAsync();

            return Ok(approvedCourse);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApprovedCourseExists(string id)
        {
            return db.approvedCourses.Count(e => e.id == id) > 0;
        }
    }
}