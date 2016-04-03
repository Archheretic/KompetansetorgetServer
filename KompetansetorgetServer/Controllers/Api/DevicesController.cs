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
    public class DevicesController : ApiController
    {
        private KompetansetorgetServerContext db = new KompetansetorgetServerContext();

        // GET: api/devices
        public IQueryable GetDevices()
        {
            //return db.devices;
            return db.devices.Select(d => new
            {
                d.id,
                d.deviceType,
                //student = d.Student.username,
                d.token
            });
        }

        // GET: api/devices/5
        [ResponseType(typeof(Device))]
        public async Task<IHttpActionResult> GetDevice(string id)
        {
            Device device = await db.devices.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }

            return Ok( new {
                device.id,
                device.deviceType,
                //student = device.Student.username,
                device.token
            });
        }

        // PUT: api/devices/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDevice(string id, Device device)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != device.id)
            {
                return BadRequest();
            }

            db.Entry(device).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceExists(id))
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

        // POST: api/devices
        [ResponseType(typeof(Device))]
        public async Task<IHttpActionResult> PostDevice(Device device)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.devices.Add(device);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DeviceExists(device.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = device.id }, device);
        }

        // DELETE: api/devices/5
        [ResponseType(typeof(Device))]
        public async Task<IHttpActionResult> DeleteDevice(string id)
        {
            Device device = await db.devices.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }

            db.devices.Remove(device);
            await db.SaveChangesAsync();

            return Ok(device);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DeviceExists(string id)
        {
            return db.devices.Count(e => e.id == id) > 0;
        }
    }
}