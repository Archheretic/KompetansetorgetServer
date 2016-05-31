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

        public ActionResult TestPushJobToViktor()
        {
            Push p = new Push();
            Device d = db.devices.First(x => x.id.Equals("HT451WM08832"));
            string vToken = d.token;
            p.PushToAndroid(vToken, "job");
            return RedirectToAction("About", "Home");
        }

        public ActionResult TestPushProjectToViktor()
        {
            Push p = new Push();
            Device d = db.devices.First(x => x.id.Equals("HT451WM08832"));
            string vToken = d.token;
            p.PushToAndroid(vToken, "project");
            return RedirectToAction("About", "Home");
        }

        public ActionResult TestPushProjectToNadia()
        {
            Push p = new Push();
            Device d = db.devices.First(x => x.id.Equals("86e0e4a5"));
            string nToken = d.token;

            p.PushToAndroid(nToken, "project");
            return RedirectToAction("About", "Home");
        }

        public ActionResult TestPushJobToNadia()
        {
            Push p = new Push();
            Device d = db.devices.First(x => x.id.Equals("86e0e4a5"));
            string nToken = d.token;

            p.PushToAndroid(nToken, "job");
            return RedirectToAction("About", "Home");
        }


        public ActionResult TestPushProjectToKjetil()
        {
            Push p = new Push();
            Device d = db.devices.First(x => x.id.Equals("ENU7N15B04007825"));
            string nToken = d.token;

            p.PushToAndroid(nToken, "project");
            return RedirectToAction("About", "Home");
        }

        public ActionResult TestPushJobToKjetil()
        {
            Push p = new Push();
            Device d = db.devices.First(x => x.id.Equals("ENU7N15B04007825"));
            string nToken = d.token;

            p.PushToAndroid(nToken, "job");
            return RedirectToAction("About", "Home");
        }

        public ActionResult TestPushToAll()
        {
            PushAll p = new PushAll();
            p.SendMessageToAllAndroid("Hei alle sammen");
            return RedirectToAction("About", "Home");
        }

        public ActionResult TestPushProjectToAll()
        {
            PushAll p = new PushAll();
            p.SendAdvertToAllAndroid("project");
            return RedirectToAction("About", "Home");
        }

        public ActionResult TestPushJobToAll()
        {
            PushAll p = new PushAll();
            p.SendAdvertToAllAndroid("job");
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
