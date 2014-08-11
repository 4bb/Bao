using System;
using System.IO;
using System.Threading;

using System.Configuration;
using Shsict.Entity;
using Shsict.InternalWeb.Controllers;

namespace Shsict.InternalWeb.Scheduler
{
    public class CacheRefreshEventInter :Job
    {
        public CacheRefreshEventInter()
        {
            ScheduleType = "Shsict.InternalWeb.Scheduler.ICacheRefreshEventInter";
            DueTimeInterval = 0;
            string ContainerRefreshRateStr = ConfigurationManager.AppSettings.GetValues("InternalWebRefresh")[0].ToString();
            //string ContainerRefreshRateStr = "5";
            PeriodInterval = 60 * 1000 * Int32.Parse(ContainerRefreshRateStr);
        }

    }

    public class ICacheRefreshEventInter : IJob
    {
        private int _IsRunning;
        public void Execute(object sender)
        {
            if (Interlocked.Exchange(ref _IsRunning, 1) == 0)
            {
                try
                {
                    //LogEvent.logSuccess(string.Format("Refresh Cache Start - {0}", DateTime.Now.ToString("HH:mm:ss")),2);
                    string starTime = DateTime.Now.ToString("HH:mm:ss");

                    OperatePlanController.Cache.RefreshCache();
                    //LogEvent.logSuccess("OperatePlan Refresh Cache Success", 2);

                    DailyReportController.Cache.RefreshCache();
                    //LogEvent.logSuccess("DailyReport Refresh Cache Success", 2);

                    ThreeShiftController.Cache.RefreshCache();
                    //LogEvent.logSuccess("ThreeShift Refresh Cache Success", 2);

                    MechanicalErrorController.Cache.RefreshCache();
                    //LogEvent.logSuccess("MechanicalError Refresh Cache Success", 2);

                    VesselAmountController.Cache.RefreshCache();
                    //LogEvent.logSuccess("VesselAmount Refresh Cache Success", 2);

                    //TruckOperationCycleController.Cache.RefreshCache();
                    //LogEvent.logSuccess("TruckOperation Refresh Cache Success", 2);

                    VesselEfficiencyController.Cache.RefreshCache();
                    //LogEvent.logSuccess("VesselEfficiency Refresh Cache Success", 2);

                    YardDensityController.Cache.RefreshCache();
                    //LogEvent.logSuccess("YardDensity Refresh Cache Success", 2);

                    TwinLiftController.Cache.RefreshCache();
                    //LogEvent.logSuccess("TwinLift Refresh Cache Success", 2);

                    VesselBerthController.Cache.RefreshCache();
                    //LogEvent.logSuccess("VesselBerth Refresh Cache Success", 2);


                    LogEvent.logSuccess(string.Format("Refresh Cache Start-{0} \r\nRefresh Cache End - {1}", starTime, DateTime.Now.ToString("HH:mm:ss")), 2);
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
