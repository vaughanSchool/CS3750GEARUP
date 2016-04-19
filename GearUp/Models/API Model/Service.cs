using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GearUp.Models.API_Model
{
    public class Service
    {
        public int serviceCodeID { get; set; }
        public char serviceCode { get; set; }
        public char description { get; set; }
    }
}