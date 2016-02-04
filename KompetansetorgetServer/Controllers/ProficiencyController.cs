using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KompetansetorgetServer.ContextDbs;
using KompetansetorgetServer.Models;
using System.Threading.Tasks;


namespace KompetansetorgetServer.Controllers
{
    public class ProficiencyController : Controller
    {
		private KompetanseContext db;

		public ProficiencyController()
		{
			this.db = new KompetanseContext ();
		}

        public ActionResult Index()
        {
            return View ();
        }

        public ActionResult Details(int id)
        {
            return View ();
        }

        public ActionResult Create()
        {
			
            return View ();
        } 

//		public async Task<Proficiency> getStudentProficiency(string username) 
//		{
//			Task<Student> student = getStudent(username);
//			int id = student.IdProficiency;
//			return await db.Proficiencies.FindAsync (id);
//		}

		private async Task<Student> getStudent(string username) 
		{
			return await db.Students.FindAsync (username);
		}

//			foreach (Student student in studDb.Students) 
//			{
//				if (student.Username.Equals(username))
//				{
//					return student.IdProficiency;
//				}
//			}
//			return null;





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