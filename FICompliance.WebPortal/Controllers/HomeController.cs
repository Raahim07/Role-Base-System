using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FICompliance.WebPortal.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View("Index");
            }
            //return RedirectToAction("LogIn", "Login");
            return RedirectToRoute(new { controller = "Login", action = "LogIn" });
        }

        public ActionResult Contact()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View("Contact");
            }
            return RedirectToRoute(new { controller = "Login", action = "LogIn" });
        }

        public ActionResult About()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View("About");
            }
            return RedirectToRoute(new { controller = "Login", action = "LogIn" });
        }
    }
}