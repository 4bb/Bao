using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.OracleClient;

using Shsict.InternalWeb.Models;

namespace Shsict.InternalWeb.Controllers
{
    public class PadTwinLiftController : Controller
    {
        [Authorize(Roles = "SC")]
        public ActionResult Index(string id)
        {
            if (string.IsNullOrEmpty(id))
                id = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");

            List<TwinLift> _twinLift = TwinLiftController.Cache.TwinLiftList.FindAll(t => t.REPORTDATE.Equals(DateTime.Parse(id)));

            string noData = "暂无数据";

            if (_twinLift.Count == 0)
            {
                TwinLift twinLift = new TwinLift();

                twinLift.VESSELNAME = noData;
                twinLift.REPORTDATE = DateTime.Parse(id);
                twinLift.IEFG = noData;

                _twinLift.Add(twinLift);
            }

            _twinLift[0].MyDate = id;
            return View(_twinLift.ToList());
        }

    }
}
