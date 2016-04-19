using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GearUp.Models.API_Model
{
    public class Term
    {
        public int schduleID { get; set; }
        public int classID { get; set; }
        public int termID { get; set; }
        public int period { get; set; }
        public int crPointsNeeded { get; set; }
    }
}