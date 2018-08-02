using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HajHakathon.Models;
using HajHakathon.App_Helpers;

namespace HajHakathon.Controllers
{
    public class SysUsersController : BaseController
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

        private LabickEntities db = new LabickEntities();

        // GET: SysUsers
        public ActionResult Index()
        {
            return View(db.Sys_Users.ToList());
        }

        // GET: SysUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Users sys_Users = db.Sys_Users.Find(id);
            if (sys_Users == null)
            {
                return HttpNotFound();
            }
            return View(sys_Users);
        }

        // GET: SysUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SysUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NameAr,NameEn,BirthDate,Gender,CountaryID,MobileNumber,IdentityNumber,Email,Passport,IsActive,IsDeleted,CreatedDate,CreatedUserID,LastUpdatedDate,LastUpdatedUserID,UsrName,Password")] Sys_Users sys_Users)
        {
            string decryptpassword = PasswordHelper.EncodePasswordMd5(sys_Users.Password);
            if (ModelState.IsValid)
            {
                sys_Users.Password = decryptpassword;
                db.Sys_Users.Add(sys_Users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sys_Users);
        }

        // GET: SysUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Users sys_Users = db.Sys_Users.Find(id);
            if (sys_Users == null)
            {
                return HttpNotFound();
            }
            return View(sys_Users);
        }

        // POST: SysUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NameAr,NameEn,BirthDate,Gender,CountaryID,MobileNumber,IdentityNumber,Email,Passport,IsActive,IsDeleted,CreatedDate,CreatedUserID,LastUpdatedDate,LastUpdatedUserID,UsrName,Password")] Sys_Users sys_Users)
        {
            string decryptpassword = PasswordHelper.EncodePasswordMd5(sys_Users.Password);
            if (ModelState.IsValid)
            {
                sys_Users.Password = decryptpassword;
                db.Entry(sys_Users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sys_Users);
        }

        // GET: SysUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Users sys_Users = db.Sys_Users.Find(id);
            if (sys_Users == null)
            {
                return HttpNotFound();
            }
            return View(sys_Users);
        }

        // POST: SysUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sys_Users sys_Users = db.Sys_Users.Find(id);
            db.Sys_Users.Remove(sys_Users);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
