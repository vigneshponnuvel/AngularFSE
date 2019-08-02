using System;
using System.Collections.Generic;

namespace Outreach_WebAPI.Models
{
    public partial class TMstrUser
    {
        public int Userid { get; set; }
        public string Username { get; set; }
        public string Useremail { get; set; }
        public int? Roleid { get; set; }
        public bool? Isactive { get; set; }
        public string Password { get; set; }
        public DateTime Createddt { get; set; }
    }
}
