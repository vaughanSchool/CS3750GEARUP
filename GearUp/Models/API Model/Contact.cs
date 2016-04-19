using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GearUp.Models.API_Model
{
    public class Contact
    {
        public int contactID { get; set; }
        public int personID { get; set; }
        public int serviceID { get; set; }
        public DateTime serviceDate { get; set; }
        public int serviceMinutes { get; set; }
    }
}