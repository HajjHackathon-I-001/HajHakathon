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
    public class CountariesController : BaseController
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

        // GET: Countaries
        public ActionResult Index()
        {
            return View(db.Sys_Countaries.ToList());
        }

        // GET: Countaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Countaries sys_Countaries = db.Sys_Countaries.Find(id);
            if (sys_Countaries == null)
            {
                return HttpNotFound();
            }
            return View(sys_Countaries);
        }

        // GET: Countaries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Countaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NameAr,NameEn,Code,IsActive,IsDeleted,CreatedDate,CreatedUserID,LastUpdatedDate,LastUpdatedUserID")] Sys_Countaries sys_Countaries)
        {
            if (ModelState.IsValid)
            {
                db.Sys_Countaries.Add(sys_Countaries);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sys_Countaries);
        }

        // GET: Countaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Countaries sys_Countaries = db.Sys_Countaries.Find(id);
            if (sys_Countaries == null)
            {
                return HttpNotFound();
            }
            return View(sys_Countaries);
        }

        // POST: Countaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NameAr,NameEn,Code,IsActive,IsDeleted,CreatedDate,CreatedUserID,LastUpdatedDate,LastUpdatedUserID")] Sys_Countaries sys_Countaries)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sys_Countaries).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sys_Countaries);
        }

        // GET: Countaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Countaries sys_Countaries = db.Sys_Countaries.Find(id);
            if (sys_Countaries == null)
            {
                return HttpNotFound();
            }
            return View(sys_Countaries);
        }

        // POST: Countaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sys_Countaries sys_Countaries = db.Sys_Countaries.Find(id);
            db.Sys_Countaries.Remove(sys_Countaries);
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
