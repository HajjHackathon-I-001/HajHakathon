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
    public class SysChekPointsController : BaseController
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

        // GET: SysChekPoints
        public ActionResult Index()
        {
            var sys_ChekPoints = db.Sys_ChekPoints.Include(s => s.Devices).Include(s => s.Sys_Area);
            return View(sys_ChekPoints.ToList());
        }

        // GET: SysChekPoints/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_ChekPoints sys_ChekPoints = db.Sys_ChekPoints.Find(id);
            if (sys_ChekPoints == null)
            {
                return HttpNotFound();
            }
            return View(sys_ChekPoints);
        }

        // GET: SysChekPoints/Create
        public ActionResult Create()
        {
            ViewBag.RFIDDeviceID = new SelectList(db.Devices, "DeviceId", "DeviceName");
            ViewBag.AreaID = new SelectList(db.Sys_Area, "ID", "AreaNameAr");
            return View();
        }

        // POST: SysChekPoints/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AreaID,RFIDDeviceID,chekpointNameAr,chekpointNameEn")] Sys_ChekPoints sys_ChekPoints)
        {
            if (ModelState.IsValid)
            {
                db.Sys_ChekPoints.Add(sys_ChekPoints);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RFIDDeviceID = new SelectList(db.Devices, "DeviceId", "DeviceName", sys_ChekPoints.RFIDDeviceID);
            ViewBag.AreaID = new SelectList(db.Sys_Area, "ID", "AreaNameAr", sys_ChekPoints.AreaID);
            return View(sys_ChekPoints);
        }

        // GET: SysChekPoints/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_ChekPoints sys_ChekPoints = db.Sys_ChekPoints.Find(id);
            if (sys_ChekPoints == null)
            {
                return HttpNotFound();
            }
            ViewBag.RFIDDeviceID = new SelectList(db.Devices, "DeviceId", "DeviceName", sys_ChekPoints.RFIDDeviceID);
            ViewBag.AreaID = new SelectList(db.Sys_Area, "ID", "AreaNameAr", sys_ChekPoints.AreaID);
            return View(sys_ChekPoints);
        }

        // POST: SysChekPoints/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AreaID,RFIDDeviceID,chekpointNameAr,chekpointNameEn")] Sys_ChekPoints sys_ChekPoints)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sys_ChekPoints).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RFIDDeviceID = new SelectList(db.Devices, "DeviceId", "DeviceName", sys_ChekPoints.RFIDDeviceID);
            ViewBag.AreaID = new SelectList(db.Sys_Area, "ID", "AreaNameAr", sys_ChekPoints.AreaID);
            return View(sys_ChekPoints);
        }

        // GET: SysChekPoints/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_ChekPoints sys_ChekPoints = db.Sys_ChekPoints.Find(id);
            if (sys_ChekPoints == null)
            {
                return HttpNotFound();
            }
            return View(sys_ChekPoints);
        }

        // POST: SysChekPoints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sys_ChekPoints sys_ChekPoints = db.Sys_ChekPoints.Find(id);
            db.Sys_ChekPoints.Remove(sys_ChekPoints);
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
