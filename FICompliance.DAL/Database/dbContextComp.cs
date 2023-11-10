using FICompliance.DAL.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FICompliance.BOL.Database
{
    public class dbContextComp : DbContext
    {
        public dbContextComp() : base("name=dbContextComp") { }

        public DbSet<tblUser> tblUsers { get; set; }
        public DbSet<tblRole> tblRoles { get; set; }

        public DbSet<tblMenu> tblMenus { get; set; }

        public DbSet<tblRolesMenu> tblRolesMenu { get; set; }


    }
}
