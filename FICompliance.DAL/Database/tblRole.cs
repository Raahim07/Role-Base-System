using FICompliance.DAL.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FICompliance.BOL.Database
{
    public class tblRole
    {
        [Key]
        public int ID { get; set; }
        public string RoleTypeName { get; set; }
        public string RoleType { get; set; }

        public virtual ICollection<tblRolesMenu> RolesMenus { get; set; }

    }
}
