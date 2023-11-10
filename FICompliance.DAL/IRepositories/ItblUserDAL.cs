using FI_Compliance.BOL;
using FICompliance.BOL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FICompliance.DAL.IRepositories
{
    public interface ItblUserDAL
    {
        List<tblUser> usersList();

        bool AddUser (UsersBOL user);

        bool LogIn(UsersBOL user);

        int GetRoleID(string username);

        bool isApproved(string username, string password);

        int GetUserId(string username);
        bool UpdateUser(UsersBOL user);

        bool UserExists(string userName, string userEmail, string userPhone);

        bool SearchByID(int id);

        

    }
}
