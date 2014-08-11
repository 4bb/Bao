using Shsict.Entity;
using System;
using System.Configuration;
using System.IO;
using System.Threading;

namespace Shsict.Scheduler
{
    public class NoticeCacheRefreshEvent : Job
    {
        public NoticeCacheRefreshEvent()
        {
            ScheduleType = "Shsict.Scheduler.INoticeCacheRefreshEvent";
            DueTimeInterval = 60 * 1000 * 2;
            string NoticeRefreshRateStr = ConfigurationManager.AppSettings.GetValues("NoticeRefreshRate")[0].ToString();
            PeriodInterval = 60 * 1000 * Int32.Parse(NoticeRefreshRateStr);
        }
    }

    public class INoticeCacheRefreshEvent : IJob
    {
        private int _IsRunning;
        public void Execute(object sender)
        {
            if (Interlocked.Exchange(ref _IsRunning, 1) == 0)
            {
                try
                {
                    Notice.Cache.RefreshCache();
                    LogEvent.logSuccess("Notice Refresh Cache Success");
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
