using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GearUp.Models;
using System;

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
        string studentAdvisor = "";
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

            setViewBags();
            return View(db.Students);
        }


        /// <summary>
        /// Used to return information based on which submit button was pressed.
        /// 'submit' is the VALUE of the button pressed
        /// 'searchTerm' is used if the user is searching for a student.
        /// </summary>
        /// <param name="submit"></param>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(string submit, string searchTerm)
        {
            switch (submit)
            {
                case "Search":
                    return (SearchStudent(searchTerm));
                case "Submit":
                    //This will need a method that takes 3? lists containing the new 
                    //lifeplan info that will be added to the databse.
                    //Need to find out how the current information like student and avisor will
                    //be affected by this. (they may need to be found again...)
                    return View();
                //Other submit buttons go here.
                default:
                    setViewBags();
                    return View();
            }
        }





        /// <summary>
        /// Used to return a list of all students with the name like..
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        public JsonResult GetStudents(string term)
        {
            GearUpDBEntities db = new GearUpDBEntities();
            List<string> students = db.Students.Where(s => s.firstName.StartsWith(term) || s.lastName.StartsWith(term))
                .Select(x => x.firstName + " " + x.lastName).ToList();

            return Json(students, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Used to return a list of all advisors with the name like...
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        public JsonResult GetAdvisors(string term)
        {
            GearUpDBEntities db = new GearUpDBEntities();
            List<string> advisors = db.Advisors.Where(s => s.firstName.StartsWith(term) || s.lastName.StartsWith(term))
                .Select(x => x.firstName + " " + x.lastName).ToList();

            return Json(advisors, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// This function is used to parse out the student search text box
        /// and return information on the student if that student exsits.
        /// 'name' is what the user entered in the text box.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ActionResult SearchStudent(string name)
        {
            GearUpDBEntities db = new GearUpDBEntities();
            List<Student> students = null;

            if (!string.IsNullOrEmpty(name))
            {
                students = db.Students
                    .Where(s => s.firstName.StartsWith(name) || s.lastName.StartsWith(name)
                    || s.firstName + " " + s.lastName == name
                    || s.lastName + " " + s.firstName == name).ToList();
                if (students.Count == 1
                    && name.Equals(students[0].firstName + " " + students[0].lastName, StringComparison.InvariantCultureIgnoreCase)
                    || name.Equals(students[0].lastName + " " + students[0].firstName, StringComparison.InvariantCultureIgnoreCase))
                {
                    //Finds student's advisor's name for autofill
                    if (students[0].Advisor != null)
                    {
                        studentAdvisor = students[0].Advisor.firstName + " " + students[0].Advisor.lastName;
                    }


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

                }
            }
            setViewBags();
            return View();
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

        /// <summary>
        /// Used to set all viewBags
        /// This was created because of multiple submit buttons on the page
        /// </summary>
        public void setViewBags()
        {
            //set the lists to a view bag
            ViewBag.Needs = needs;
            ViewBag.Education = education;
            ViewBag.CareerName = careerInputBox;
            ViewBag.CareerCategory = careerDropDown;
            ViewBag.StudentAdvisor = studentAdvisor;
            ViewBag.Academic = academic;
            ViewBag.SchoolGoals = schoolGoals;
            ViewBag.Career = career;
            ViewBag.CareerType = careerType;

            return;
        }
    }
}

