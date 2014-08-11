using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Shsict.InternalWeb.Models;

namespace Shsict.InternalWeb.Controllers
{
    public class VesselAmountController : Controller
    {
        [Authorize(Roles = "ZYL")]
        public ActionResult Index()
        {
            return RedirectToAction("Vessel");
        }

        [Authorize(Roles = "ZYL")]
        public ActionResult Vessel()
        {
            var _VesselAmounts = Cache.VesselAmountList.FindAll(t => t.VESSELTYPE.Equals("大船"));
            return View(_VesselAmounts.ToList());
        }

        [Authorize(Roles = "ZYL")]
        public ActionResult Barge()
        {
            var _VesselAmounts = Cache.VesselAmountList.FindAll(t => t.VESSELTYPE.Equals("驳船"));
            return View(_VesselAmounts.ToList());
        }

        public static class Cache
        {
            static Cache()
            {
                InitCache();
            }

            public static void RefreshCache()
            {
                InitCache();
            }

            private static void InitCache()
            {

                VesselAmountList = VesselAmount.GetVesselAmounts();

            }

            public static List<VesselAmount> VesselAmountList;

        }
    }
}
