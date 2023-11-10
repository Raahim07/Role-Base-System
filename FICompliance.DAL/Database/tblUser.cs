using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FICompliance.BOL.Database
{
    public class tblUser
    {
        [Key]
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string MartialStatus { get; set; }
        public string Nationality { get; set; }
        //public string DateOfBirth { get; set; }
        //public string DateOfJoining { get; set; }
        //public string DateOfConfirm { get; set; }
        //public string CNIC { get; set; }
        //public string CNICIssueDate { get; set; }
        //public string CNICExpiryDate { get; set; }
        //public string NTN { get; set; }
        //public string PresentAddress { get; set; }
        //public string PermanentAddress { get; set; }
        //public int CreatedBy { get; set; }
        //public int UpdatedBy { get; set; }
        //public int ApprovedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsArchive { get; set; }
        public System.DateTime CreatedDate { get; set; }
        
        public bool IsApprove { get; set; }
        public bool IsPending { get; set; }

        [ForeignKey("tblRole")]
        public int RoleID { get; set; }


        public virtual tblRole tblRole { get; set; }
    }
}
