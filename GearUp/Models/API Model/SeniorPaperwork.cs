using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GearUp.Models.API_Model
{
    public class SeniorPaperwork
    {
        public int seniorPaperworkID { get; set; }
        public int studentID { get; set; }
        public bool ferpaReleaseComplete { get; set; }
        public bool uheaaFafsaStatus { get; set; }
        public bool FafsaVerification { get; set; }
        public double pellGrantAmount { get; set; }
        public DateTime collegeStartDate { get; set; }
        public int collegeID { get; set; }
        public char exitStatus1 { get; set; }
        public char exitStatus2 { get; set; }
        public char exitStatus3 { get; set; }
    }
}