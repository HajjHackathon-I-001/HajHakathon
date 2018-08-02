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
    public class TypesController : BaseController
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

        // GET: Types
        public ActionResult Index()
        {
            return View(db.Sys_Types.ToList());
        }

        // GET: Types/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Types sys_Types = db.Sys_Types.Find(id);
            if (sys_Types == null)
            {
                return HttpNotFound();
            }
            return View(sys_Types);
        }

        // GET: Types/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Types/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NameAr,NameEn,Code,IsActive,IsDeleted,CreatedDate,CreatedUserID,LastUpdatedDate,LastUpdatedUserID")] Sys_Types sys_Types)
        {
            if (ModelState.IsValid)
            {
                db.Sys_Types.Add(sys_Types);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sys_Types);
        }

        // GET: Types/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Types sys_Types = db.Sys_Types.Find(id);
            if (sys_Types == null)
            {
                return HttpNotFound();
            }
            return View(sys_Types);
        }

        // POST: Types/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NameAr,NameEn,Code,IsActive,IsDeleted,CreatedDate,CreatedUserID,LastUpdatedDate,LastUpdatedUserID")] Sys_Types sys_Types)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sys_Types).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sys_Types);
        }

        // GET: Types/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Types sys_Types = db.Sys_Types.Find(id);
            if (sys_Types == null)
            {
                return HttpNotFound();
            }
            return View(sys_Types);
        }

        // POST: Types/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sys_Types sys_Types = db.Sys_Types.Find(id);
            db.Sys_Types.Remove(sys_Types);
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
