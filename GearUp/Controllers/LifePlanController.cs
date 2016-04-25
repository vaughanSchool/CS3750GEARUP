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
        //List<string> studentAdvisor = new List<string>();
        List<string> academic = new List<string>();
        List<string> schoolGoals = new List<string>();
        List<string> career = new List<string>();
        List<string> careerType = new List<string>();


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
            // ViewBag.StudentAdvisor = studentAdvisor;
            ViewBag.Academic = academic;
            ViewBag.SchoolGoals = schoolGoals;
            ViewBag.Career = career;
            ViewBag.CareerType = careerType;

            return View(db.Students);
        }

              

        //This post will be used when the student is selected
        //and all information for their lifeplan is grabbed.
        [HttpPost]
        public ActionResult Edit(string searchTerm)
        {
            GearUpDBEntities db = new GearUpDBEntities();
            List<Student> students = null;
            //List<Advisor> advisor = null;

            if (string.IsNullOrEmpty(searchTerm))
            {
                //Do Nothing
            }
            else
            {
                students = db.Students
                    .Where(s => s.firstName.StartsWith(searchTerm) || s.lastName.StartsWith(searchTerm)
                    || s.firstName + " " + s.lastName == searchTerm).ToList();
                /*
                advisor = db.Advisors
                   .Where(s => s.advisorID.Equals(students[0].advisorID)).ToList();

                studentAdvisor[0] = advisor[0].firstName + " " + advisor[0].lastName;
            */
            }

           


            //Need to check if student exsists



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
            //ViewBag.StudentAdvisor = studentAdvisor;
            ViewBag.Academic = academic;
            ViewBag.schoolGoals = schoolGoals;
            ViewBag.Career = career;
            ViewBag.CareerType = careerType;

            return View(students);
        }

        


        public JsonResult GetStudents(string term)
        {
            GearUpDBEntities db = new GearUpDBEntities();
            List<string> students = db.Students.Where(s => s.firstName.StartsWith(term) || s.lastName.StartsWith(term))
                .Select(x => x.firstName + " " + x.lastName).ToList();

            return Json(students, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAdvisors(string term)
        {
            GearUpDBEntities db = new GearUpDBEntities();
            List<string> advisors = db.Advisors.Where(s => s.firstName.StartsWith(term) || s.lastName.StartsWith(term))
                .Select(x => x.firstName + " " + x.lastName).ToList();

            return Json(advisors, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult input(string academicNeeds)
        {
            List<string> academic = null;
            if (string.IsNullOrEmpty(academicNeeds))
            {
                //Do Nothing
            }

            academic.Add(academicNeeds);
            ViewBag.Academic = academic;

            return View(academic);
        }

        [HttpPost]
        public ActionResult input2(string educationalGoals)
        {
            List<string> schoolGoals = null;
            if (string.IsNullOrEmpty(educationalGoals))
            {
                //Do Nothing
            }

            schoolGoals.Add(educationalGoals);
            ViewBag.SchoolGoals = schoolGoals;

            return View(schoolGoals);
        }

        [HttpPost]
        public ActionResult input3(string careerGoals, string categorySelection)
        {
            List<string> career = null;
            List<string> careerType = null;
            if (string.IsNullOrEmpty(careerGoals))
            {
                //Do Nothing
            }


            career.Add(careerGoals);
            careerType.Add(categorySelection);
            ViewBag.Career = career;
            ViewBag.CareerType = careerType; 

            return View(career);
        }

        public ActionResult Print()
        {
            ViewBag.Message = "Print";

            return View();
        }
    }
}

