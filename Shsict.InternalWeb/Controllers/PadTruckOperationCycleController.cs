using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Shsict.InternalWeb.Models;

namespace Shsict.InternalWeb.Controllers
{
    public class PadTruckOperationCycleController : Controller
    {
        [Authorize(Roles = "ZYL")]
        public ActionResult Index()
        {
            return RedirectToAction("SortByCompTruck");
        }

        [Authorize(Roles = "ZYL")]
        public ActionResult SortByCurrent(string id = "25N")
        {
            int i = 25;

            List<TruckOperationCycle> _TruckOperationCycles;

            if (int.TryParse(id.Substring(0, id.Length - 1), out  i))
            {
                _TruckOperationCycles = TruckOperationCycleController.Cache.TruckOperationCycleList.FindAll(t => t.AVEPERIOD >= i && t.STOPFG.Equals(id.Substring(id.Length - 1, 1)));
            }
            else
            {
                _TruckOperationCycles = TruckOperationCycleController.Cache.TruckOperationCycleList.FindAll(t => t.AVEPERIOD >= 25 && t.STOPFG.Equals(id.Substring(id.Length - 1, 1)));

            }

            if (_TruckOperationCycles == null)
            {
                //string noData = "暂无数据";

                TruckOperationCycle truckOperationCycle = new TruckOperationCycle();
                truckOperationCycle.COMPLETETRUCKNUM = 0;

                _TruckOperationCycles.Add(truckOperationCycle);

            }

            return View(_TruckOperationCycles.OrderBy(t => t.CURRENTINSTRUCTION).ToList());
        }

        [Authorize(Roles = "ZYL")]
        public ActionResult SortByCurrentDesc(string id = "25N")
        {
            int i = 25;

            List<TruckOperationCycle> _TruckOperationCycles;

            if (int.TryParse(id.Substring(0, id.Length - 1), out  i))
            {
                _TruckOperationCycles = TruckOperationCycleController.Cache.TruckOperationCycleList.FindAll(t => t.AVEPERIOD >= i && t.STOPFG.Equals(id.Substring(id.Length - 1, 1)));
            }
            else
            {
                _TruckOperationCycles = TruckOperationCycleController.Cache.TruckOperationCycleList.FindAll(t => t.AVEPERIOD >= 25 && t.STOPFG.Equals(id.Substring(id.Length - 1, 1)));

            }

            if (_TruckOperationCycles == null)
            {
                //string noData = "暂无数据";

                TruckOperationCycle truckOperationCycle = new TruckOperationCycle();
                truckOperationCycle.COMPLETETRUCKNUM = 0;

                _TruckOperationCycles.Add(truckOperationCycle);

            }

            return View(_TruckOperationCycles.OrderByDescending(t => t.CURRENTINSTRUCTION).ToList());
        }

        [Authorize(Roles = "ZYL")]
        public ActionResult SortByCompTruck(string id = "25N")
        {
            int i = 25;

            List<TruckOperationCycle> _TruckOperationCycles;

            if (int.TryParse(id.Substring(0, id.Length - 1), out  i))
            {
                _TruckOperationCycles = TruckOperationCycleController.Cache.TruckOperationCycleList.FindAll(t => t.AVEPERIOD >= i && t.STOPFG.Equals(id.Substring(id.Length - 1, 1)));
            }
            else
            {
                _TruckOperationCycles = TruckOperationCycleController.Cache.TruckOperationCycleList.FindAll(t => t.AVEPERIOD >= 25 && t.STOPFG.Equals(id.Substring(id.Length - 1, 1)));

            }

            if (_TruckOperationCycles == null)
            {
                //string noData = "暂无数据";

                TruckOperationCycle truckOperationCycle = new TruckOperationCycle();
                truckOperationCycle.COMPLETETRUCKNUM = 0;

                _TruckOperationCycles.Add(truckOperationCycle);

            }

            return View(_TruckOperationCycles.OrderBy(t => t.COMPLETETRUCKNUM).ToList());
        }

        [Authorize(Roles = "ZYL")]
        public ActionResult SortByCompTruckDesc(string id = "25N")
        {
            int i = 25;

            List<TruckOperationCycle> _TruckOperationCycles;

            if (int.TryParse(id.Substring(0, id.Length - 1), out  i))
            {
                _TruckOperationCycles = TruckOperationCycleController.Cache.TruckOperationCycleList.FindAll(t => t.AVEPERIOD >= i && t.STOPFG.Equals(id.Substring(id.Length - 1, 1)));
            }
            else
            {
                _TruckOperationCycles = TruckOperationCycleController.Cache.TruckOperationCycleList.FindAll(t => t.AVEPERIOD >= 25 && t.STOPFG.Equals(id.Substring(id.Length - 1, 1)));

            }

            if (_TruckOperationCycles == null)
            {
                //string noData = "暂无数据";

                TruckOperationCycle truckOperationCycle = new TruckOperationCycle();
                truckOperationCycle.COMPLETETRUCKNUM = 0;

                _TruckOperationCycles.Add(truckOperationCycle);

            }

            return View(_TruckOperationCycles.OrderByDescending(t => t.COMPLETETRUCKNUM).ToList());
        }

