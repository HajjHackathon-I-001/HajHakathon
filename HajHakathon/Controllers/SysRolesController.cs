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
    public class SysRolesController : BaseController
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

        // GET: SysRoles
        public ActionResult Index()
        {
            return View(db.Sys_Roles.ToList());
        }

        // GET: SysRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Roles sys_Roles = db.Sys_Roles.Find(id);
            if (sys_Roles == null)
            {
                return HttpNotFound();
            }
            return View(sys_Roles);
        }

        // GET: SysRoles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SysRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NameAr,NameEn,Code,IsActive,IsDeleted,CreatedDate,CreatedUserID,LastUpdatedDate,LastUpdatedUserID")] Sys_Roles sys_Roles)
        {
            if (ModelState.IsValid)
            {
                db.Sys_Roles.Add(sys_Roles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sys_Roles);
        }

        // GET: SysRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Roles sys_Roles = db.Sys_Roles.Find(id);
            if (sys_Roles == null)
            {
                return HttpNotFound();
            }
            return View(sys_Roles);
        }

        // POST: SysRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NameAr,NameEn,Code,IsActive,IsDeleted,CreatedDate,CreatedUserID,LastUpdatedDate,LastUpdatedUserID")] Sys_Roles sys_Roles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sys_Roles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sys_Roles);
        }

        // GET: SysRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Roles sys_Roles = db.Sys_Roles.Find(id);
            if (sys_Roles == null)
            {
                return HttpNotFound();
            }
            return View(sys_Roles);
        }

        // POST: SysRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sys_Roles sys_Roles = db.Sys_Roles.Find(id);
            db.Sys_Roles.Remove(sys_Roles);
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
