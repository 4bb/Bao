using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Shsict.InternalWeb.Models;
namespace Shsict.InternalWeb.Controllers
{
    public class PadYardDensityController : Controller
    {
        [Authorize(Roles = "SC")]
        public ActionResult Index(string id)
        {
            if (id == null)
            {
                id = DateTime.Now.ToString("yyyy-MM-dd");

            }

            var _YardDensity = YardDensityController.Cache.YardDensityList.FindAll(t => t.YD_ID.Date.Equals(DateTime.Parse(id))).OrderBy(t => t.mySort).ToList();

            string noData = "暂无数据";

            if (_YardDensity.Count == 0)
            {
                YardDensity yardDensity = new YardDensity();

                yardDensity.YD_CNTR_STATUS = noData;
                yardDensity.YD_ID = DateTime.Parse(id);
                yardDensity.MyDate = id;

                _YardDensity.Add(yardDensity);
            }

            return View(_YardDensity.ToList());
        }
        [Authorize(Roles = "SC")]
        public ActionResult Charts(string id)
        {
            if (id == null)
            {
                id = DateTime.Now.ToString("yyyy-MM-dd");

            }

            var _YardDensity = YardDensityController.Cache.YardDensityList.FindAll(t => t.YD_ID.Date.Equals(DateTime.Parse(id)));

            string noData = "暂无数据";

            Dictionary<int, YardDensity> myYardDensity = new Dictionary<int, YardDensity>();

            foreach (YardDensity yd in _YardDensity)
            {
                if (!myYardDensity.ContainsKey(yd.mySort))
                {
                    myYardDensity.Add(yd.mySort, yd);
                }
            }

            YardDensity yardDensity = new YardDensity();
            yardDensity.YD_CNTR_STATUS = noData;
            yardDensity.YD_ID = DateTime.Parse(id);
            yardDensity.MyDate = id;
            yardDensity.mySort = 0;
            yardDensity.YD_SAC_SUM = yardDensity.YD_YARD_SLOT_SUM = yardDensity.YD_YARD_SLOT_TOTAL = "0";
            yardDensity.YD_PCT = 0;

            for (int i = 1; i <= 7; i++)
            {
                if (!myYardDensity.ContainsKey(i))
                {
                    myYardDensity.Add(i, yardDensity);
                }
            }

            return View(myYardDensity);
        }

    }
}
