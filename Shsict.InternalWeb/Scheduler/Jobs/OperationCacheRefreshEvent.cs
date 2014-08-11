using System;
using System.IO;
using System.Threading;

using System.Configuration;
using Shsict.Entity;
using Shsict.InternalWeb.Controllers;

namespace Shsict.InternalWeb.Scheduler
{
    public class OperationCacheRefreshEvent : Job
    {
        public OperationCacheRefreshEvent()
        {
            ScheduleType = "Shsict.InternalWeb.Scheduler.IOperationCacheRefreshEvent";
            DueTimeInterval = 60 * 1000 * 2;

            string ContainerRefreshRateStr = ConfigurationManager.AppSettings.GetValues("TruckOperationCycle")[0].ToString();
            PeriodInterval = 60 * 1000 * Int32.Parse(ContainerRefreshRateStr);

        }
    }

    public class IOperationCacheRefreshEvent : IJob
    {
        private int _IsRunning;
        public void Execute(object sender)
        {
            if (Interlocked.Exchange(ref _IsRunning, 1) == 0)
            {
                try
                {
                    string starTime = DateTime.Now.ToString("HH:mm:ss");

                    TruckOperationCycleController.Cache.RefreshCache();

                    LogEvent.logSuccess(string.Format("TruckOperationCycle Refresh Cache Start-{0} \r\nRefresh Cache End - {1}", starTime, DateTime.Now.ToString("HH:mm:ss")), 2);

                }
                catch (Exception ex)
                {

                    LogEvent.logErro(ex, 2);
                }
                finally
                {
                    Interlocked.Exchange(ref _IsRunning, 0);
                }
            }
        }
    }
}
