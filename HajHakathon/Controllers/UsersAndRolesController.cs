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
    public class UsersAndRolesController : BaseController
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

        // GET: UsersAndRoles
        public ActionResult Index()
        {
            var sys_UsersAndRoles = db.Sys_UsersAndRoles.Include(s => s.Sys_Menues).Include(s => s.Sys_Roles);
            return View(sys_UsersAndRoles.ToList());
        }

        // GET: UsersAndRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_UsersAndRoles sys_UsersAndRoles = db.Sys_UsersAndRoles.Find(id);
            if (sys_UsersAndRoles == null)
            {
                return HttpNotFound();
            }
            return View(sys_UsersAndRoles);
        }

        // GET: UsersAndRoles/Create
        public ActionResult Create()
        {
            ViewBag.RoleID = new SelectList(db.Sys_Menues, "ID", "NameAr");
            ViewBag.RoleID = new SelectList(db.Sys_Roles, "ID", "NameAr");
            return View();
        }

        // POST: UsersAndRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RoleID,MenueID,Description,IsActive,Regdate,CreatedDate,CreatedUserID,LastUpdatedDate,LastUpdateUserID")] Sys_UsersAndRoles sys_UsersAndRoles)
        {
            if (ModelState.IsValid)
            {
                db.Sys_UsersAndRoles.Add(sys_UsersAndRoles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleID = new SelectList(db.Sys_Menues, "ID", "NameAr", sys_UsersAndRoles.RoleID);
            ViewBag.RoleID = new SelectList(db.Sys_Roles, "ID", "NameAr", sys_UsersAndRoles.RoleID);
            return View(sys_UsersAndRoles);
        }

        // GET: UsersAndRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_UsersAndRoles sys_UsersAndRoles = db.Sys_UsersAndRoles.Find(id);
            if (sys_UsersAndRoles == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleID = new SelectList(db.Sys_Menues, "ID", "NameAr", sys_UsersAndRoles.RoleID);
            ViewBag.RoleID = new SelectList(db.Sys_Roles, "ID", "NameAr", sys_UsersAndRoles.RoleID);
            return View(sys_UsersAndRoles);
        }

        // POST: UsersAndRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RoleID,MenueID,Description,IsActive,Regdate,CreatedDate,CreatedUserID,LastUpdatedDate,LastUpdateUserID")] Sys_UsersAndRoles sys_UsersAndRoles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sys_UsersAndRoles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleID = new SelectList(db.Sys_Menues, "ID", "NameAr", sys_UsersAndRoles.RoleID);
            ViewBag.RoleID = new SelectList(db.Sys_Roles, "ID", "NameAr", sys_UsersAndRoles.RoleID);
            return View(sys_UsersAndRoles);
        }

        // GET: UsersAndRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_UsersAndRoles sys_UsersAndRoles = db.Sys_UsersAndRoles.Find(id);
            if (sys_UsersAndRoles == null)
            {
                return HttpNotFound();
            }
            return View(sys_UsersAndRoles);
        }

        // POST: UsersAndRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sys_UsersAndRoles sys_UsersAndRoles = db.Sys_UsersAndRoles.Find(id);
            db.Sys_UsersAndRoles.Remove(sys_UsersAndRoles);
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
