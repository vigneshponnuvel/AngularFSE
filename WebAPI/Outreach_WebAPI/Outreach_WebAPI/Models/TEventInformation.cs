using System;
using System.Collections.Generic;

namespace Outreach_WebAPI.Models
{
    public partial class TEventInformation
    {
        public int Sno { get; set; }
        public string Eventid { get; set; }
        public string Baselocation { get; set; }
        public string Beneficiaryname { get; set; }
        public string Councilname { get; set; }
        public string Eventname { get; set; }
        public string Eventdescription { get; set; }
        public DateTime? Eventdate { get; set; }
        public int? Employeeid { get; set; }
        public string Employeename { get; set; }
        public int? Volunteerhours { get; set; }
        public int? Travelhours { get; set; }
        public int? Livesimpacted { get; set; }
        public string Businessunit { get; set; }
        public string Status { get; set; }
        public string Iiepcategory { get; set; }
    }
}
