using HajHakathon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Web.Optimization;

namespace HajHakathon.App_Helpers
{
    public class OpenMaintnanceTicket
    {
        
        //public static string openMaint()
        //{
        //    MedDeviceDBEntities db = new MedDeviceDBEntities();
        //    string welcom = "welcom";

        //    //DeviceMaintenanceTBL companydevMaint = new DeviceMaintenanceTBL();
        //    //var comdev = db.CompanyMedDevicesTBL.ToList();
        //    //string maxreqnumber;
        //    //var Maintitem = db.MaintenanceItemTBL.Where(a => a.MaintenanceItemName == "صيانة دورية - Periodic maintenance").SingleOrDefault();
        //    //Guid? Maintitemid = Maintitem.MaintenanceItemID;
        //    //DateTime? nowdate = DateTime.Now;
        //    //foreach (var item in comdev)
        //    //{
        //    //    Guid? devid = item.DeviceID;
        //    //    var maintdevtbl = db.DeviceMaintenanceTBL.Where(a => a.DeviceID == devid && a.MaintenanceItemID == Maintitemid).ToList();

        //    //    if (maintdevtbl == null || maintdevtbl.Count()==0)
        //    //    {

        //    //        DateTime checkWenOpenDate = new DateTime();
        //    //        checkWenOpenDate = item.FirstPeriodicMaintenanceDate.Value;
        //    //        checkWenOpenDate = checkWenOpenDate.AddDays(Convert.ToInt32(item.PeriodicMaintenanceAfterDays));

        //    //        if (checkWenOpenDate >= DateTime.Now)
        //    //        {
        //    //            var maxreqnumberchecker = db.DeviceMaintenanceTBL.OrderByDescending(a => a.MaintenanceRequestNumber).FirstOrDefault();

        //    //            if (maxreqnumberchecker == null)
        //    //            {

        //    //                maxreqnumber = Convert.ToString(Convert.ToString(DateTime.Now.Year) + Convert.ToString(DateTime.Now.Month) + "000001");
        //    //            }
        //    //            else
        //    //            {
        //    //                maxreqnumber = Convert.ToString(Convert.ToDouble(maxreqnumberchecker.MaintenanceRequestNumber) + 1);
        //    //            }

        //    //            companydevMaint.DeviceID = item.DeviceID;
        //    //            companydevMaint.MaintenanceID = Guid.NewGuid();
        //    //            companydevMaint.MaintenanceRequestNumber = Convert.ToDouble(maxreqnumber);
        //    //            companydevMaint.RequestMaintenanceBy = "System - النظام";
        //    //            companydevMaint.MaintenanceItemID = Maintitemid.Value;
        //    //            companydevMaint.MaintenanceRequestDate = DateTime.Now;
        //    //            db.DeviceMaintenanceTBL.Add(companydevMaint);
        //    //            db.SaveChanges();
        //    //            var DevmaintResultReq = db.DeviceRequairmentMaintenanceTBL.Where(a => a.DeviceID == devid).ToList();
        //    //            DeviceMaintenanceResualtTBL devresult = new DeviceMaintenanceResualtTBL();
        //    //            if (DevmaintResultReq != null)
        //    //            {
        //    //                foreach (var itemres in DevmaintResultReq)
        //    //                {
        //    //                    devresult.DeviceMaintenanceResualtID = Guid.NewGuid();
        //    //                    devresult.MaintenanceID = companydevMaint.MaintenanceID;
        //    //                    devresult.DeviceRequairmentMaintenanceID = itemres.DeviceRequairmentMaintenanceID;
        //    //                    db.DeviceMaintenanceResualtTBL.Add(devresult);
        //    //                    db.SaveChanges();
        //    //                }

        //    //            }
        //    //        }
        //    //    }


