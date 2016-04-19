using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GearUp.Models.API_Model
{
    public class StudentCollege
    {
        public int studentCollegeID { get; set; }
        public int studentID { get; set; }
        public int collegeID { get; set; }
        public int preference { get; set; }
        public int status { get; set; }
    }
}