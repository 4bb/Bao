using System;
using System.IO;
using System.Threading;
using Shsict.Entity;
using System.Configuration;

namespace Shsict.Scheduler
{
    public class FavouriteCacheRefreshEvent : Job
    {
        public FavouriteCacheRefreshEvent()
        {

            ScheduleType = "Shsict.Scheduler.IFavouriteCacheRefreshEvent";

            DueTimeInterval = 60 * 1000 * 2;
            string FavouriteRefreshRateStr = ConfigurationManager.AppSettings.GetValues("FavouriteRefreshRate")[0].ToString();
            PeriodInterval = 60 * 1000 * Int32.Parse(FavouriteRefreshRateStr);

        }
    }

    public class IFavouriteCacheRefreshEvent : IJob
    {
        private int _IsRunning;
        public void Execute(object sender)
        {
            if (Interlocked.Exchange(ref _IsRunning, 1) == 0)
            {
                try
                {
     
                MyFavourite.ReloadAll("database");

                LogEvent.logSuccess("Favourite Refresh Cache Success");

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

