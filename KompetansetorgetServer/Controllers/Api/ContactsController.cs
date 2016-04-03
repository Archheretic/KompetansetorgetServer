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
    public class ContactsController : ApiController
    {
        private KompetansetorgetServerContext db = new KompetansetorgetServerContext();

        // GET: api/Contacts
        public IQueryable Getcontacts()
        {
            return db.contacts.Select(c => new
            {
                c.id,
                c.name,
                c.position,
                c.phone,
                c.email
            });
        }

        // GET: api/Contacts/5
        [ResponseType(typeof(Contact))]
        public async Task<IHttpActionResult> GetContact(int id)
        {
            Contact contact = await db.contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            return Ok( new {
                contact.id,
                contact.name,
                contact.position,
                contact.phone,
                contact.email
            });
        }

        // PUT: api/Contacts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutContact(int id, Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contact.id)
            {
                return BadRequest();
            }

            db.Entry(contact).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
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

        // POST: api/Contacts
        [ResponseType(typeof(Contact))]
        public async Task<IHttpActionResult> PostContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.contacts.Add(contact);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = contact.id }, contact);
        }

        // DELETE: api/Contacts/5
        [ResponseType(typeof(Contact))]
        public async Task<IHttpActionResult> DeleteContact(int id)
        {
            Contact contact = await db.contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            db.contacts.Remove(contact);
            await db.SaveChangesAsync();

            return Ok(contact);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactExists(int id)
        {
            return db.contacts.Count(e => e.id == id) > 0;
        }
    }
}