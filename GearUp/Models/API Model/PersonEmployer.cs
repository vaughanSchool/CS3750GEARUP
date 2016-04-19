using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GearUp.Models.API_Model
{
    public class PersonEmployer
    {
        public int personEmployerID { get; set; }
        public int personID { get; set; }
        public int employerID { get; set; }
    }
}