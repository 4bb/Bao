using Shsict.Entity;
using System;
using System.Configuration;
using System.IO;
using System.Threading;

namespace Shsict.Scheduler
{
    public class VesselCacheRefreshEvent : Job
    {
        public VesselCacheRefreshEvent()
        {
            ScheduleType = "Shsict.Scheduler.IVesselCacheRefreshEvent";
            DueTimeInterval = 60 * 1000 * 2;
            string VesselRefreshRateStr = ConfigurationManager.AppSettings.GetValues("VesselRefreshRate")[0].ToString();
            PeriodInterval = 60 * 1000 * Int32.Parse(VesselRefreshRateStr);
        }
    }

    public class IVesselCacheRefreshEvent : IJob
    {
        private int _IsRunning;
        public void Execute(object sender)
        {
            if (Interlocked.Exchange(ref _IsRunning, 1) == 0)
            {
                try
                {
                    OVesselPlan.Cache.RefreshCache();
                    LogEvent.logSuccess("VesselPlan Refresh Cache Success");

                    PortOfCall.Cache.RefreshCache();
                    LogEvent.logSuccess("PortOfCall Refresh Cache Success");
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

