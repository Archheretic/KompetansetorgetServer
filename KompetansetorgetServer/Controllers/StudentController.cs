using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KompetansetorgetServer.Models;
using KompetansetorgetServer.ContextDbs;


namespace KompetansetorgetServer.Controllers
{
    public class StudentController : Controller
    {
		private KompetanseContext db;

		public StudentController() 
		{
			this.db = new KompetanseContext();
		}

        public ActionResult Index()
        {
            return View ();
        }

		public ActionResult TestAddition() 
		{
			Random r = new Random();
			int rNumber = r.Next();
			Proficiency prof = new Proficiency ();
			Student student = new Student () {
				Username = rNumber.ToString(),
				FirstName = "Some",
				LastName = "Guy",
				Proficiency = prof
			};
			db.Proficiencies.Add (prof);
			db.Students.Add(student);
			db.SaveChanges();

			return RedirectToAction("Index", "Home");
		}

        public ActionResult Details(int id)
        {
            return View ();
        }

        public ActionResult Create()
        {
            return View ();
        } 

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try {
                return RedirectToAction ("Index");
            } catch {
                return View ();
            }
        }
        
        public ActionResult Edit(int id)
        {
            return View ();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try {
                return RedirectToAction ("Index");
            } catch {
                return View ();
            }
        }

        public ActionResult Delete(int id)
        {
            return View ();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try {
                return RedirectToAction ("Index");
            } catch {
                return View ();
            }
        }
    }
}