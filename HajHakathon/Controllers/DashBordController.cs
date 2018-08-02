using HajHakathon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HajHakathon.Controllers
{
    public class DashBordController : Controller
    {
        private LabickEntities db = new LabickEntities();
        public ActionResult GetZonMax()
        {

            var zone = db.Sys_Zone.ToList();
           

           


            return View(zone);
        }
    }
}