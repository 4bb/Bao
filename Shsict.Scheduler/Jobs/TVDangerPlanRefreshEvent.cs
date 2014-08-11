using Shsict.Entity;
using System;
using System.Configuration;
using System.IO;
using System.Threading;

namespace Shsict.Scheduler
{
    public class TVDangerPlanRefreshEvent : Job
    {
        public TVDangerPlanRefreshEvent()
        {
            ScheduleType = "Shsict.Scheduler.ITVDangerPlanRefreshEvent";
            DueTimeInterval = 60 * 1000 * 2;
            string TVDangerPlanRefreshRateStr = ConfigurationManager.AppSettings.GetValues("TVDangerPlanRefreshRate")[0].ToString();
            PeriodInterval = 60 * 1000 * Int32.Parse(TVDangerPlanRefreshRateStr);
        }
    }

    public class ITVDangerPlanRefreshEvent : IJob
    {
        private int _IsRunning;
        public void Execute(object sender)
        {
            if (Interlocked.Exchange(ref _IsRunning, 1) == 0)
            {
                try
                {

                    TVDangerPlan.Cache.RefreshCache();
                    LogEvent.logSuccess("TVDangerPlan Refresh Cache Success");

                    TVDangerContainer.Cache.RefreshCache();
                    LogEvent.logSuccess("TVDangerContainer Refresh Cache Success");

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
