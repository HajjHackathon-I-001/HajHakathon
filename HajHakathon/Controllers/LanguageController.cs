using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace HajHakathon.Controllers
{
    public class LanguageController : Controller
    {
        // GET: Language
        public ActionResult Change(String LanguageAbbrevation , String flagval,String returnUrl)
        {
            if(LanguageAbbrevation !=null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(LanguageAbbrevation);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(LanguageAbbrevation);
                

            }
            HttpCookie cookie = new HttpCookie("Language");
            cookie.Value = LanguageAbbrevation;
            Response.Cookies.Add(cookie);
            HttpCookie cookieflag = new HttpCookie("langflag");
            cookieflag.Value = flagval;
            Response.Cookies.Add(cookieflag);
            return Redirect(returnUrl);
        }
    }
}