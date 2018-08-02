using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HajHakathon.Models;
namespace HajHakathon.Controllers
{
  
   
    public class HomeController : BaseController
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

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}