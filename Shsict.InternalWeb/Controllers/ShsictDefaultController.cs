using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shsict.InternalWeb.Controllers
{
    public class ShsictDefaultController : Controller
    {
        //
        // GET: /ShsictDefault/

        public ActionResult Index()
        {
            if (Request.QueryString["Type"] != "admin")
            {
                return RedirectToAction("", "Portal");
            }

            return View();
        }

        public void HandRefresh(string id)
        {
            string responseText = string.Empty;

            try
            {
                switch (id)
                {
                    case "DailyReport":
                        DailyReportController.Cache.RefreshCache();
                        break;
                    case "ThreeShift":
                        ThreeShiftController.Cache.RefreshCache();
                        break;
                    case "VesselEfficiency":
                        VesselEfficiencyController.Cache.RefreshCache();
                        break;
                    case "OperatePlan":
                        OperatePlanController.Cache.RefreshCache();
                        break;
                    case "YardDensity":
                        YardDensityController.Cache.RefreshCache();
                        break;
                    case "TwinLift":
                        TwinLiftController.Cache.RefreshCache();
                        break;
                    case "VesselBerth":
                        VesselBerthController.Cache.RefreshCache();
                        break;
                    case "VesselAmount":
                        VesselAmountController.Cache.RefreshCache();
                        break;
                    case "TruckOperationCycle":
                        TruckOperationCycleController.Cache.RefreshCache();
                        break;
                    case "MechanicalError":
                        MechanicalErrorController.Cache.RefreshCache();
                        break;

                    default:
                        responseText = string.Empty;
                        break;
                }

                Response.Write("success");
            }
            catch (Exception ex)
            {
                Response.Write("Exception:" + ex.Message);
            }
        }



    }
}
