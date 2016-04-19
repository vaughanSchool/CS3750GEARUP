using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GearUp.Models.API_Model
{
    public class Class
    {
        public int classID { get; set; }
        public int schoolID { get; set; }
        public string teacherName { get; set; }
        public string className { get; set; }
        public string rigorCode { get; set; }
    }
}