using Shsict.Entity;
using System;
using System.Configuration;
using System.IO;
using System.Threading;

namespace Shsict.Scheduler
{
    public class TruckCacheRefreshEvent : Job
    {
        public TruckCacheRefreshEvent()
        {
            ScheduleType = "Shsict.Scheduler.ITruckCacheRefreshEvent";
            string TruckRefreshRateStr = ConfigurationManager.AppSettings.GetValues("TruckRefreshRate")[0].ToString();
            DueTimeInterval = 60 * 1000 * 2;
            PeriodInterval = 60 * 1000 * Int32.Parse(TruckRefreshRateStr);
        }
    }

    public class ITruckCacheRefreshEvent : IJob
    {
        private int _IsRunning;
        public void Execute(object sender)
        {
            if (Interlocked.Exchange(ref _IsRunning, 1) == 0)
            {
                try
                {

                    OTruck.Cache.RefreshCache();
                    LogEvent.logSuccess("Truck Refresh Cache Success");

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
