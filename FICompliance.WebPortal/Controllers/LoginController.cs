using FI_Compliance.BOL;
using FICompliance.BLL.Logics;
using FICompliance.WebPortal.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Collections;
using static System.Collections.Specialized.BitVector32;
using System.Net;
using FICompliance.BOL.Database;
using System.Data.Entity;
using System.Web.UI.WebControls;
using System.Data;
using FICompliance.DAL.Database;

namespace FICompliance.WebPortal.Controllers
{
    public class LoginController : Controller
    {
        private readonly ItblUserBLL _userLogicsBLL;
        dbContextComp db = new dbContextComp();

        public LoginController()
        {
            this._userLogicsBLL = new tblUserBLL();
        }

        public ActionResult _GetUsersDetail()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult _GetUserDetails(int userId)
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = db.tblUsers.FirstOrDefault(u => u.UserID == userId);

                if (user != null)
                {
                    return PartialView("_GetUsersDetail", user);
                }

                return Json(new { success = false });
            }
            return View("Login");

        }

        [HttpPost]
        public ActionResult UpdateUserStatus(int userId, bool isChecked)
        {
            var user = db.tblUsers.Find(userId);

            if (user != null)
            {
                if (isChecked)
                {
                    user.IsApprove = isChecked;
                    user.IsPending = false;
                }
                else
                {
                    
                    user.IsPending = true;
                    user.IsApprove = false;
                       
                }

                db.SaveChanges();

                return Json(new { success = true, isChecked = isChecked });
            }

            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult DeleteUserStatus(int userId, bool isChecked)
        {
            var user = db.tblUsers.Find(userId);

            if (user != null)
            {
                user.IsPending = true;
                user.IsActive = user.IsApprove = false;
                

                db.SaveChanges();

                return Json(new { success = true, isChecked = isChecked });
            }

            return Json(new { success = false });
        }


        public ActionResult UsersProfile()
        {

            if (User.Identity.IsAuthenticated)
            {
                string userName = User.Identity.Name;                
                var currentUser = db.tblUsers.FirstOrDefault(u => u.UserName == userName);

                if (currentUser != null)
                {
                    return View(currentUser);
                }
            }
            return View("Login");
        }


        [HttpPost]
        public ActionResult ApproveUserStatus(int userId, bool isChecked)
        {
            var user = db.tblUsers.Find(userId);

            if (user != null)
            {
                user.IsArchive = true;
                user.IsPending = false; 
                db.SaveChanges();

                return Json(new { success = true, isChecked = isChecked });
            }

            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult RejectUserStatus(int userId, bool isChecked)
        {
            var user = db.tblUsers.Find(userId);

            if (user != null)
            {
                user.IsApprove = user.IsActive = true;
                user.IsPending = user.IsArchive = false;
                db.SaveChanges();

                return Json(new { success = true, isChecked = isChecked });
            }

            return Json(new { success = false });
        }

        [HttpGet]
        public ActionResult UsersList()
        {

            dbContextComp db = new dbContextComp();

            string username = User.Identity.GetUserName();
            int roleId = _userLogicsBLL.GetRoleID(username);           

            var recordsForRole = db.tblRolesMenu.Where(rm => rm.RoleID == roleId).ToList();
            
            var menuNamesForRole =
            (from rm in recordsForRole
            join menu in db.tblMenus on rm.MenuID equals menu.MenuID
            select menu.MenuName).ToList();

            string selectedMenuName = menuNamesForRole.FirstOrDefault(menuName => menuName == "Users List");

            if (User.Identity.IsAuthenticated && selectedMenuName != null )
            {
                    string userName = User.Identity.Name;
                    ViewBag.userList = _userLogicsBLL.GetUsersList().Where(u => u.UserName != userName && u.IsArchive == false);
                return View();
            }
            return RedirectToAction("Index","Home");
        }
        
        public ActionResult AddUser(tblUser user)
        {
            string username = User.Identity.GetUserName();
            int roleId = _userLogicsBLL.GetRoleID(username);
            int loggedInUserId = _userLogicsBLL.GetUserId(username);

//            var menuIdToCheck = (
//    from u in db.tblUsers
//    join r in db.tblRoles on u.RoleID equals r.ID
//    join rm in db.tblRolesMenu on r.ID equals rm.RoleID
//    where u.UserID == loggedInUserId
//    select rm.MenuID
//).ToList();

            //var recordsForRole = db.tblRolesMenu.Where(rm => rm.RoleID == roleId).ToList();
            bool hasAccess = (
    from rm in db.tblRolesMenu
    where rm.RoleID == roleId select 
).ToList();
            //var menuNamesForRole =
            //(from rm in recordsForRole
            // join menu in db.tblMenus on rm.MenuID equals menu.MenuID
            // select menu.MenuName).ToList();

           // string selectedMenuName = menuNamesForRole.FirstOrDefault(menuName => menuName == "add user");
            if (User.Identity.IsAuthenticated && hasAccess)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
            
        }

        [HttpPost]
        public ActionResult CheckUserExists(string userName, string userEmail, string userPhone)
        {
            bool userExists = _userLogicsBLL.UserExists(userName, userEmail, userPhone);

            return Json(new { exists = userExists });
        }

        [HttpPost]
        public ActionResult AddUser(UsersBOL obj)
        {
                       
                try
                {
                
                    if (obj.UserID > 0)
                    {
                        bool isUpdated = _userLogicsBLL.UpdateUser(obj);
                        if (isUpdated)
                        {
                            return RedirectToAction("UsersList", "Login");
                        }
                    }
                    else
                    {
                        bool userExists = _userLogicsBLL.UserExists(obj.UserName, obj.Email, obj.Phone);
                        if (userExists)
                        {
                            return Json(new { success = false });
                        }

                        bool isfound = _userLogicsBLL.AddUser(obj);

                        if (isfound)
                        {
                            return RedirectToAction("UsersList", "Login");
                        }
                    }

                    return RedirectToAction("AddUser", "Login"); // Display the view with validation errors or updated user details                
               
                }
                catch (Exception ex)
                {
                    throw ex;
                }
           
        }


        public ActionResult LogIn()
        {

            return View();
        }

        [HttpPost]
        public ActionResult LogIn(UsersBOL users)
        {
            try
            {
                bool isAuthenticated = _userLogicsBLL.LogIn(users);
                bool isValid = _userLogicsBLL.isApproved(users.UserName, users.Password);

                if (isAuthenticated && isValid)
                {
                    Userview obj = new Userview();
                    obj.UserName = users.UserName;                 

                    SetClaimIdentity(obj);
                    FormsAuthentication.SetAuthCookie(users.UserName, false);

                    int roleId = _userLogicsBLL.GetRoleID(obj.UserName);
                    Session["roleId"] = roleId == 1 ? "Admin Maker" : roleId == 2 ? "Admin Checker" : roleId == 7 ? "Maker" : "Checker";


                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false });
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public ActionResult MakerAndChecker()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }

            return RedirectToAction("LogIn","Login");       
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        private void SetClaimIdentity(Userview usrviewmodel)
        {

            if (usrviewmodel != null)
            {
                if (!string.IsNullOrEmpty(usrviewmodel.UserName))
                {
                    var claims = new List<Claim>();

                    claims.Add(new Claim(ClaimTypes.Sid, usrviewmodel.UserID.ToString()));
                    claims.Add(new Claim(ClaimTypes.Name, usrviewmodel.UserName.ToString()));
                    claims.Add(new Claim(ClaimTypes.Role, usrviewmodel.RoleID.ToString()));


                    var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                    var authenticationManager = Request.GetOwinContext().Authentication;
                    authenticationManager.SignIn(identity);
                    var claimsPrincipal = new ClaimsPrincipal(identity);
                    Thread.CurrentPrincipal = claimsPrincipal;
                }

            }
        }

        public ActionResult LogOut()
        {
            List<string> keys = new List<string>();

            foreach (DictionaryEntry item in HttpContext.Cache)
            {
                keys.Add(item.Key.ToString());
            }

            foreach (string key in keys)
            {
                HttpContext.Cache.Remove(key);
            }

            AuthenticationManager.SignOut();
            HttpCookie c = new HttpCookie(".AspNet.ApplicationCookie");
            c.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(c);

            HttpCookie d = new HttpCookie("__RequestVerificationToken");
            d.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(d);

            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToRoute(new { controller = "Login", action = "LogIn" });

        }
    }
}
