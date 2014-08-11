using System;
using System.Threading;

using Shsict.Entity;
using System.Configuration;

namespace Shsict.Scheduler
{
    public class CacheRefreshEvent : Job
    {
        public CacheRefreshEvent()
        {
            ScheduleType = "Shsict.Scheduler.ICacheRefreshEvent";

            // TODO : To add in the Configuration
            string ContainerRefreshRateStr = ConfigurationManager.AppSettings.GetValues("CacheRefresh")[0].ToString(); ;
            DueTimeInterval = 0;
            PeriodInterval = 60 * 1000 * Int32.Parse(ContainerRefreshRateStr);
        }

    }

    public class ICacheRefreshEvent : IJob
    {
        private int _IsRunning;
        public void Execute(object sender)
        {
            if (Interlocked.Exchange(ref _IsRunning, 1) == 0)
            {
                try
                {
                    string starTime = DateTime.Now.ToString("HH:mm:ss");

                    //LogEvent.logSuccess(string.Format("Refresh Cache Start - {0}", DateTime.Now.ToString("HH:mm:ss")), 1);

                    ContainerEload.Cache.RefreshCache();
                    //LogEvent.logSuccess("ContainerEload Refresh Cache Success", 1);

                    ContainerMain.Cache.RefreshCache();
                    //LogEvent.logSuccess("ContainerMain Refresh Cache Success", 1);

                    ContainerPlan.Cache.RefreshCache();
                    //LogEvent.logSuccess("ContainerPlan Refresh Cache Success", 1);

                    ContainerDetail.Cache.RefreshCache();
                    //LogEvent.logSuccess("ContainerDetail Refresh Cache Success", 1);

                    Notice.Cache.RefreshCache();
                    //LogEvent.logSuccess("Notice Refresh Cache Success", 1);

                    OTruck.Cache.RefreshCache();
                    //LogEvent.logSuccess("Truck Refresh Cache Success", 1);


                    TVDangerPlan.Cache.RefreshCache();
                    //LogEvent.logSuccess("TVDangerPlan Refresh Cache Success", 1);

                    TVDangerContainer.Cache.RefreshCache();
                    //LogEvent.logSuccess("TVDangerContainer Refresh Cache Success", 1);

                    OVesselPlan.Cache.RefreshCache();
                    //LogEvent.logSuccess("VesselPlan Refresh Cache Success", 1);

                    PortOfCall.Cache.RefreshCache();
                    //LogEvent.logSuccess("PortOfCall Refresh Cache Success", 1);

                    MyFavourite.ReloadAll("database");

                    //LogEvent.logSuccess("Favourite Refresh Cache Success", 1);

                    LogEvent.logSuccess(string.Format("Refresh Cache Start-{0}\r\n Refresh Cache End - {1}", starTime, DateTime.Now.ToString("HH:mm:ss")), 1);
                }
                catch (Exception ex)
                {
                    LogEvent.logErro(ex, 1);
                }
                finally
                {
                    Interlocked.Exchange(ref _IsRunning, 0);
                }
            }
        }
    }
}
