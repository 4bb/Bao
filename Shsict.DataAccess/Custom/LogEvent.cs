using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Text;

namespace Shsict.DataAccess
{
    /// <summary>
    /// 刷新日志
    /// </summary>
    public class LogEvent
    {
        public static DataRow GetLogEventByID(string logID)
        {
            string sql = @"SELECT LOGID, EventType, Message, ErrorStackTrace, EventDate
                            FROM MOBILEAPP_LOGEVENT WHERE (LOGID = :logID) ";

            OracleParameter[] para = new OracleParameter[1];
            para[0] = new OracleParameter("logID", logID);

            DataSet ds = OracleDataTool.ExecuteDataset(ConnectStringOracle.GetTableConnection(), sql, para);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return ds.Tables[0].Rows[0];
            }
        }
        public static void InsertLogEvent(string eventType, string message, string errorStackTrace, DateTime eventDate)
        {
            string sql = @"INSERT INTO MOBILEAPP_LOGEVENT
                            (LOGID, EventType, Message, ErrorStackTrace, EventDate )
                            VALUES ( SEQ_MOBILEAPP.Nextval, :eventType ,:message ,:errorStackTrace ,to_date(:eventDate,'yyyy-MM-DD hh24:mi:ss') )";

            OracleParameter[] para = new OracleParameter[4];
            para[0] = new OracleParameter("eventType", eventType);
            para[1] = new OracleParameter("message", message);
            para[2] = new OracleParameter("errorStackTrace", errorStackTrace);
            para[3] = new OracleParameter("eventDate", eventDate.ToString());
  

            OracleDataTool.ExecuteNonQuery(ConnectStringOracle.GetTableConnection(), sql, para);

        }

        public static void UpdateLogEvent(string logID, string eventType, string message, string errorStackTrace, DateTime eventDate)
        {
            string sql = @"UPDATE MOBILEAPP_LOGEVENT SET EventType=:eventType, Message=:message, ErrorStackTrace=:errorStackTrace, EventDate=to_date(:eventDate,'yyyy-MM-DD hh24:mi:ss')
                           WHERE LOGID=:logID";

            OracleParameter[] para = new OracleParameter[5];
            para[0] = new OracleParameter("logID", logID);
            para[1] = new OracleParameter("eventType", eventType);
            para[2] = new OracleParameter("message", message);
            para[3] = new OracleParameter("errorStackTrace", errorStackTrace);
            para[4] = new OracleParameter("eventDate", eventDate.ToString());
           
            OracleDataTool.ExecuteNonQuery(ConnectStringOracle.GetTableConnection(), sql, para);
        }

        public static void DeleteLogEvent(string logID)
        {
            string sql = @"DELETE FROM  MOBILEAPP_LOGEVENT WHERE LOGID=:logID ";

            DataSet ds = OracleDataTool.ExecuteDataset(ConnectStringOracle.GetTableConnection(), sql);

            OracleParameter[] para = new OracleParameter[1];
            para[0] = new OracleParameter("logID", logID);

            OracleDataTool.ExecuteNonQuery(ConnectStringOracle.GetTableConnection(), sql, para);
        }

        public static DataTable GetLogEvents()
        {
            string sql = @"SELECT LOGID, EventType, Message, ErrorStackTrace, EventDate
                            FROM  MOBILEAPP_LOGEVENT ";

            DataSet ds = OracleDataTool.ExecuteDataset(ConnectStringOracle.GetTableConnection(), sql);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return ds.Tables[0];
            }
        }

    }
}
