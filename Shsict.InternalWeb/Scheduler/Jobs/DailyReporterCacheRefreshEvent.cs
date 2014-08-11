using System;
using System.IO;
using System.Threading;

using System.Configuration;
using Shsict.Entity;
using Shsict.InternalWeb.Controllers;

namespace Shsict.InternalWeb.Scheduler
{
    public class DailyReporterCacheRefreshEvent : Job
    {
        public DailyReporterCacheRefreshEvent()
        {
            ScheduleType = "Shsict.InternalWeb.Scheduler.IDailyReporterCacheRefreshEvent";
            DueTimeInterval = 60 * 1000 * 2;

            string ContainerRefreshRateStr = ConfigurationManager.AppSettings.GetValues("DailyReporterRefreshRate")[0].ToString();
            PeriodInterval = 60 * 1000 * Int32.Parse(ContainerRefreshRateStr);

        }
    }

    public class IDailyReporterCacheRefreshEvent : IJob
    {
        private int _IsRunning;
        public void Execute(object sender)
        {
            if (Interlocked.Exchange(ref _IsRunning, 1) == 0)
            {
                try
                {
                    DailyReportController.Cache.RefreshCache();              
                    LogEvent.logSuccess("DailyReport Refresh Cache Success");

                    ThreeShiftController.Cache.RefreshCache();
                    LogEvent.logSuccess("ThreeShift Refresh Cache Success");

                }
                catch (Exception ex)
                {

                    LogEvent.logErro(ex);
                }
                finally
                {
                    Interlocked.Exchange(ref _IsRunning, 0);
                }
            }
        }
    }
}
