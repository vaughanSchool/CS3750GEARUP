using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GearUp.Models;

namespace GearUp.Controllers
{
    [Authorize]
    public class LifePlanController : Controller
    {
        //lists that contain the information from the database
        List<string> needs = new List<string>();
        List<string> education = new List<string>();
        List<string> careerInputBox = new List<string>();
        List<string> careerDropDown = new List<string>();

        public ActionResult Index()
        {
            ViewBag.Message = "LifePlans";

            return View();
        }

        public ActionResult Edit()
        {
            GearUpDBEntities db = new GearUpDBEntities();
            ViewBag.Message = "Your LifePlan edit page.";

            //set the lists to a view bag
            ViewBag.Needs = needs;
            ViewBag.Education = education;
            ViewBag.CareerName = careerInputBox;
            ViewBag.CareerCategory = careerDropDown;

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

            //update the right side of the form
            //once we have db working then make calls to get this information
            //for now going to make up data
            needs.Add("FAFSA Help");
            needs.Add("Math Tutoring");
            needs.Add("ACT Prep");

            education.Add("3.5 GPA");
            education.Add("Graduate High Scool");
            education.Add("Bachelor's Degree");

            careerInputBox.Add("Programming");
            careerInputBox.Add("Chef");
            careerInputBox.Add("Start up own business");

            careerDropDown.Add("Computers");
            careerDropDown.Add("Culinary");
            careerDropDown.Add("Business");

            //set the lists to a view bag after being populated
            ViewBag.Needs = needs;
            ViewBag.Education = education;
            ViewBag.CareerName = careerInputBox;
            ViewBag.CareerCategory = careerDropDown;


            return View(students);
        }

        public JsonResult GetStudents(string term)
        {
            GearUpDBEntities db = new GearUpDBEntities();
            List<string> students = db.Students.Where(s => s.firstName.StartsWith(term) || s.lastName.StartsWith(term))
                .Select(x => x.firstName + " " + x.lastName).ToList();

            return Json(students, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Print()
        {
            ViewBag.Message = "Print";

            return View();
        }
    }
}