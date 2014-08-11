using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.OracleClient;

using Shsict.InternalWeb.Models;

namespace Shsict.InternalWeb.Controllers
{
    public class ThreeShiftController : Controller
    {
                [Authorize(Roles = "ZY")]
        public ActionResult Index(string id)
        {
            if (id == null)
            {
                id = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");

            }

            var _threeShifts = Cache.ThreeShiftList.FindAll(t => t.SHIFTDATE.Equals(DateTime.Parse(id)));

            string noData = "暂无数据";

            if (!_threeShifts.Exists(f => f.SHIFT.Equals("1")))
            {
                ThreeShift FirShifts = new ThreeShift();
                FirShifts.SHIFT = "1";
                FirShifts.SHIFTACTUAL = noData;
                FirShifts.MySHIFTCOMPLETERATE = noData;
                FirShifts.SHIFTPLAN = noData;
                FirShifts.SHIFTDATE = DateTime.Parse(id);
                FirShifts.MyDate = id;

                _threeShifts.Add(FirShifts);

            }
            if (!_threeShifts.Exists(f => f.SHIFT.Equals("2")))
            {
                ThreeShift SenShifts = new ThreeShift();
                SenShifts.SHIFT = "2";
                SenShifts.SHIFTACTUAL = noData;
                SenShifts.MySHIFTCOMPLETERATE = noData;
                SenShifts.SHIFTPLAN = noData;
                SenShifts.SHIFTDATE = DateTime.Parse(id);
                SenShifts.MyDate = id;

                _threeShifts.Add(SenShifts);
            }
            if (!_threeShifts.Exists(f => f.SHIFT.Equals("3")))
            {
                ThreeShift TirShifts = new ThreeShift();
                TirShifts.SHIFT = "3";
                TirShifts.SHIFTACTUAL = noData;
                TirShifts.MySHIFTCOMPLETERATE = noData;
                TirShifts.SHIFTPLAN = noData;
                TirShifts.SHIFTDATE = DateTime.Parse(id);
                TirShifts.MyDate = id;

                _threeShifts.Add(TirShifts);
            }


            return View(_threeShifts.ToList());
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

                ThreeShiftList = ThreeShift.GetContainerMains();

            }

            public static List<ThreeShift> ThreeShiftList;

        }

    }
}