        [Authorize(Roles = "ZYL")]
        public ActionResult SortByAvgTruck(string id = "25N")
        {
            int i = 25;

            List<TruckOperationCycle> _TruckOperationCycles;

            if (int.TryParse(id.Substring(0, id.Length - 1), out  i))
            {
                _TruckOperationCycles = TruckOperationCycleController.Cache.TruckOperationCycleList.FindAll(t => t.AVEPERIOD >= i && t.STOPFG.Equals(id.Substring(id.Length - 1, 1)));
            }
            else
            {
                _TruckOperationCycles = TruckOperationCycleController.Cache.TruckOperationCycleList.FindAll(t => t.AVEPERIOD >= 25 && t.STOPFG.Equals(id.Substring(id.Length - 1, 1)));

            }

            if (_TruckOperationCycles == null)
            {
                //string noData = "暂无数据";

                TruckOperationCycle truckOperationCycle = new TruckOperationCycle();
                truckOperationCycle.COMPLETETRUCKNUM = 0;

                _TruckOperationCycles.Add(truckOperationCycle);

            }

            return View(_TruckOperationCycles.OrderBy(t => t.AVEPERIOD).ToList());
        }

        [Authorize(Roles = "ZYL")]
        public ActionResult SortByAvgTruckDesc(string id = "25N")
        {
            int i = 25;

            List<TruckOperationCycle> _TruckOperationCycles;

            if (int.TryParse(id.Substring(0, id.Length - 1), out  i))
            {
                _TruckOperationCycles = TruckOperationCycleController.Cache.TruckOperationCycleList.FindAll(t => t.AVEPERIOD >= i && t.STOPFG.Equals(id.Substring(id.Length - 1, 1)));
            }
            else
            {
                _TruckOperationCycles = TruckOperationCycleController.Cache.TruckOperationCycleList.FindAll(t => t.AVEPERIOD >= 25 && t.STOPFG.Equals(id.Substring(id.Length - 1, 1)));

            }

            if (_TruckOperationCycles == null)
            {
                //string noData = "暂无数据";

                TruckOperationCycle truckOperationCycle = new TruckOperationCycle();
                truckOperationCycle.COMPLETETRUCKNUM = 0;

                _TruckOperationCycles.Add(truckOperationCycle);

            }

            return View(_TruckOperationCycles.OrderByDescending(t => t.AVEPERIOD).ToList());
        }

        [Authorize(Roles = "ZYL")]
        public ActionResult SortByToloc(string id = "25N")
        {
            int i = 25;

            List<TruckOperationCycle> _TruckOperationCycles;

            if (int.TryParse(id.Substring(0, id.Length - 1), out  i))
            {
                _TruckOperationCycles = TruckOperationCycleController.Cache.TruckOperationCycleList.FindAll(t => t.AVEPERIOD >= i && t.STOPFG.Equals(id.Substring(id.Length - 1, 1)));
            }
            else
            {
                _TruckOperationCycles = TruckOperationCycleController.Cache.TruckOperationCycleList.FindAll(t => t.AVEPERIOD >= 25 && t.STOPFG.Equals(id.Substring(id.Length - 1, 1)));

            }

            if (_TruckOperationCycles == null)
            {
                //string noData = "暂无数据";

                TruckOperationCycle truckOperationCycle = new TruckOperationCycle();
                truckOperationCycle.COMPLETETRUCKNUM = 0;

                _TruckOperationCycles.Add(truckOperationCycle);

            }

            return View(_TruckOperationCycles.OrderBy(t => t.TOLOC1).ToList());
        }

        [Authorize(Roles = "ZYL")]
        public ActionResult SortByTolocDesc(string id = "25N")
        {
            int i = 25;

            List<TruckOperationCycle> _TruckOperationCycles;

            if (int.TryParse(id.Substring(0, id.Length - 1), out  i))
            {
                _TruckOperationCycles = TruckOperationCycleController.Cache.TruckOperationCycleList.FindAll(t => t.AVEPERIOD >= i && t.STOPFG.Equals(id.Substring(id.Length - 1, 1)));
            }
            else
            {
                _TruckOperationCycles = TruckOperationCycleController.Cache.TruckOperationCycleList.FindAll(t => t.AVEPERIOD >= 25 && t.STOPFG.Equals(id.Substring(id.Length - 1, 1)));

            }

            if (_TruckOperationCycles == null)
            {
                //string noData = "暂无数据";

                TruckOperationCycle truckOperationCycle = new TruckOperationCycle();
                truckOperationCycle.COMPLETETRUCKNUM = 0;

                _TruckOperationCycles.Add(truckOperationCycle);

            }

            return View(_TruckOperationCycles.OrderByDescending(t => t.TOLOC1).ToList());
        }
    }
}
