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
    
    public partial class Note
    {
        public int noteID { get; set; }
        public int studentID { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string note1 { get; set; }
    
        public virtual Student Student { get; set; }
    }
}
