using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Shsict.InternalWeb.Models;

namespace Shsict.InternalWeb.Controllers
{
    public class PadVesselAmountController : Controller
    {
        [Authorize(Roles = "ZYL")]
        public ActionResult Index()
        {
            return RedirectToAction("Vessel");
        }

        [Authorize(Roles = "ZYL")]
        public ActionResult Vessel()
        {
            var _VesselAmounts = VesselAmountController.Cache.VesselAmountList.FindAll(t => t.VESSELTYPE.Equals("大船"));
            return View(_VesselAmounts.ToList());
        }

        [Authorize(Roles = "ZYL")]
        public ActionResult Barge()
        {
            var _VesselAmounts = VesselAmountController.Cache.VesselAmountList.FindAll(t => t.VESSELTYPE.Equals("驳船"));
            return View(_VesselAmounts.ToList());
        }
     
    }
}
