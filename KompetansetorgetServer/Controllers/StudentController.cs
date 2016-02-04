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
		private StudentContext db;

		public StudentController() 
		{
			this.db = new StudentContext();
		}

        public ActionResult Index()
        {
            return View ();
        }

		public ActionResult TestAddition() 
		{
			Student student = new Student () {
				FirstName = "Some",
				LastName = "Guy"
			};
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