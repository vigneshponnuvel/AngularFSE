using System;
using System.Collections.Generic;

namespace Outreach_WebAPI.Models
{
    public partial class TTtrnFeedback
    {
        public int Feedbackid { get; set; }
        public string Eventid { get; set; }
        public int Associateid { get; set; }
        public string Feedbackcategory { get; set; }
        public string Mainfeedback { get; set; }
        public string Optionalfeedback1 { get; set; }
        public string Optionalfeedback2 { get; set; }
        public string Associatestatus { get; set; }
        public DateTime Createddt { get; set; }
    }
}
