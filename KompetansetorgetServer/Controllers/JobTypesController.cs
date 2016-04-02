using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KompetansetorgetServer.Models;

namespace KompetansetorgetServer.Controllers
{
    public class JobTypesController : Controller
    {
        private KompetansetorgetServerContext db = new KompetansetorgetServerContext();

        // GET: jobTypes
        public async Task<ActionResult> Index()
        {
            return View(await db.jobTypes.ToListAsync());
        }

        // GET: jobTypes/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobType jobType = await db.jobTypes.FindAsync(id);
            if (jobType == null)
            {
                return HttpNotFound();
            }
            return View(jobType);
        }

        // GET: jobTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: jobTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,name")] JobType jobType)
        {
            if (ModelState.IsValid)
            {
                db.jobTypes.Add(jobType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(jobType);
        }

        // GET: jobTypes/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobType jobType = await db.jobTypes.FindAsync(id);
            if (jobType == null)
            {
                return HttpNotFound();
            }
            return View(jobType);
        }

        // POST: jobTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,name")] JobType jobType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(jobType);
        }

        // GET: jobTypes/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobType jobType = await db.jobTypes.FindAsync(id);
            if (jobType == null)
            {
                return HttpNotFound();
            }
            return View(jobType);
        }

        // POST: jobTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            JobType jobType = await db.jobTypes.FindAsync(id);
            db.jobTypes.Remove(jobType);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
