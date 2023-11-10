using FICompliance.WebPortal.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FICompliance.WebPortal.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected override void Initialize(RequestContext req)
        {
            base.Initialize(req);
            if (utility.GetUserInfo("UserName") == null)
            {
                req.HttpContext.Response.Clear();
                req.HttpContext.Response.Redirect("LogIn");
                req.HttpContext.Response.End();
            }
        }
    }
}