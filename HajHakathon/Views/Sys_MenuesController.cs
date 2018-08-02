using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HajHakathon.Models;
using HajHakathon.Controllers;

namespace HajHakathon.Views
{
    public class Sys_MenuesController : BaseController
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

        // GET: Sys_Menues
        public ActionResult Index()
        {
            return View(db.Sys_Menues.ToList());
        }

        // GET: Sys_Menues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Menues sys_Menues = db.Sys_Menues.Find(id);
            if (sys_Menues == null)
            {
                return HttpNotFound();
            }
            return View(sys_Menues);
        }

        // GET: Sys_Menues/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sys_Menues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NameAr,NameEn,Action,Controller,Area,Description,IsActive,Regdate,ReguserID,ParentID")] Sys_Menues sys_Menues)
        {
            if (ModelState.IsValid)
            {
                db.Sys_Menues.Add(sys_Menues);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sys_Menues);
        }

        // GET: Sys_Menues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Menues sys_Menues = db.Sys_Menues.Find(id);
            if (sys_Menues == null)
            {
                return HttpNotFound();
            }
            return View(sys_Menues);
        }

        // POST: Sys_Menues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NameAr,NameEn,Action,Controller,Area,Description,IsActive,Regdate,ReguserID,ParentID")] Sys_Menues sys_Menues)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sys_Menues).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sys_Menues);
        }

        // GET: Sys_Menues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Menues sys_Menues = db.Sys_Menues.Find(id);
            if (sys_Menues == null)
            {
                return HttpNotFound();
            }
            return View(sys_Menues);
        }

        // POST: Sys_Menues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sys_Menues sys_Menues = db.Sys_Menues.Find(id);
            db.Sys_Menues.Remove(sys_Menues);
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
