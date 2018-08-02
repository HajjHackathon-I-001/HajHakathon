using HajHakathon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HajHakathon.Controllers
{
    public class BaseController : Controller
    {

        public Sys_Users LoggedInUser()
        {
            if (IsloggedIn()) return Session["LoggedInUser"] as Sys_Users;
            return null;
        }

        public bool IsloggedIn()
        {
            var LoggedUser = Session["LoggedInUser"] as Sys_Users;
            if (LoggedUser != null)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
    }

}