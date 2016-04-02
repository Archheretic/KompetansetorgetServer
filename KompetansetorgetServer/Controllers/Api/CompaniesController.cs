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
    public class CompaniesController : ApiController
    {
        private KompetansetorgetServerContext db = new KompetansetorgetServerContext();

        // GET: api/companies
        public IQueryable<Company> GetCompanies()
        {
            return db.companies;
        }

        // GET: api/companies/5
        [ResponseType(typeof(Company))]
        public async Task<IHttpActionResult> GetCompany(string id)
        {
            Company company = await db.companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        // PUT: api/companies/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCompany(string id, Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != company.id)
            {
                return BadRequest();
            }

            db.Entry(company).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(id))
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

        // POST: api/companies
        [ResponseType(typeof(Company))]
        public async Task<IHttpActionResult> PostCompany(Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.companies.Add(company);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CompanyExists(company.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = company.id }, company);
        }

        // DELETE: api/companies/5
        [ResponseType(typeof(Company))]
        public async Task<IHttpActionResult> DeleteCompany(string id)
        {
            Company company = await db.companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            db.companies.Remove(company);
            await db.SaveChangesAsync();

            return Ok(company);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompanyExists(string id)
        {
            return db.companies.Count(e => e.id == id) > 0;
        }
    }
}