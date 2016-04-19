using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GearUp.Models.API_Model
{
    public class Survey
    {
        public int surveyID { get; set; }
        public int studentID { get; set; }
        public bool studentCompleted { get; set; }
        public bool parentCompleted { get; set; }
    }
}