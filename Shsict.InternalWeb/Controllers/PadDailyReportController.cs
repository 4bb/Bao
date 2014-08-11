using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.OracleClient;

using Shsict.InternalWeb.Models;

namespace Shsict.InternalWeb.Controllers
{
    public class PadDailyReportController : Controller
    {
        [Authorize(Roles = "ZY")]
        public ActionResult Index()
        {
            return RedirectToAction("Day");
        }

        [Authorize(Roles = "ZY")]
        public ActionResult Day(string id)
        {
            if (string.IsNullOrEmpty(id))
                id = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");

            var _DailyReports = DailyReportController.Cache.DailyReportList.Find(t => t.REPORT_DATE.Equals(DateTime.Parse(id)));


            if (_DailyReports == null)
            {
                _DailyReports = NoData(_DailyReports, id);

            }
            else
            {
                //_DailyReports.SearchType = dailyReport.SearchType;
            }

            return View(_DailyReports);
        }

        [Authorize(Roles = "ZY")]
        public ActionResult Month(string id)
        {
            if (string.IsNullOrEmpty(id))
                id = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");


            var _DailyReports =DailyReportController.Cache.DailyReportList.Find(t => t.REPORT_DATE.Equals(DateTime.Parse(id)));


            if (_DailyReports == null)
            {
                _DailyReports = NoData(_DailyReports, id);

            }
            else
            {
                //_DailyReports.SearchType = dailyReport.SearchType;
            }

            return View(_DailyReports);
        }

         [Authorize(Roles = "ZY")]
        public ActionResult Year(string id)
        {
            if (string.IsNullOrEmpty(id))
                id = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");

            var _DailyReports = DailyReportController.Cache.DailyReportList.Find(t => t.REPORT_DATE.Equals(DateTime.Parse(id)));

            if (_DailyReports == null)
            {
                _DailyReports = NoData(_DailyReports, id);

            }
            else
            {
                //_DailyReports.SearchType = dailyReport.SearchType;
            }

            return View(_DailyReports);
        }

        public DailyReport NoData(DailyReport _DailyReports, string id)
        {
            string noData = "暂无数据";
            _DailyReports = new DailyReport();
            _DailyReports.LASTALLDAY_PLAN = noData;
            _DailyReports.LASTALLDAY_ACTUAL = noData;
            _DailyReports.LASTALLDAY_BARGE = noData;
            _DailyReports.LASTALLDAY_SHUTTLE = noData;
            _DailyReports.MyLASTALLDAY_COMPLETERATE = noData;
            _DailyReports.MONTHLY_PLAN = noData;
            _DailyReports.MONTHLY_TARGET = noData;
            _DailyReports.MONTHLY_ACTUAL = noData;
            _DailyReports.MONTHLY_BARGE = noData;
            _DailyReports.MONTHLY_SHUTTLE = noData;
            _DailyReports.MyMONTHLY_COMPLETERATE = noData;
            _DailyReports.MONTHLY_PLANCONTAINER = noData;
            _DailyReports.ANNUAL_PLAN = noData;
            _DailyReports.ANNUAL_ACTUAL = noData;
            _DailyReports.ANNUAL_BARGE = noData;
            _DailyReports.ANNUAL_SHUTTLE = noData;
            _DailyReports.MyANNUAL_COMPLETERATE = noData;
            _DailyReports.ANNUAL_PLANCONTAINER = noData;
            _DailyReports.REPORT_DATE = DateTime.Parse(id);
            _DailyReports.MyDate = id;
            return _DailyReports;

        }
    }
}
