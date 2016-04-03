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
        [HttpGet, Route("api/{jobs}/{id}")]
        [ResponseType(typeof(Student))]
        public async Task<IHttpActionResult> GetStudent(string id, string fields = "")
        {
            Student student = await db.students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            if (!fields.Equals("token")) { 
            //return Ok(student);
                return Ok( new { 
                    student.username,
                    student.name,
                    student.email,
                    devices = student.Devices.Select(d => new { d.id }),
                    studyGroups = student.studyGroups.Select(st => new { st.id })
                });
            }

            return Ok(new
            {
                student.username,
                student.name,
                student.email,
                devices = student.Devices.Select(d => new { d.id, d.token }),
                studyGroups = student.studyGroups.Select(st => new { st.id })
            });


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