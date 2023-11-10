using FI_Compliance.BOL;
using FICompliance.BOL.Database;
using FICompliance.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FICompliance.DAL.Repositories
{
    public class tblUserDAL : ItblUserDAL
    {
        private readonly dbContextComp UserEntities;

        public tblUserDAL()
        {
            UserEntities = new dbContextComp();
        }

        public List<tblUser> usersList()
        {
            return UserEntities.tblUsers.ToList();
        }
        public bool AddUser(UsersBOL users)
        {
            if (users != null)
            {
                try
                {
                    tblUser usersinfo = new tblUser();

                    // Set user information
                    usersinfo.UserID= users.UserID;
                    usersinfo.FullName = users.FullName;
                    usersinfo.UserName = users.UserName;
                    usersinfo.Password = users.Password;
                    usersinfo.Email = users.Email;
                    usersinfo.Phone = users.Phone;
                    usersinfo.CreatedDate = DateTime.Now;
                    usersinfo.RoleID = users.RoleID;
                    usersinfo.MartialStatus = users.MartialStatus;
                    usersinfo.Nationality = users.Nationality;
                    usersinfo.IsApprove = usersinfo.IsArchive = false;
                    usersinfo.IsActive = usersinfo.IsPending =   true;
                    

                    UserEntities.tblUsers.Add(usersinfo);
                    UserEntities.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }

            return false;
        }

        public int GetRoleID(string userName)
        {
            using (var dbContext = new dbContextComp())
            {
                var user = dbContext.tblUsers.FirstOrDefault(u => u.UserName == userName);

                if (user != null)
                {
                    return user.RoleID;
                    //{
                    //    RoleID = user.RoleID,
                    //    FullName = user.FullName // Assuming there's a property named FullName in your tblUsers
                    //};
                }
            }

            return -1; 
        }
        public bool UpdateUser(UsersBOL user)
        {
            try
            {
                var existingUser = UserEntities.tblUsers.FirstOrDefault(u => u.UserID == user.UserID);

                if (existingUser != null)
                {
                    existingUser.FullName = user.FullName;
                    existingUser.RoleID = user.RoleID ;
                    existingUser.UserName = user.UserName;
                    existingUser.Password = user.Password;
                    existingUser.Email = user.Email;
                    existingUser.Phone = user.Phone;
                    existingUser.MartialStatus = user.MartialStatus;
                    existingUser.Nationality = user.Nationality;
                    existingUser.IsApprove = false;
                    existingUser.IsPending = true;


                    UserEntities.Entry(existingUser).State = (System.Data.Entity.EntityState)EntityState.Modified;
                    UserEntities.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool UserExists(string userName,string userEmail,string userPhone)
        {
            
            return UserEntities.tblUsers.Any(u =>
                u.UserName == userName || u.Email == userEmail || u.Phone == userPhone);
        }
        public bool isApproved(string userName, string password)
        {
            using (var dbContext = new dbContextComp())
            {
                var user = dbContext.tblUsers.FirstOrDefault(u => u.UserName == userName && u.Password == password);

                if (user != null)
                {
                    return user.IsApprove;
                }
            }

            return false;
        }
        public int GetUserId(string userName)
        {
            using (var dbContext = new dbContextComp())
            {
                var user = dbContext.tblUsers.FirstOrDefault(u => u.UserName == userName );

                if (user != null)
                {
                    return user.UserID;
                }
            }

            return -1;
        }
        public bool LogIn(UsersBOL user)
        {
            bool isAuthenticated = false;

            using (var dbContext = new dbContextComp()) 
            {
                var users = dbContext.tblUsers.FirstOrDefault(u => u.UserName == user.UserName  && u.Password == user.Password);
                
                if (users != null)
                {
                    isAuthenticated = true;
                }
            }
            

            return isAuthenticated;
        }

        public bool SearchByID(int id)
        {
            var users = UserEntities.tblUsers.FirstOrDefault(u=> u.UserID == id);

            bool isfound = false;
            if (users != null)
            {   
                isfound = true;
            }

            return isfound;
        }
    }

}
