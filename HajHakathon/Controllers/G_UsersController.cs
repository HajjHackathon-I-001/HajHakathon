using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HajHakathon.Models;

namespace HajHakathon.Controllers
{
    public class G_UsersController : BaseController
    {

	protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
            if(!IsloggedIn())
            {
                filterContext.Result = RedirectToAction("login", "LoginSystemAdmin", new { returnUrl = Request.Url.AbsoluteUri });
            }


          
			//any command need to run befor run Action 
            base.OnActionExecuting(filterContext);
			
        }

        private LabickEntities db = new LabickEntities();

        // GET: G_Users
        public ActionResult Index()
        {
            var g_Users = db.G_Users.Include(g => g.Sys_Countaries).Include(g => g.Sys_Languages);
            return View(g_Users.ToList());
        }

        // GET: G_Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_Users g_Users = db.G_Users.Find(id);
            if (g_Users == null)
            {
                return HttpNotFound();
            }
            return View(g_Users);
        }

        // GET: G_Users/Create
        public ActionResult Create()
        {
            ViewBag.CountaryID = new SelectList(db.Sys_Countaries, "ID", "NameAr");
            ViewBag.ID = new SelectList(db.Sys_Languages, "ID", "NameAr");
            return View();
        }

        // POST: G_Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NameAr,NameEn,PassportID,BirthDate,VisaNumber,BarcodeIQ,AirLinesCompanyID,TawafaCompanyID,Gender,Photo,TouchID,PassportSource,CountaryID,LanguageID,PortNumber,VisaIssuance,IsNedded,BlodGroup,MobileNumber,IdentityNumber,TasreeeNumber,Email,UserName,Password")] G_Users g_Users)
        {
            if (ModelState.IsValid)
            {
                db.G_Users.Add(g_Users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountaryID = new SelectList(db.Sys_Countaries, "ID", "NameAr", g_Users.CountaryID);
            ViewBag.ID = new SelectList(db.Sys_Languages, "ID", "NameAr", g_Users.ID);
            return View(g_Users);
        }

        // GET: G_Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_Users g_Users = db.G_Users.Find(id);
            if (g_Users == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountaryID = new SelectList(db.Sys_Countaries, "ID", "NameAr", g_Users.CountaryID);
            ViewBag.ID = new SelectList(db.Sys_Languages, "ID", "NameAr", g_Users.ID);
            return View(g_Users);
        }

        // POST: G_Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NameAr,NameEn,PassportID,BirthDate,VisaNumber,BarcodeIQ,AirLinesCompanyID,TawafaCompanyID,Gender,Photo,TouchID,PassportSource,CountaryID,LanguageID,PortNumber,VisaIssuance,IsNedded,BlodGroup,MobileNumber,IdentityNumber,TasreeeNumber,Email,UserName,Password")] G_Users g_Users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(g_Users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountaryID = new SelectList(db.Sys_Countaries, "ID", "NameAr", g_Users.CountaryID);
            ViewBag.ID = new SelectList(db.Sys_Languages, "ID", "NameAr", g_Users.ID);
            return View(g_Users);
        }

        // GET: G_Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_Users g_Users = db.G_Users.Find(id);
            if (g_Users == null)
            {
                return HttpNotFound();
            }
            return View(g_Users);
        }

        // POST: G_Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            G_Users g_Users = db.G_Users.Find(id);
            db.G_Users.Remove(g_Users);
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
