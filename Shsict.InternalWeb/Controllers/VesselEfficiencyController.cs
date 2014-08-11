using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.OracleClient;

using Shsict.InternalWeb.Models;

namespace Shsict.InternalWeb.Controllers
{
    public class VesselEfficiencyController : Controller
    {
            [Authorize(Roles = "SC")]
        public ActionResult Index(string id)
        {
            if (id == null)
            {
                id = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");

            }

            var _VesselEfficiency = Cache.VesselEfficiencyList.FindAll(t => t.REPORT_DATE.Equals(DateTime.Parse(id)));

            string noData = "暂无数据";

            if (_VesselEfficiency.Count == 0)
            {
                VesselEfficiency vesselEfficiency = new VesselEfficiency();

                vesselEfficiency.VSL_CNNAME = noData;
                vesselEfficiency.REPORT_DATE = DateTime.Parse(id);
                vesselEfficiency.MyDate = id;

                _VesselEfficiency.Add(vesselEfficiency);
            }

            return View(_VesselEfficiency.ToList());
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

                VesselEfficiencyList = VesselEfficiency.GetVesselEfficiencys();

            }

            public static List<VesselEfficiency> VesselEfficiencyList;

        }

    }
}
