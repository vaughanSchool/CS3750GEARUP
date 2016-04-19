using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GearUp.Models.API_Model
{
    public class Notes
    {
        public int noteID { get; set; }
        public int personID { get; set; }
        public string note { get; set; }
    }
}