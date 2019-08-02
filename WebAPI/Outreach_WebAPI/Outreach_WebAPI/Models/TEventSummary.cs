using System;
using System.Collections.Generic;

namespace Outreach_WebAPI.Models
{
    public partial class TEventSummary
    {
        public int Sno { get; set; }
        public string Eventid { get; set; }
        public string Month { get; set; }
        public string Baselocation { get; set; }
        public string Beneficiaryname { get; set; }
        public string Venueaddress { get; set; }
        public string Councilname { get; set; }
        public string Project { get; set; }
        public string Category { get; set; }
        public string Eventname { get; set; }
        public string Eventdescription { get; set; }
        public DateTime? Eventdate { get; set; }
        public int? Totalnoofvolunteers { get; set; }
        public int? Totalvolunteerhours { get; set; }
        public int? Totaltravelhours { get; set; }
        public int? Overallvolunteeringhours { get; set; }
        public int? Livesimpacted { get; set; }
        public int? Activitytype { get; set; }
        public string Status { get; set; }
        public int? Pocid { get; set; }
        public string Pocname { get; set; }
        public int? Poccontactnumber { get; set; }
    }
}
