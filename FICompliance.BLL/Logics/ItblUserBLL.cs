using FI_Compliance.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FICompliance.BLL.Logics
{
    public interface ItblUserBLL
    {
        List<UsersBOL> GetUsersList();

        bool AddUser(UsersBOL users);

        bool LogIn(UsersBOL user);

        int GetRoleID(string username);

        int GetUserId(string username);

        bool isApproved(string username, string password);
        bool UserExists(string userName, string userEmail, string userPhone);
        bool UpdateUser(UsersBOL users);

        bool SearchByID(int id);
    }
}
