using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using KompetansetorgetServer.Models;
using System.Security.Cryptography;

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

        [HttpGet, Route("api/v1/studygroups/hash")]
        //[ResponseType(typeof(StudyGroup))]
        public async Task<IHttpActionResult> GetLocationsHash()
        {
            var result = from studyGroup in db.studyGroup select studyGroup;
            List<StudyGroup> studyGroupList = result.OrderBy(sg => sg.id).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var studyGroup in studyGroupList)
            {
                sb.Append(studyGroup.id);
            }
            string hash = CalculateMD5Hash(sb.ToString());

            return Ok(new
            {
                hash
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