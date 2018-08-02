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
    public class CitiesController : BaseController
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

        // GET: Cities
        public ActionResult Index()
        {
            var sys_Cities = db.Sys_Cities.Include(s => s.Sys_Countaries);
            return View(sys_Cities.ToList());
        }

        // GET: Cities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Cities sys_Cities = db.Sys_Cities.Find(id);
            if (sys_Cities == null)
            {
                return HttpNotFound();
            }
            return View(sys_Cities);
        }

        // GET: Cities/Create
        public ActionResult Create()
        {
            ViewBag.CountrayID = new SelectList(db.Sys_Countaries, "ID", "NameAr");
            return View();
        }

        // POST: Cities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NameAr,NameEn,CountrayID,Code,IsActive,IsDeleted,CreatedDate,CreatedUserID,LastUpdatedDate,LastUpdatedUserID")] Sys_Cities sys_Cities)
        {
            if (ModelState.IsValid)
            {
                db.Sys_Cities.Add(sys_Cities);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountrayID = new SelectList(db.Sys_Countaries, "ID", "NameAr", sys_Cities.CountrayID);
            return View(sys_Cities);
        }

        // GET: Cities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Cities sys_Cities = db.Sys_Cities.Find(id);
            if (sys_Cities == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountrayID = new SelectList(db.Sys_Countaries, "ID", "NameAr", sys_Cities.CountrayID);
            return View(sys_Cities);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NameAr,NameEn,CountrayID,Code,IsActive,IsDeleted,CreatedDate,CreatedUserID,LastUpdatedDate,LastUpdatedUserID")] Sys_Cities sys_Cities)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sys_Cities).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountrayID = new SelectList(db.Sys_Countaries, "ID", "NameAr", sys_Cities.CountrayID);
            return View(sys_Cities);
        }

        // GET: Cities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Cities sys_Cities = db.Sys_Cities.Find(id);
            if (sys_Cities == null)
            {
                return HttpNotFound();
            }
            return View(sys_Cities);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sys_Cities sys_Cities = db.Sys_Cities.Find(id);
            db.Sys_Cities.Remove(sys_Cities);
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
