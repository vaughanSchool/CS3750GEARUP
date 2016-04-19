using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GearUp.Models
{
    public class StudentViewModel
    {
        public Student student { get; set; }
        public IEnumerable<Contact> contactLog { get; set; }
        public IEnumerable<School> schools { get; set; }
    }
}