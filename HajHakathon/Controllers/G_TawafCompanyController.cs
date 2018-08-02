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
    public class G_TawafCompanyController : BaseController
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

        // GET: G_TawafCompany
        public ActionResult Index()
        {
            var g_TawafCompany = db.G_TawafCompany.Include(g => g.Sys_Cities).Include(g => g.Sys_Types);
            return View(g_TawafCompany.ToList());
        }

        // GET: G_TawafCompany/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_TawafCompany g_TawafCompany = db.G_TawafCompany.Find(id);
            if (g_TawafCompany == null)
            {
                return HttpNotFound();
            }
            return View(g_TawafCompany);
        }

        // GET: G_TawafCompany/Create
        public ActionResult Create()
        {
            ViewBag.CityID = new SelectList(db.Sys_Cities, "ID", "NameAr");
            ViewBag.TypeID = new SelectList(db.Sys_Types, "ID", "NameAr");
            return View();
        }

        // POST: G_TawafCompany/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NameAr,NameEn,Code,Email,Tel,Fax,TypeID,CityID,TasreehID,HamlaID,ComeFrom,ComeTo,IsActive,IsDeleted,CreatedDate,CreatedUserID,LastUpdatedDate,LastUpdatedUserID")] G_TawafCompany g_TawafCompany)
        {
            if (ModelState.IsValid)
            {
                db.G_TawafCompany.Add(g_TawafCompany);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityID = new SelectList(db.Sys_Cities, "ID", "NameAr", g_TawafCompany.CityID);
            ViewBag.TypeID = new SelectList(db.Sys_Types, "ID", "NameAr", g_TawafCompany.TypeID);
            return View(g_TawafCompany);
        }

        // GET: G_TawafCompany/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_TawafCompany g_TawafCompany = db.G_TawafCompany.Find(id);
            if (g_TawafCompany == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityID = new SelectList(db.Sys_Cities, "ID", "NameAr", g_TawafCompany.CityID);
            ViewBag.TypeID = new SelectList(db.Sys_Types, "ID", "NameAr", g_TawafCompany.TypeID);
            return View(g_TawafCompany);
        }

        // POST: G_TawafCompany/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NameAr,NameEn,Code,Email,Tel,Fax,TypeID,CityID,TasreehID,HamlaID,ComeFrom,ComeTo,IsActive,IsDeleted,CreatedDate,CreatedUserID,LastUpdatedDate,LastUpdatedUserID")] G_TawafCompany g_TawafCompany)
        {
            if (ModelState.IsValid)
            {
                db.Entry(g_TawafCompany).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityID = new SelectList(db.Sys_Cities, "ID", "NameAr", g_TawafCompany.CityID);
            ViewBag.TypeID = new SelectList(db.Sys_Types, "ID", "NameAr", g_TawafCompany.TypeID);
            return View(g_TawafCompany);
        }

        // GET: G_TawafCompany/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_TawafCompany g_TawafCompany = db.G_TawafCompany.Find(id);
            if (g_TawafCompany == null)
            {
                return HttpNotFound();
            }
            return View(g_TawafCompany);
        }

        // POST: G_TawafCompany/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            G_TawafCompany g_TawafCompany = db.G_TawafCompany.Find(id);
            db.G_TawafCompany.Remove(g_TawafCompany);
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
