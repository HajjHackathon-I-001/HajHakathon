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
    public class G_AirLineCompanyController : BaseController
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

        // GET: G_AirLineCompany
        public ActionResult Index()
        {
            var g_AirLineCompany = db.G_AirLineCompany.Include(g => g.Sys_Types);
            return View(g_AirLineCompany.ToList());
        }

        // GET: G_AirLineCompany/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_AirLineCompany g_AirLineCompany = db.G_AirLineCompany.Find(id);
            if (g_AirLineCompany == null)
            {
                return HttpNotFound();
            }
            return View(g_AirLineCompany);
        }

        // GET: G_AirLineCompany/Create
        public ActionResult Create()
        {
            ViewBag.TypeID = new SelectList(db.Sys_Types, "ID", "NameAr");
            return View();
        }

        // POST: G_AirLineCompany/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NameAr,NameEn,Code,Email,Tel,Fax,TypeID,TravelID,ComeFrom,ComeTo,IsActive,IsDeleted,CreatedDate,CreatedUserID,LastUpdatedDate,LastUpdatedUserID")] G_AirLineCompany g_AirLineCompany)
        {
            if (ModelState.IsValid)
            {
                db.G_AirLineCompany.Add(g_AirLineCompany);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TypeID = new SelectList(db.Sys_Types, "ID", "NameAr", g_AirLineCompany.TypeID);
            return View(g_AirLineCompany);
        }

        // GET: G_AirLineCompany/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_AirLineCompany g_AirLineCompany = db.G_AirLineCompany.Find(id);
            if (g_AirLineCompany == null)
            {
                return HttpNotFound();
            }
            ViewBag.TypeID = new SelectList(db.Sys_Types, "ID", "NameAr", g_AirLineCompany.TypeID);
            return View(g_AirLineCompany);
        }

        // POST: G_AirLineCompany/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NameAr,NameEn,Code,Email,Tel,Fax,TypeID,TravelID,ComeFrom,ComeTo,IsActive,IsDeleted,CreatedDate,CreatedUserID,LastUpdatedDate,LastUpdatedUserID")] G_AirLineCompany g_AirLineCompany)
        {
            if (ModelState.IsValid)
            {
                db.Entry(g_AirLineCompany).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TypeID = new SelectList(db.Sys_Types, "ID", "NameAr", g_AirLineCompany.TypeID);
            return View(g_AirLineCompany);
        }

        // GET: G_AirLineCompany/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            G_AirLineCompany g_AirLineCompany = db.G_AirLineCompany.Find(id);
            if (g_AirLineCompany == null)
            {
                return HttpNotFound();
            }
            return View(g_AirLineCompany);
        }

        // POST: G_AirLineCompany/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            G_AirLineCompany g_AirLineCompany = db.G_AirLineCompany.Find(id);
            db.G_AirLineCompany.Remove(g_AirLineCompany);
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
