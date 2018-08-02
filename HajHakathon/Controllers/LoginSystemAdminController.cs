using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HajHakathon.App_Helpers;
using HajHakathon.Models; 
using HajHakathon.ViewModel;

namespace HajHakathon.Controllers
{
    public class LoginSystemAdminController : Controller
    {
        private LabickEntities db = new LabickEntities();
        public ActionResult Login(String returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            ViewBag.Messges = null;
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginUsers loginUsers)
        {

            string decryptpassword = PasswordHelper.EncodePasswordMd5(loginUsers.Password);
            if (ModelState.IsValid)

            {


                var usersTBLs = db.Sys_Users.Where(u => (u.UsrName == loginUsers.UserName && u.Password == decryptpassword)).SingleOrDefault();
                if (usersTBLs != null)
                {
                    Session["LoggedInUser"] = usersTBLs;
                    if (loginUsers.ReturnUrl != null)
                    {
                        
                        return Redirect(loginUsers.ReturnUrl);
                    }
                    else
                    {
                        
                        return RedirectToAction("Index", "AdminHome");

                    }


                }

                else
                {

                    ViewBag.Messges = "خطا في اسم المستخدم او كلمة المرور";
                    return View();
                }
            }

            else
            {
                ViewBag.Messges = "شروط الادخال غير متحققة";
                return View();
            }

        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult SetSession()
        {
            Session["Test"] = "Test Value";
            return View();
        }

        public ActionResult Keepalive()
        {
            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        public ActionResult AjaxClick()
        {
            return Json("OK", JsonRequestBehavior.AllowGet);
        }
        
    }
}