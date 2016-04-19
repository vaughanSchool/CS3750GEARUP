using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GearUp.Models;

namespace GearUp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        //private AspNetUser user = new AspNetUser();

        public ActionResult Index()
        {
            ViewBag.Message = "Dashboard";

            return View();
        }

        public ActionResult Search()
        {
            GearUpDBEntities db = new GearUpDBEntities();
            
            return View(db.Students);
        }

        [HttpPost]
        public ActionResult Search(string searchTerm)
        {
            GearUpDBEntities db = new GearUpDBEntities();
            List<Student> students;
            if (string.IsNullOrEmpty(searchTerm))
            {
                students = db.Students.ToList();
            }
            else
            {
                //var student1 = db.Students.Where(s => s.firstName.StartsWith(searchTerm)).ToList();


                students = db.Students
                    .Where(s => s.firstName.StartsWith(searchTerm) || s.lastName.StartsWith(searchTerm)
                    || s.firstName + " " + s.lastName == searchTerm).ToList();

                //students = students.Concat(db.Students.Where(x => x.lastName.StartsWith(searchTerm));

                //students = students.Concat(student1).ToList();
            }
            return View(students);
        }

        public JsonResult GetStudents(string term)
        {
            GearUpDBEntities db = new GearUpDBEntities();
            List<string> students = db.Students.Where(s => s.firstName.StartsWith(term) || s.lastName.StartsWith(term))
                .Select(x => x.firstName + " " + x.lastName).ToList();

            return Json(students, JsonRequestBehavior.AllowGet);
        }


        //public async Task<ActionResult> Index()
        //{

        //    return View("index",
        //       await service.GetStudentAsync()
        //    );
        //}

        //public ActionResult Index()
        //{
        //    ViewBag.Message = "Dashboard";

        //    return View();
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}