using FICompliance.BOL.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FICompliance.DAL.Database
{
    public class tblRolesMenu
    {
        [Key]
        public int MenuRoleID { get; set; }

        [ForeignKey ("tblMenu")]
        public int MenuID { get; set; }

        [ForeignKey ("tblRole")] 
        public int RoleID { get; set; }

        public bool IsAllowed { get; set; }

        public virtual tblMenu tblMenu { get; set; }

        public virtual tblRole tblRole { get; set; }
    }
}
