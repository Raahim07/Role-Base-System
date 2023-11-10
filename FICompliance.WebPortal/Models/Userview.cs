using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FICompliance.WebPortal.Models
{
    public class Userview
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int roleId { get; set; }
    }
}