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
    public class SysAreaController : BaseController
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

        // GET: SysArea
        public ActionResult Index()
        {
            var sys_Area = db.Sys_Area.Include(s => s.Sys_Cities);
            return View(sys_Area.ToList());
        }

        // GET: SysArea/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Area sys_Area = db.Sys_Area.Find(id);
            if (sys_Area == null)
            {
                return HttpNotFound();
            }
            return View(sys_Area);
        }

        // GET: SysArea/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Sys_Cities, "ID", "NameAr");
            return View();
        }

        // POST: SysArea/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CityId,AreaNameAr,AreaNameEn,MaxInArea")] Sys_Area sys_Area)
        {
            if (ModelState.IsValid)
            {
                db.Sys_Area.Add(sys_Area);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Sys_Cities, "ID", "NameAr", sys_Area.CityId);
            return View(sys_Area);
        }

        // GET: SysArea/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Area sys_Area = db.Sys_Area.Find(id);
            if (sys_Area == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Sys_Cities, "ID", "NameAr", sys_Area.CityId);
            return View(sys_Area);
        }

        // POST: SysArea/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CityId,AreaNameAr,AreaNameEn,MaxInArea")] Sys_Area sys_Area)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sys_Area).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Sys_Cities, "ID", "NameAr", sys_Area.CityId);
            return View(sys_Area);
        }

        // GET: SysArea/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Area sys_Area = db.Sys_Area.Find(id);
            if (sys_Area == null)
            {
                return HttpNotFound();
            }
            return View(sys_Area);
        }

        // POST: SysArea/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sys_Area sys_Area = db.Sys_Area.Find(id);
            db.Sys_Area.Remove(sys_Area);
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