        //    //    else
        //    //    {
        //    //        var checklastMaintDev = db.DeviceMaintenanceTBL.Where(a => a.DeviceID == item.DeviceID).OrderByDescending(a => a.MaintenanceRequestDate).FirstOrDefault();
        //    //        DateTime dd = new DateTime();
        //    //        if (checklastMaintDev != null)
        //    //        {
        //    //            dd = checklastMaintDev.MaintenanceRequestDate;
        //    //            dd.AddDays(Convert.ToInt32(item.PeriodicMaintenanceAfterDays));


        //    //            if (dd >= DateTime.Now)
        //    //            {
        //    //                var maxreqnumberchecker = db.DeviceMaintenanceTBL.OrderByDescending(a => a.MaintenanceRequestNumber).FirstOrDefault();

        //    //                if (maxreqnumberchecker == null)
        //    //                {

        //    //                    maxreqnumber = Convert.ToString(Convert.ToString(DateTime.Now.Year) + Convert.ToString(DateTime.Now.Month) + "000001");
        //    //                }
        //    //                else
        //    //                {
        //    //                    maxreqnumber = Convert.ToString(Convert.ToDouble(maxreqnumberchecker.MaintenanceRequestNumber) + 1);
        //    //                }

        //    //                companydevMaint.DeviceID = item.DeviceID;
        //    //                companydevMaint.MaintenanceID = Guid.NewGuid();
        //    //                companydevMaint.MaintenanceRequestNumber = Convert.ToDouble(maxreqnumber);
        //    //                companydevMaint.RequestMaintenanceBy = "System - النظام";
        //    //                companydevMaint.MaintenanceItemID = Maintitemid.Value;
        //    //                companydevMaint.MaintenanceRequestDate = DateTime.Now;
        //    //                //companydevMaint.MaintenanceEndRequestDate = null;
        //    //                //companydevMaint.EmpDoMaintenance = null;
        //    //                //companydevMaint.EndMaintenanceResualt = null;
        //    //                //companydevMaint.NeedMaintenanceFromPPM = false;
        //    //                db.DeviceMaintenanceTBL.Add(companydevMaint);
        //    //                db.SaveChanges();

        //    //            }
        //    //        }

        //    //    }
        //    //}

        //    DeviceMaintenanceTBL companydevMaint = new DeviceMaintenanceTBL();
        //    var compdev = db.CompanyMedDevicesTBL.Include(a=>a.DeviceMaintenanceTBL).ToList();
        //    DateTime nextopendate = new DateTime();
        //    int? dayAftertoOpen = 0;
        //    string maxreqnumber;
        //    var Maintitem = db.MaintenanceItemTBL.Where(a => a.MaintenanceItemName == "صيانة دورية - Periodic maintenance").SingleOrDefault();
        //    Guid Maintitemid = Maintitem.MaintenanceItemID;
        //    foreach (var item in compdev.Where(d=>d.DeviceMaintenanceTBL.Count == 0))
        //    {
        //        nextopendate = item.FirstPeriodicMaintenanceDate.Value;
        //        dayAftertoOpen = item.PeriodicMaintenanceAfterDays;
        //        nextopendate.AddDays(dayAftertoOpen.Value);
        //        if(DateTime.Now >= nextopendate)
        //        {
        //            var maxreqnumberchecker = db.DeviceMaintenanceTBL.OrderByDescending(a => a.MaintenanceRequestNumber).FirstOrDefault();

        //            if (maxreqnumberchecker == null)
        //            {

        //                maxreqnumber = Convert.ToString(Convert.ToString(DateTime.Now.Year) + Convert.ToString(DateTime.Now.Month) + "000001");
        //            }
        //            else
        //            {
        //                maxreqnumber = Convert.ToString(Convert.ToDouble(maxreqnumberchecker.MaintenanceRequestNumber) + 1);
        //            }

