using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;

namespace FICompliance.WebPortal.Utilities
{
    public class utility
    {
        public static string GetUserInfo(string value)
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            string ReturnVal = string.Empty;
            switch (value)
            {

                case "UserID":
                    ReturnVal = identity.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault();
                    break;
                case "RoleID":
                    ReturnVal = identity.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(c => c.Value).SingleOrDefault();
                    break;
                case "FullName":
                    ReturnVal = identity.Claims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).SingleOrDefault();
                    break;

                case "roleId":
                    ReturnVal = identity.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault();
                    break;
                case "UserName":
                    ReturnVal = identity.Claims.Where(c => c.Type == ClaimTypes.GivenName).Select(c => c.Value).SingleOrDefault();
                    break;
                //case "profilepic":
                //    ReturnVal = identity.Claims.Where(c => c.Type == ClaimTypes.Thumbprint).Select(c => c.Value).SingleOrDefault();
                //    break;
                case "Email":
                    ReturnVal = identity.Claims.Where(c => c.Type == ClaimTypes.Email).Select(c => c.Value).SingleOrDefault();
                    break;
                //case "officeid":
                //    ReturnVal = identity.Claims.Where(c => c.Type == ClaimTypes.PrimaryGroupSid).Select(c => c.Value).SingleOrDefault();
                //    break;
                //case "officename":
                //    ReturnVal = identity.Claims.Where(c => c.Type == ClaimTypes.PrimarySid).Select(c => c.Value).SingleOrDefault();
                //    break;
                //case "roleid":
                //    ReturnVal = identity.Claims.Where(c => c.Type == ClaimTypes.PrimarySid).Select(c => c.Value).SingleOrDefault();
                //    break;
                //case "role":
                //    ReturnVal = identity.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).SingleOrDefault();
                //    break;
                //case "cityid":
                //    ReturnVal = identity.Claims.Where(c => c.Type == ClaimTypes.GroupSid).Select(c => c.Value).SingleOrDefault();
                //    break;
                //case "cityname":
                //    ReturnVal = identity.Claims.Where(c => c.Type == ClaimTypes.GivenName).Select(c => c.Value).SingleOrDefault();
                //    break;

                //case "companyid":
                //    ReturnVal = identity.Claims.Where(c => c.Type == ClaimTypes.GivenName).Select(c => c.Value).SingleOrDefault();
                //    break;
                //case "officeid":
                //    ReturnVal = identity.Claims.Where(c => c.Type == ClaimTypes.GroupSid).Select(c => c.Value).SingleOrDefault();
                //    break;
                //case "companyName":
                //    ReturnVal = identity.Claims.Where(c => c.Type == ClaimTypes.Actor).Select(c => c.Value).SingleOrDefault();
                //    break;
                //case "officeName":
                //    ReturnVal = identity.Claims.Where(c => c.Type == ClaimTypes.Locality).Select(c => c.Value).SingleOrDefault();
                //    break;
                //case "picture":
                //    ReturnVal = identity.Claims.Where(c => c.Type == ClaimTypes.Thumbprint).Select(c => c.Value).SingleOrDefault();
                //    break;
                //case "Logo":
                //    ReturnVal = identity.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(c => c.Value).SingleOrDefault();
                //    break;
                default:
                    ReturnVal = "";
                    break;
            }

            return ReturnVal;

        }

    }
}