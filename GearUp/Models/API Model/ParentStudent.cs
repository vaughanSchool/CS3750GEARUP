using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GearUp.Models.API_Model
{
    public class ParentStudent
    {
        public int parentStudentID { get; set; }
        public int parentID { get; set; }
        public int studentID { get; set; }
    }
}