using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.OracleClient;

using Shsict.InternalWeb.Models;

namespace Shsict.InternalWeb.Controllers
{
    public class VesselBerthController : Controller
    {
        [Authorize(Roles = "SC")]
        public ActionResult Index()
        {
            return RedirectToAction("Berth");
        }

        [Authorize(Roles = "SC")]
        public ActionResult Berth(string id)
        {
            if (string.IsNullOrEmpty(id))
                id = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");

            var _VesselBerth = Cache.VesselBerthList.FindAll(t => t.REPORT_DATE.Equals(DateTime.Parse(id)));

            string noData = "暂无数据";

            if (_VesselBerth.Count == 0)
            {
                VesselBerth vesselBerth = new VesselBerth();

                vesselBerth.VSL_CNNAME = noData;
                vesselBerth.REPORT_DATE = DateTime.Parse(id);
                vesselBerth.MyDate = id;
                vesselBerth.punctualityRate = 100;

                _VesselBerth.Add(vesselBerth);

            }
            else
            {
                double count = (from v in _VesselBerth where v.VBT_STATUS.Contains("准") || v.VBT_STATUS.Equals("提前") select v.VBT_STATUS).Count();

                _VesselBerth[0].punctualityRate = count / _VesselBerth.Count * 100;
            }

            return View(_VesselBerth.ToList());
        }

        [Authorize(Roles = "SC")]
        public ActionResult Depart(string id)
        {
            if (string.IsNullOrEmpty(id))
                id = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");

            var _VesselBerth = Cache.VesselDepartList.FindAll(t => t.REPORT_DATE.Equals(DateTime.Parse(id)));

            string noData = "暂无数据";

            if (_VesselBerth.Count == 0)
            {
                VesselDepart vesselDepart = new VesselDepart();

                vesselDepart.VSL_CNNAME = noData;
                vesselDepart.REPORT_DATE = DateTime.Parse(id);
                vesselDepart.MyDate = id;
                vesselDepart.punctualityRate = 100;

                _VesselBerth.Add(vesselDepart);
            }
            else
            {
                double count = (from v in _VesselBerth where v.VBT_STATUS.Contains("准") || v.VBT_STATUS.Equals("提前") select v.VBT_STATUS).Count();

                _VesselBerth[0].punctualityRate = count / _VesselBerth.Count * 100;
            }

            return View(_VesselBerth.ToList());

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
                VesselBerthList = VesselBerth.GetVesselBerths();
                VesselDepartList = VesselDepart.GetVesselDeparts();
            }

            public static List<VesselBerth> VesselBerthList;
            public static List<VesselDepart> VesselDepartList;
        }

    }
}
