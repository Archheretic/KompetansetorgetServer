﻿using System;
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
    public class LocationsController : Controller
    {
        private KompetansetorgetServerContext db = new KompetansetorgetServerContext();

        // GET: locations
        public async Task<ActionResult> Index()
        {
            return View(await db.locations.ToListAsync());
        }

        // GET: locations/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = await db.locations.FindAsync(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // GET: locations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: locations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,name")] Location location)
        {
            if (ModelState.IsValid)
            {
                db.locations.Add(location);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(location);
        }

        // GET: locations/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = await db.locations.FindAsync(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // POST: locations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,name")] Location location)
        {
            if (ModelState.IsValid)
            {
                db.Entry(location).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(location);
        }

        // GET: locations/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = await db.locations.FindAsync(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // POST: locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Location location = await db.locations.FindAsync(id);
            db.locations.Remove(location);
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
