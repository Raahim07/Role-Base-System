using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FI_Compliance.BOL
{
    public class UsersBOL
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string MartialStatus { get; set; }
        public string Nationality { get; set; }
        public bool IsActive { get; set; }
        public bool IsArchive { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public bool IsApprove { get; set; }
        public bool IsPending { get; set; }

    }
}
