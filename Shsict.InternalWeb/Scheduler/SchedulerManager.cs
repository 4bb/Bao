using System;
using System.Collections.Generic;
using System.Threading;

namespace Shsict.InternalWeb.Scheduler
{
    public static class SchedulerManager
    {
        public static void Start()
        {
            try
            {
                Job j = new CacheRefreshEventInter();
                CurrentJobsList.Add(j.ScheduleType, j.Execute());

                //Job j1 = new DailyReporterCacheRefreshEvent();
                //Job j2 = new ProductionReportCacheRefreshEvent();
                Job j3 = new OperationCacheRefreshEvent();
                //Job j4 = new MechanicalCacheRefreshEvent();
                //Job j5 = new AttendanceCacheRefreshEvent();


                //CurrentJobsList.Add(j1.ScheduleType, j1.Execute());
                //CurrentJobsList.Add(j2.ScheduleType, j2.Execute());
                CurrentJobsList.Add(j3.ScheduleType, j3.Execute());
                //CurrentJobsList.Add(j4.ScheduleType, j4.Execute());
                //CurrentJobsList.Add(j5.ScheduleType, j5.Execute());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Stop()
        {
            try
            {
                if (CurrentJobsList != null && CurrentJobsList.Count > 0)
                {
                    foreach (var item in CurrentJobsList)
                    {
                        item.Value.Dispose();
                    }

                    CurrentJobsList.Clear();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Dictionary<string, Timer> CurrentJobsList = new Dictionary<string, Timer>();
    }
}
