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
using KompetansetorgetServer.PushNotifications;

namespace KompetansetorgetServer.Controllers
{
    public class JobsController : Controller
    {
        private KompetansetorgetServerContext db = new KompetansetorgetServerContext();

        // GET: Jobs
        public async Task<ActionResult> Index()
        {
            return View(await db.jobs.ToListAsync());
        }

        // GET: Jobs/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = await db.jobs.FindAsync(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: Jobs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "uuid,title,description,webpage,linkedInProfile,expiryDate,stepsToApply,created,published,modified")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.jobs.Add(job);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(job);
        }

        // GET: Jobs/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = await db.jobs.FindAsync(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "uuid,title,description,webpage,linkedInProfile,expiryDate,stepsToApply,created,published,modified")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(job);
        }

        // GET: Jobs/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = await db.jobs.FindAsync(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Job job = await db.jobs.FindAsync(id);
            db.jobs.Remove(job);
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

        public ActionResult TestPushToViktor()
        {
            Push p = new Push();
            string vToken =
                "cMpKlAeCYZE:APA91bHR93f2MrYJfM3WpSDfzhfDu4mFwLVUPVHez47Mq8qoMp7p-Fnl3kFaF8F0QAxqr6S-rinrRLdddi2gXnD0h5_QmAz2XYIjsnXQ2ARLZMTWveT9amKxp53ZeLgZ527vmbxYEROm";
            p.PushToAndroid(vToken);
            return RedirectToAction("About", "Home");
        }

        public ActionResult TestPushToNadia()
        {
            Push p = new Push();
            string nToken =
     "erFSVhQN-Qc:APA91bGGzos4X2Hh4np_swN6U15_8U1mCOXekMT95k4evG2S1TvT67DgzQ5gXEv8_9uSRhCveP99jqMAygGSyp1TxQomegJpzLd-iXQQvPAf99D5DPZr6cYpLwz7ezyQfASQuMQnB6Im";

            p.PushToAndroid(nToken);
            return RedirectToAction("About", "Home");
        }

        public ActionResult TestPushToAll()
        {
            PushAll p = new PushAll();
            p.SendMessageToAllAndroid("Hei alle sammen");
            return RedirectToAction("About", "Home");
        }

        public ActionResult PopulateDb()
        {
            DbPopulator populator = new DbPopulator();
            populator.PopulateAll();
            return RedirectToAction("About", "Home");
        }
    }
}
