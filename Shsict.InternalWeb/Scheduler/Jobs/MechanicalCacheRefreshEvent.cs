using System;
using System.IO;
using System.Threading;

using System.Configuration;
using Shsict.Entity;
using Shsict.InternalWeb.Controllers;

namespace Shsict.InternalWeb.Scheduler
{
    public class MechanicalCacheRefreshEvent : Job
    {
        public MechanicalCacheRefreshEvent()
        {
            ScheduleType = "Shsict.InternalWeb.Scheduler.IMechanicalCacheRefreshEvent";
            DueTimeInterval = 60 * 1000 * 2;

            string ContainerRefreshRateStr = ConfigurationManager.AppSettings.GetValues("MechanicalRefreshRate")[0].ToString();
            PeriodInterval = 60 * 1000 * Int32.Parse(ContainerRefreshRateStr);
        }
    }

    public class IMechanicalCacheRefreshEvent : IJob
    {
        private int _IsRunning;
        public void Execute(object sender)
        {
            if (Interlocked.Exchange(ref _IsRunning, 1) == 0)
            {
                try
                {
                    MechanicalErrorController.Cache.RefreshCache();
                    LogEvent.logSuccess("MechanicalError Refresh Cache Success");

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
