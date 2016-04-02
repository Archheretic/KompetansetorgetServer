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
    public class StudyGroupsController : Controller
    {
        private KompetansetorgetServerContext db = new KompetansetorgetServerContext();

        // GET: StudyGroups
        public async Task<ActionResult> Index()
        {
            return View(await db.studyGroup.ToListAsync());
        }

        // GET: StudyGroups/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudyGroup studyGroup = await db.studyGroup.FindAsync(id);
            if (studyGroup == null)
            {
                return HttpNotFound();
            }
            return View(studyGroup);
        }

        // GET: StudyGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudyGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,name")] StudyGroup studyGroup)
        {
            if (ModelState.IsValid)
            {
                db.studyGroup.Add(studyGroup);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(studyGroup);
        }

        // GET: StudyGroups/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudyGroup studyGroup = await db.studyGroup.FindAsync(id);
            if (studyGroup == null)
            {
                return HttpNotFound();
            }
            return View(studyGroup);
        }

        // POST: StudyGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,name")] StudyGroup studyGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studyGroup).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(studyGroup);
        }

        // GET: StudyGroups/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudyGroup studyGroup = await db.studyGroup.FindAsync(id);
            if (studyGroup == null)
            {
                return HttpNotFound();
            }
            return View(studyGroup);
        }

        // POST: StudyGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            StudyGroup studyGroup = await db.studyGroup.FindAsync(id);
            db.studyGroup.Remove(studyGroup);
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
