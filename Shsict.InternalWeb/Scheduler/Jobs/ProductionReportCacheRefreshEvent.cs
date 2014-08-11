using System;
using System.IO;
using System.Threading;

using System.Configuration;
using Shsict.Entity;
using Shsict.InternalWeb.Controllers;

namespace Shsict.InternalWeb.Scheduler
{
    public class ProductionReportCacheRefreshEvent : Job
    {
        public ProductionReportCacheRefreshEvent()
        {
            ScheduleType = "Shsict.InternalWeb.Scheduler.IProductionReportCacheRefreshEvent";
            DueTimeInterval = 60 * 1000 * 2;

            string ContainerRefreshRateStr = ConfigurationManager.AppSettings.GetValues("ProductionReportRefreshRate")[0].ToString();
            PeriodInterval = 60 * 1000 * Int32.Parse(ContainerRefreshRateStr);

        }
    }

    public class IProductionReportCacheRefreshEvent : IJob
    {
        private int _IsRunning;
        public void Execute(object sender)
        {
            if (Interlocked.Exchange(ref _IsRunning, 1) == 0)
            {
                try
                {
                    VesselEfficiencyController.Cache.RefreshCache();
                    LogEvent.logSuccess("VesselEfficiency Refresh Cache Success");

                    YardDensityController.Cache.RefreshCache();
                    LogEvent.logSuccess("YardDensity Refresh Cache Success");

                    TwinLiftController.Cache.RefreshCache();
                    LogEvent.logSuccess("TwinLift Refresh Cache Success");

                    VesselBerthController.Cache.RefreshCache();
                    LogEvent.logSuccess("VesselBerth Refresh Cache Success");

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
