using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.OracleClient;

using Shsict.InternalWeb.Models;

namespace Shsict.InternalWeb.Controllers
{
    public class TwinLiftController : Controller
    {
            [Authorize(Roles = "SC")]
        public ActionResult Index(string id)
        {
            if (string.IsNullOrEmpty(id))
                id = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");

            List<TwinLift> _twinLift = Cache.TwinLiftList.FindAll(t => t.REPORTDATE.Equals(DateTime.Parse(id)));

            string noData = "暂无数据";

            if (_twinLift.Count == 0)
            {
                TwinLift twinLift = new TwinLift();

                twinLift.VESSELNAME = noData;
                twinLift.REPORTDATE = DateTime.Parse(id);


                _twinLift.Add(twinLift);
            }

            _twinLift[0].MyDate = id;
            return View(_twinLift.ToList());
        }
          [Authorize(Roles = "SC")]
        public ActionResult Detail(string id)
        {
            List<TwinLift> _twinLift;

            if (!string.IsNullOrEmpty(id))
            {
                int count = id.IndexOf("$");
                string vName = id.Substring(0, count);
                string Date = id.Substring(count+1, id.Length - count-1);

               _twinLift = Cache.TwinLiftList.FindAll(t => t.REPORTDATE.Equals(DateTime.Parse(Date)) && t.VESSELNAME.Trim().Equals(vName));
               
                string noData = "暂无数据";

               if (_twinLift.Count == 0)
               {
                   TwinLift twinLift = new TwinLift();

                   twinLift.VESSELNAME = noData;
                   twinLift.REPORTDATE = DateTime.Parse(Date);
                   twinLift.IEFG = "Null";

                   _twinLift.Add(twinLift);
               }

               return View(_twinLift.ToList());
            }

            return View();
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

                TwinLiftList = TwinLift.GetTwinLifts();

            }

            public static List<TwinLift> TwinLiftList;

        }

    }
}
