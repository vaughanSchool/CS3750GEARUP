//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GearUp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SeniorPaperwork
    {
        public int seniorPaperworkID { get; set; }
        public int studentID { get; set; }
        public Nullable<bool> ferpaReleaseComplete { get; set; }
        public Nullable<bool> uheaaFafsaStatus { get; set; }
        public Nullable<bool> fafsaVerification { get; set; }
        public Nullable<decimal> pellGrantAmount { get; set; }
        public Nullable<System.DateTime> collegeStateDate { get; set; }
        public Nullable<int> collegeID { get; set; }
        public string exitStatus1 { get; set; }
        public string exitStatus2 { get; set; }
        public string exitStatus3 { get; set; }
    
        public virtual Student Student { get; set; }
    }
}