        //            companydevMaint.DeviceID = item.DeviceID;
        //            companydevMaint.MaintenanceID = Guid.NewGuid();
        //            companydevMaint.MaintenanceRequestNumber = Convert.ToDouble(maxreqnumber);
        //            companydevMaint.RequestMaintenanceBy = "System - النظام";
        //            companydevMaint.MaintenanceItemID = Maintitemid;
        //            companydevMaint.MaintenanceRequestDate = DateTime.Now;
        //            db.DeviceMaintenanceTBL.Add(companydevMaint);
        //            db.SaveChanges();
        //            var DevmaintResultReq = db.DeviceRequairmentMaintenanceTBL.Where(a => a.DeviceID == item.DeviceID).ToList();
        //            DeviceMaintenanceResualtTBL devresult = new DeviceMaintenanceResualtTBL();
        //            if (DevmaintResultReq != null)
        //            {
        //                foreach (var itemres in DevmaintResultReq)
        //                {
        //                    devresult.DeviceMaintenanceResualtID = Guid.NewGuid();
        //                    devresult.MaintenanceID = companydevMaint.MaintenanceID;
        //                    devresult.DeviceRequairmentMaintenanceID = itemres.DeviceRequairmentMaintenanceID;
        //                    db.DeviceMaintenanceResualtTBL.Add(devresult);
        //                    db.SaveChanges();
        //                }

        //            }
        //        }

        //    }
        //    //-----------------------------اذا كان جدول البلاغات غير فارغ ---------------------
        //    //foreach (var item in compdev.Where(d => d.DeviceMaintenanceTBL.Where(s=>s.MaintenanceItemID.Equals(Maintitemid)).ToList()))
        //    //{
        //    //    nextopendate = item.FirstPeriodicMaintenanceDate.Value;
        //    //    dayAftertoOpen = item.PeriodicMaintenanceAfterDays;
        //    //    nextopendate.AddDays(dayAftertoOpen.Value);
        //    //    if (nextopendate >= DateTime.Now)
        //    //    {
        //    //        var maxreqnumberchecker = db.DeviceMaintenanceTBL.OrderByDescending(a => a.MaintenanceRequestNumber).FirstOrDefault();

        //    //        if (maxreqnumberchecker == null)
        //    //        {

        //    //            maxreqnumber = Convert.ToString(Convert.ToString(DateTime.Now.Year) + Convert.ToString(DateTime.Now.Month) + "000001");
        //    //        }
        //    //        else
        //    //        {
        //    //            maxreqnumber = Convert.ToString(Convert.ToDouble(maxreqnumberchecker.MaintenanceRequestNumber) + 1);
        //    //        }

        //    //        companydevMaint.DeviceID = item.DeviceID;
        //    //        companydevMaint.MaintenanceID = Guid.NewGuid();
        //    //        companydevMaint.MaintenanceRequestNumber = Convert.ToDouble(maxreqnumber);
        //    //        companydevMaint.RequestMaintenanceBy = "System - النظام";
        //    //        companydevMaint.MaintenanceItemID = Maintitemid.Value;
        //    //        companydevMaint.MaintenanceRequestDate = DateTime.Now;
        //    //        db.DeviceMaintenanceTBL.Add(companydevMaint);
        //    //        db.SaveChanges();
        //    //        var DevmaintResultReq = db.DeviceRequairmentMaintenanceTBL.Where(a => a.DeviceID == item.DeviceID).ToList();
        //    //        DeviceMaintenanceResualtTBL devresult = new DeviceMaintenanceResualtTBL();
        //    //        if (DevmaintResultReq != null)
        //    //        {
        //    //            foreach (var itemres in DevmaintResultReq)
        //    //            {
        //    //                devresult.DeviceMaintenanceResualtID = Guid.NewGuid();
        //    //                devresult.MaintenanceID = companydevMaint.MaintenanceID;
        //    //                devresult.DeviceRequairmentMaintenanceID = itemres.DeviceRequairmentMaintenanceID;
        //    //                db.DeviceMaintenanceResualtTBL.Add(devresult);
        //    //                db.SaveChanges();
        //    //            }

        //    //        }
        //    //    }

        //    //}
        //    return welcom;
        //}
    }
}