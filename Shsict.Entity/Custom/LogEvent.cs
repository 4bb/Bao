using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace Shsict.Entity
{
    /// <summary>
    /// 更新日志
    /// </summary>
    public class LogEvent
    {
        public LogEvent() { }

        public LogEvent(DataRow dr)
        {
            InitLogEvent(dr);
        }

        private void InitLogEvent(DataRow dr)
        {
            if (dr != null)
            {
                LOGID = dr["LOGID"].ToString();
                EventType = (LogType)Enum.Parse(typeof(LogType), dr["EventType"].ToString());
                Message = dr["Message"].ToString();
                ErrorStackTrace = dr["ErrorStackTrace"].ToString();
                EventDate = DateTime.Parse(dr["EventDate"].ToString());


            }
            else
            {
                throw new Exception("Unable to init LogEvent.");
            }
        }

        public void Select()
        {
            DataRow dr = Shsict.DataAccess.LogEvent.GetLogEventByID(LOGID);

            if (dr != null)
            {
                InitLogEvent(dr);
            }
        }

        public void Insert()
        {
            Shsict.DataAccess.LogEvent.InsertLogEvent(EventType.ToString(), Message, ErrorStackTrace, (DateTime)EventDate);

        }

        public void Update()
        {
            Shsict.DataAccess.LogEvent.UpdateLogEvent(LOGID, EventType.ToString(), Message, ErrorStackTrace, (DateTime)EventDate);

        }

        public void Delete()
        {
            Shsict.DataAccess.LogEvent.DeleteLogEvent(LOGID);

        }

        public static List<LogEvent> GetLogEvents()
        {
            DataTable dt = Shsict.DataAccess.LogEvent.GetLogEvents();
            List<LogEvent> list = new List<LogEvent>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new LogEvent(dr));
                }
            }

            return list;
        }

        /// <summary>
        /// 插入LOG表
        /// </summary>
        /// <param name="let">LOG类型</param>
        /// <param name="message">LOG信息</param>
        /// <param name="errorStackTrace">异常堆栈</param>
        /// <param name="Type">1外网，2内网</param>
        public static void Logging(LogType let, string message, string errorStackTrace, int Type)
        {
            try
            {
                //LogEvent l = new LogEvent();
                //l.EventType = let;
                //l.EventDate = DateTime.Now.ToLocalTime();
                //l.Message = message;
                //l.ErrorStackTrace = errorStackTrace;
                //l.Insert();
                string str = "Mylog.txt";

                if (Type == 1)
                {
                    str = "External\\ExternalLog" + DateTime.Now.Date.ToString("yyyyMMdd") + ".txt";
                }
                else
                {
                    str = "Internal\\InternalLog" + DateTime.Now.Date.ToString("yyyyMMdd") + ".txt";

                }


                using (System.IO.StreamWriter sw = new System.IO.StreamWriter("D:\\www-root\\LogEvent\\" + str, true))
                {
                    sw.WriteLine("\r\n本次轮询：\r\n状态:{0} \r\n 信息:{1}\r\n ", let, message);
                }

            }
            catch (Exception ex)
            {

                string str = "MyErrorlog.txt";

                if (Type == 1)
                {
                    str = "External\\ExternalLogError" + DateTime.Now.Date.ToString("yyyyMMdd") + ".txt";
                }
                else
                {
                    str = "Internal\\InternalLogError" + DateTime.Now.Date.ToString("yyyyMMdd") + ".txt";

                }

                using (System.IO.StreamWriter sw = new System.IO.StreamWriter("D:\\www-root\\LogEvent\\" + str, true))
                {
                    sw.WriteLine("\r\n报错信息：时间：{0}\r\n    LogType:{1}\r\n Message:{2}\r\n ErrorStackTrace:{3} \r\n 错误信息", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss "), let, message, errorStackTrace, ex.Message);
                }

            }
        }

        /// <summary>
        /// 记录执行成功消息
        /// </summary>
        /// <param name="msgSuccess"></param>
        public static void logSuccess(string msgSuccess, int type)
        {
            Logging(LogType.Success, msgSuccess, string.Empty, type);
        }
        public static void logErro(Exception exp, int type)
        {
            Logging(LogType.Error, exp.Message, exp.StackTrace, type);
        }
        //public static void logErroMsg(string msgErro)
        //{
        //    Logging(LogType.Error, msgErro, string.Empty);
        //}

        #region members and propertis
        public string LOGID { get; set; }
        public LogType EventType { get; set; }
        public string Message { get; set; }
        public string ErrorStackTrace { get; set; }
        public DateTime EventDate { get; set; }
        #endregion
        public enum LogType
        {
            Success,
            Error
        }
    }
}



