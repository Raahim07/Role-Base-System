using FICompliance.DAL.Database;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FICompliance.BOL.Database
{
    public class tblMenu
    {
        [Key]
        public int MenuID { get; set; }

        public string MenuName { get; set; }

        public virtual ICollection<tblRolesMenu> RolesMenus { get; set; }
    }
}