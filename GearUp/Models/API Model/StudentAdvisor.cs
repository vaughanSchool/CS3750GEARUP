using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GearUp.Models.API_Model
{
    public class StudentAdvisor
    {
        public int studentAdvisorID { get; set; }
        public int advisorID { get; set; }
        public int studentID { get; set; }
    }
}