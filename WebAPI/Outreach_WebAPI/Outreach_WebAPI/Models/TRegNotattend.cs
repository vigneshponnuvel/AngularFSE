using System;
using System.Collections.Generic;

namespace Outreach_WebAPI.Models
{
    public partial class TRegNotattend
    {
        public int Sno { get; set; }
        public string Eventid { get; set; }
        public string Eventname { get; set; }
        public string Beneficiaryname { get; set; }
        public string Baselocation { get; set; }
        public DateTime? Eventdate { get; set; }
        public int? Employeeid { get; set; }
    }
}
