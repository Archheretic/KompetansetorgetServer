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
    public class Study_groupController : Controller
    {
        private KompetansetorgetServerContext db = new KompetansetorgetServerContext();

        // GET: Study_group
        public async Task<ActionResult> Index()
        {
            return View(await db.Study_group.ToListAsync());
        }

        // GET: Study_group/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Study_group study_group = await db.Study_group.FindAsync(id);
            if (study_group == null)
            {
                return HttpNotFound();
            }
            return View(study_group);
        }

        // GET: Study_group/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Study_group/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdStudy_group,Name")] Study_group study_group)
        {
            if (ModelState.IsValid)
            {
                db.Study_group.Add(study_group);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(study_group);
        }

        // GET: Study_group/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Study_group study_group = await db.Study_group.FindAsync(id);
            if (study_group == null)
            {
                return HttpNotFound();
            }
            return View(study_group);
        }

        // POST: Study_group/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdStudy_group,Name")] Study_group study_group)
        {
            if (ModelState.IsValid)
            {
                db.Entry(study_group).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(study_group);
        }

        // GET: Study_group/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Study_group study_group = await db.Study_group.FindAsync(id);
            if (study_group == null)
            {
                return HttpNotFound();
            }
            return View(study_group);
        }

        // POST: Study_group/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Study_group study_group = await db.Study_group.FindAsync(id);
            db.Study_group.Remove(study_group);
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
