using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GearUp.Models.API_Model
{
    public class ServiceContact
    {
        public int serviceID { get; set; }
        public int serviceCodeID { get; set; }
        public char serviceName { get; set; } 
    }
}