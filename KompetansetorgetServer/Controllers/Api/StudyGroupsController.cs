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
    public class StudyGroupsController : ApiController
    {
        private KompetansetorgetServerContext db = new KompetansetorgetServerContext();

        // GET: api/StudyGroups
        public IQueryable GetStudyGroup()
        {
            
            return db.studyGroup.Select(s => new
            {
                s.id,
                s.name
            });
        }

        // GET: api/StudyGroups/5
        [ResponseType(typeof(StudyGroup))]
        public async Task<IHttpActionResult> GetStudyGroup(string id)
        {
            StudyGroup studyGroup = await db.studyGroup.FindAsync(id);
            if (studyGroup == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                studyGroup.id,
                studyGroup.name
            });
        }

        // PUT: api/StudyGroups/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStudyGroup(string id, StudyGroup studyGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studyGroup.id)
            {
                return BadRequest();
            }

            db.Entry(studyGroup).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudyGroupExists(id))
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

        // POST: api/StudyGroups
        [ResponseType(typeof(StudyGroup))]
        public async Task<IHttpActionResult> PostStudyGroup(StudyGroup studyGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.studyGroup.Add(studyGroup);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudyGroupExists(studyGroup.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = studyGroup.id }, studyGroup);
        }

        // DELETE: api/StudyGroups/5
        [ResponseType(typeof(StudyGroup))]
        public async Task<IHttpActionResult> DeleteStudyGroup(string id)
        {
            StudyGroup studyGroup = await db.studyGroup.FindAsync(id);
            if (studyGroup == null)
            {
                return NotFound();
            }

            db.studyGroup.Remove(studyGroup);
            await db.SaveChangesAsync();

            return Ok(studyGroup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudyGroupExists(string id)
        {
            return db.studyGroup.Count(e => e.id == id) > 0;
        }
    }
}