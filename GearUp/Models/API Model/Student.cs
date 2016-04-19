using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GearUp.Models.API_Model
{
    public class Student
    {
        public int studentID { get; set; }
        public int personID { get; set; }
        public int schoolID { get; set; }
        public int compassStudentID { get; set; }
        public DateTime? MyProperty { get; set; }
        public int classOf { get; set; }
        public bool iep { get; set; }
        public bool lep { get; set; }
        public bool collegeGreenlight { get; set; }
        public bool lifePlaneStatus { get; set; }
        public string mathLevel { get; set; }
        public string wNumber { get; set; }
        public string careerGoal1 { get; set; }
        public string careerGoal2 { get; set; }
    }
}