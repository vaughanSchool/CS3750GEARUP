using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GearUp.Models.API_Model
{
    public class Person
    {
        public int personID { get; set; }
        public char firstName { get; set; }
        public char lastName { get; set; }
        public char gender { get; set; }
        public int preferredLanguage { get; set; }
    }
}