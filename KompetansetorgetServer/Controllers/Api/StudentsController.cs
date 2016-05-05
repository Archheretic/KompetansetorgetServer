using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Description;
using KompetansetorgetServer.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KompetansetorgetServer.Controllers.Api
{
    [Authorize]
    public class StudentsController : ApiController
    {
        private KompetansetorgetServerContext db = new KompetansetorgetServerContext();

        // GET: api/students?fields=token
        public IQueryable Get(string fields = "")
        {
            if (!fields.Equals("token"))
            {
                return GetStudents();
            }

            //string[] extraFields = fields.Split('+');

            return db.students.Select(s => new
            {
                s.username,
                s.name,
                s.email,
                studyGroups = s.studyGroups.Select(st => new { st.id }),
                devices = s.Devices.Select(st => new
                {
                    st.id,
                    st.token
                })
                });
         }

        // GET: api/students
        private IQueryable GetStudents()
        {
            //return db.students;

            return db.students.Select(s => new
            {
                s.username,
                s.name,
                s.email,
                studyGroups = s.studyGroups.Select(st => new { st.id }), 
                devices = s.Devices.Select(st => new {st.id})
            });

        }

        // GET: api/students/5
        [HttpGet, Route("api/v1/students/{id}")]
        [ResponseType(typeof(Student))]
        public async Task<IHttpActionResult> GetStudent(string id, string fields = "")
        {
            string decodedId = Base64Decode(id);
            Student student = await db.students.FindAsync(decodedId);
            if (student == null)
            {
                return NotFound();
            }

            if (!fields.ToLower().Equals("gcmtoken")) { 
            //return Ok(student);
                return Ok( new { 
                    student.username,
                    //student.name,
                    student.email,
                    devices = student.Devices.Select(d => new { d.id }),
                    studyGroups = student.studyGroups.Select(st => new { st.id })
                });
            }

            return Ok(new
            {
                student.username,
                //student.name,
                student.email,
                devices = student.Devices.Select(d => new { d.id, d.token }),
                studyGroups = student.studyGroups.Select(st => new { st.id })
            });

            
        }

        // Post: api/students/{id}
        [HttpPost, Route("api/v1/students/{id}")]
        [ResponseType(typeof (Student))]
        public async Task<IHttpActionResult> UpdateStudent(string id, [FromBody]dynamic raw)
        {
            string decodedId = Base64Decode(id);
            Student student = await db.students.FindAsync(decodedId);
            if (student == null)
            {
                // should return not authorized
                return NotFound();
            }

            Dictionary<string, object> dict =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(raw.ToString());
            // {"StudyGroup":[{"id":"idrettsfag"},{"id":"datateknologi"}]}
            if (dict.ContainsKey("StudyGroup"))
            {
                JArray array = (JArray)dict["StudyGroup"];
                List<StudyGroup> studyGroupIds = array.ToObject<List<StudyGroup>>();
                UpdateStudyGroupStudent(studyGroupIds, student);
                return Ok();
            }

            return BadRequest();
        }

        private void UpdateStudyGroupStudent(List<StudyGroup> studyGroups,Student student)
        {

            List<StudyGroup> oldStudyGroups = student.studyGroups.ToList();
            if (oldStudyGroups.Count > 0)
            {
                // removes all old relations between student and studygroup
                foreach (StudyGroup sg in oldStudyGroups)
                {
                    student.studyGroups.Remove(sg);
                }

                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                /*
                db.students.Attach(student);
                var entry1 = db.Entry(student);
                entry1.Property(e => e.studyGroups).IsModified = true;
                db.SaveChanges();
                */
            }

            // creates new relations between the student and the studygroups provided
            foreach (var study in studyGroups)
            {
                string id = study.id;
                StudyGroup sg = db.studyGroup.First(x => x.id.Equals(id));
                if (sg != null)
                {
                    student.studyGroups.Add(sg);
                }
            }
            /*
            db.students.Attach(student);
            var entry2 = db.Entry(student);
            entry2.Property(e => e.studyGroups).IsModified = true;
            db.SaveChanges();
            */

            db.Entry(student).State = EntityState.Modified;
            db.SaveChanges();
            
        }

        // PUT: api/students/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStudent(string id, Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student.username)
            {
                return BadRequest();
            }

            db.Entry(student).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
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

        // POST: api/students
        [ResponseType(typeof(Student))]
        public async Task<IHttpActionResult> PostStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.students.Add(student);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudentExists(student.username))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = student.username }, student);
        }

        // DELETE: api/students/5
        [ResponseType(typeof(Student))]
        public async Task<IHttpActionResult> DeleteStudent(string id)
        {
            Student student = await db.students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            db.students.Remove(student);
            await db.SaveChangesAsync();

            return Ok(student);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentExists(string id)
        {
            return db.students.Count(e => e.username == id) > 0;
        }


    }
}