using FI_Compliance.BOL;
using FICompliance.BOL.Database;
using FICompliance.DAL.IRepositories;
using FICompliance.BLL.Logics;
using FICompliance.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FICompliance.BLL.Logics
{
    public class tblUserBLL : ItblUserBLL
    {
        private readonly ItblUserDAL _itblUsersDAL;

        public tblUserBLL()
        {
            this._itblUsersDAL = new tblUserDAL();
        }

        public bool AddUser(UsersBOL users)
        {
            bool isfound = false;

            if (users != null)
            {

                if (users != null)
                {

                    bool userExists = _itblUsersDAL.UserExists(users.UserName, users.Email, users.Phone);

                    if (userExists)
                    {
                        return false;
                    }
                }



                try
                {
                    isfound = _itblUsersDAL.AddUser(users);
                }
                catch (Exception)
                {


                }
            }

            return isfound;
        }
        public List<UsersBOL> GetUsersList()
        {
                List<UsersBOL> list = new List<UsersBOL>();
                List<tblUser> users = _itblUsersDAL.usersList();
                foreach (var item in users)
                {
                    UsersBOL use = new UsersBOL();
                    use.UserID = item.UserID;
                    use.RoleID = item.RoleID;
                    use.FullName = item.FullName;
                    use.UserName = item.UserName;
                    use.Password = item.Password;
                    use.Email = item.Email;
                    use.Phone = item.Phone;
                    use.MartialStatus= item.MartialStatus;
                    use.Nationality = item.Nationality;
                    use.IsActive = item.IsActive;
                    use.IsArchive = item.IsArchive;
                    use.IsApprove = item.IsApprove;
                    use.IsPending = item.IsPending;
                    list.Add(use);

                }
                return list;
        }

        public int GetRoleID(string userName)
        {
            return _itblUsersDAL.GetRoleID(userName);
        }

        public bool isApproved(string userName, string password)
        {
            return _itblUsersDAL.isApproved(userName, password);
        }

        public int GetUserId(string userName)
        {
            return _itblUsersDAL.GetUserId(userName);
        }

        public bool LogIn(UsersBOL user)
        {
            bool isfound = false;
            try
            {
                isfound = _itblUsersDAL.LogIn(user);
            }
            catch (Exception)
            {


            }

            return isfound;

        }

        public bool UserExists(string userName, string userEmail, string userPhone)
        {
            bool userExists = _itblUsersDAL.UserExists(userName, userEmail, userPhone);

            if (userExists)
            {
                return true;
            }

            return false;
        }

        public bool UpdateUser(UsersBOL user)
        {
            UsersBOL userBOL = new UsersBOL();
            bool isfound = false;
            try
            {
                isfound = _itblUsersDAL.UpdateUser(user);
            }
            catch (Exception)
            {


            }

            return isfound;

        }

        public bool SearchByID(int id)
        {
            bool isfound = false;
            try
            {
                isfound = _itblUsersDAL.SearchByID(id);
            }
            catch (Exception)
            {


            }

            return isfound;

        }
    }
}
