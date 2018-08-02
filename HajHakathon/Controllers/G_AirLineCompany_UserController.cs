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
    public class G_AirLineCompany_UserController : BaseController
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

        // GET: G_AirLineCompany_User
        public ActionResult Index()
        {
            var g_AirLineCompany_User = db.G_AirLineCompany_User.Include(g => g.G_AirLineCompany).Include(g => g.G_Users);
            return View(g_AirLineCompany_User.ToList());
        }

        // GET: G_AirLineCompany_User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_AirLineCompany_User g_AirLineCompany_User = db.G_AirLineCompany_User.Find(id);
            if (g_AirLineCompany_User == null)
            {
                return HttpNotFound();
            }
            return View(g_AirLineCompany_User);
        }

        // GET: G_AirLineCompany_User/Create
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.G_AirLineCompany, "ID", "NameAr");
            ViewBag.G_UserID = new SelectList(db.G_Users, "ID", "NameAr");
            return View();
        }

        // POST: G_AirLineCompany_User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CompanyID,G_UserID,TravelID,ComeFrom,ComeTo,IsActive,IsDeleted,CreatedDate,CreatedUserID,LastUpdatedDate,LastUpdatedUserID")] G_AirLineCompany_User g_AirLineCompany_User)
        {
            if (ModelState.IsValid)
            {
                db.G_AirLineCompany_User.Add(g_AirLineCompany_User);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(db.G_AirLineCompany, "ID", "NameAr", g_AirLineCompany_User.CompanyID);
            ViewBag.G_UserID = new SelectList(db.G_Users, "ID", "NameAr", g_AirLineCompany_User.G_UserID);
            return View(g_AirLineCompany_User);
        }

        // GET: G_AirLineCompany_User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_AirLineCompany_User g_AirLineCompany_User = db.G_AirLineCompany_User.Find(id);
            if (g_AirLineCompany_User == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.G_AirLineCompany, "ID", "NameAr", g_AirLineCompany_User.CompanyID);
            ViewBag.G_UserID = new SelectList(db.G_Users, "ID", "NameAr", g_AirLineCompany_User.G_UserID);
            return View(g_AirLineCompany_User);
        }

        // POST: G_AirLineCompany_User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CompanyID,G_UserID,TravelID,ComeFrom,ComeTo,IsActive,IsDeleted,CreatedDate,CreatedUserID,LastUpdatedDate,LastUpdatedUserID")] G_AirLineCompany_User g_AirLineCompany_User)
        {
            if (ModelState.IsValid)
            {
                db.Entry(g_AirLineCompany_User).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.G_AirLineCompany, "ID", "NameAr", g_AirLineCompany_User.CompanyID);
            ViewBag.G_UserID = new SelectList(db.G_Users, "ID", "NameAr", g_AirLineCompany_User.G_UserID);
            return View(g_AirLineCompany_User);
        }

        // GET: G_AirLineCompany_User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_AirLineCompany_User g_AirLineCompany_User = db.G_AirLineCompany_User.Find(id);
            if (g_AirLineCompany_User == null)
            {
                return HttpNotFound();
            }
            return View(g_AirLineCompany_User);
        }

        // POST: G_AirLineCompany_User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            G_AirLineCompany_User g_AirLineCompany_User = db.G_AirLineCompany_User.Find(id);
            db.G_AirLineCompany_User.Remove(g_AirLineCompany_User);
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
