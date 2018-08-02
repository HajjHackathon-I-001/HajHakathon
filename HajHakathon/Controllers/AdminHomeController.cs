using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HajHakathon.Controllers
{
    public class AdminHomeController : BaseController
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (!IsloggedIn())
            {
                filterContext.Result = RedirectToAction("login", "LoginSystemAdmin", new { returnUrl = Request.Url.AbsoluteUri });
            }



            //any command need to run befor run Action 
            base.OnActionExecuting(filterContext);

        }
        // GET: AdminHome
        public ActionResult Index()
        {
            return View();
        }
    }
}