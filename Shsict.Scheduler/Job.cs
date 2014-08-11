using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Shsict.Scheduler
{
    public abstract class Job
    {
        private IJob _ijob = null;

        public IJob IJobInstance
        {
            get
            {
                LoadIJob();
                return _ijob;
            }
        }

        private void LoadIJob()
        {
            if (_ijob == null)
            {
                if (this.ScheduleType == null)
                {
                    throw new Exception("计划任务没有定义其 type 属性");
                }

                Type type = Type.GetType(this.ScheduleType);
                if (type == null)
                {
                    throw new Exception(string.Format("计划任务 {0} 无法被正确识别", this.ScheduleType));
                }
                else
                {
                    _ijob = (IJob)Activator.CreateInstance(type);
                    if (_ijob == null)
                    {
                        throw new Exception(string.Format("计划任务 {0} 未能正确加载", this.ScheduleType));
                    }
                }
            }
        }

        public string ScheduleType { get; set; }
        public int DueTimeInterval { get; set; }
        public int PeriodInterval { get; set; }

        //public Timer JobTimer = null;

        public Timer Execute()
        {
            return new Timer(new TimerCallback(IJobInstance.Execute), null, DueTimeInterval, PeriodInterval);
            //IJobInstance.Execute(sender);
        }
    }
}
