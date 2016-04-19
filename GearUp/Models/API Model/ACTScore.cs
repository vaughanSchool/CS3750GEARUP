using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GearUp.Models.API_Model
{
    public class ACTScore
    {
        public int actID { get; set; }
        public int studentiD { get; set; }
        public int attempted { get; set; }
        public DateTime dateAttempted { get; set; }
        public int compositeScore { get; set; }
        public int englishScore { get; set; }
        public int mathScore { get; set; }
        public int readingScore { get; set; }
        public int scienceScore { get; set; }
    }
}