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
            var jobs = db.Jobs.Include(j => j.Company).Include(j => j.Contact).Include(j => j.JobType).Include(j => j.Location);
            return View(await jobs.ToListAsync());
        }

        // GET: Jobs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = await db.Jobs.FindAsync(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: Jobs/Create
        public ActionResult Create()
        {
            ViewBag.IdCompany = new SelectList(db.Companies, "IdCompany", "Name");
            ViewBag.IdContact = new SelectList(db.Contacts, "IdContact", "Name");
            ViewBag.IdJobType = new SelectList(db.JobTypes, "IdJobType", "Name");
            ViewBag.IdLocation = new SelectList(db.Locations, "IdLocation", "Name");
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdJob,Title,Description,Webpage,LinkedIn_profile,Expiry_date,Steps_to_apply,Created,Published,Modified,IdContact,IdLocation,IdJobType,IdCompany")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Jobs.Add(job);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdCompany = new SelectList(db.Companies, "IdCompany", "Name", job.IdCompany);
            ViewBag.IdContact = new SelectList(db.Contacts, "IdContact", "Name", job.IdContact);
            ViewBag.IdJobType = new SelectList(db.JobTypes, "IdJobType", "Name", job.IdJobType);
            ViewBag.IdLocation = new SelectList(db.Locations, "IdLocation", "Name", job.IdLocation);
            return View(job);
        }

        // GET: Jobs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = await db.Jobs.FindAsync(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCompany = new SelectList(db.Companies, "IdCompany", "Name", job.IdCompany);
            ViewBag.IdContact = new SelectList(db.Contacts, "IdContact", "Name", job.IdContact);
            ViewBag.IdJobType = new SelectList(db.JobTypes, "IdJobType", "Name", job.IdJobType);
            ViewBag.IdLocation = new SelectList(db.Locations, "IdLocation", "Name", job.IdLocation);
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdJob,Title,Description,Webpage,LinkedIn_profile,Expiry_date,Steps_to_apply,Created,Published,Modified,IdContact,IdLocation,IdJobType,IdCompany")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdCompany = new SelectList(db.Companies, "IdCompany", "Name", job.IdCompany);
            ViewBag.IdContact = new SelectList(db.Contacts, "IdContact", "Name", job.IdContact);
            ViewBag.IdJobType = new SelectList(db.JobTypes, "IdJobType", "Name", job.IdJobType);
            ViewBag.IdLocation = new SelectList(db.Locations, "IdLocation", "Name", job.IdLocation);
            return View(job);
        }

        // GET: Jobs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = await db.Jobs.FindAsync(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Job job = await db.Jobs.FindAsync(id);
            db.Jobs.Remove(job);
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
            p.PushToAndroid();
            return RedirectToAction("About", "Home");
        }

        public ActionResult TestPushToAll()
        {
            PushAll p = new PushAll();
            p.SendMessageToAllAndroid("Hei alle sammen");
            return RedirectToAction("About", "Home");
        }


        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        public ActionResult InsertEnJob()
        {
            Job job = new Job()
            {
                Title = "Database ansvarlig",
                Description = "Database ansvarlig for Snekkern",
                Webpage = "http://snekkern.no/",
                Steps_to_apply = "Send mail",
                Expiry_date = DateTime.Now.AddDays(20),
                Created = DateTime.Now,
                Published = DateTime.Now,
                Modified = DateTime.Now
            };

            Contact contact = db.Contacts.First(x => x.IdContact == 1);
            Location location = db.Locations.First(x => x.IdLocation.Equals("Vest-Agder"));
            JobType jobType = db.JobTypes.First(x => x.IdJobType.Equals("Heltid"));
            Company company = db.Companies.First(x => x.IdCompany.Equals("uia"));

            Study_group data = db.Study_group.First(x => x.IdStudy_group.Equals("datateknologi"));
            //Study_group idrett = db.Study_group.First(x => x.IdStudy_group.Equals("idrettsfag"));


            job.Contact = contact;
            job.Study_groups.Add(data);
            //job.Study_groups.Add(idrett);
            job.Location = location;
            job.JobType = jobType;
            job.Company = company;

            db.Jobs.Add(job);
            //htc.Student = student;
            db.SaveChanges();
            return RedirectToAction("About", "Home");
        }

    }
}
