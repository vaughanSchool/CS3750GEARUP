using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GearUp.Models;

namespace GearUp.Controllers
{
    [Authorize]
    public class LifePlanController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "LifePlans";

            return View();
        }

        public ActionResult Edit()
        {
            GearUpDBEntities db = new GearUpDBEntities();
            ViewBag.Message = "Your LifePlan edit page.";

            return View(db.Students);
        }

              

        //This post will be used when the student is selected
        //and all information for their lifeplan is grabbed.
        [HttpPost]
        public ActionResult Edit(string searchTerm)
        {
            GearUpDBEntities db = new GearUpDBEntities();
            List<Student> students = null;
            if (string.IsNullOrEmpty(searchTerm))
            {
                //Do Nothing
            }
            else
            {
                students = db.Students
                    .Where(s => s.firstName.StartsWith(searchTerm) || s.lastName.StartsWith(searchTerm)
                    || s.firstName + " " + s.lastName == searchTerm).ToList();
            }

            //need to check if there is only a single student left
            return View(students);
        }

        public JsonResult GetStudents(string term)
        {
            GearUpDBEntities db = new GearUpDBEntities();
            List<string> students = db.Students.Where(s => s.firstName.StartsWith(term) || s.lastName.StartsWith(term))
                .Select(x => x.firstName + " " + x.lastName).ToList();

            return Json(students, JsonRequestBehavior.AllowGet);
        }
    }
}