using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Text;

namespace Shsict.DataAccess
{
    /// <summary>
    /// 访问信息
    /// </summary>
    public class VisitMsg
    {
        public static DataRow GetVisitMsgByID(string logID)
        {
            string sql = @"SELECT  VISITID ,IP, VISIT_DATE, BROWSER ,MOBILE_USER_AGENT ,USERNAME
                            FROM MOBILEAPP_VISIT WHERE (LOGID = :logID) ";

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

        public static void InsertVisitMsg(string visitID, string ip, DateTime visitDate, string browser, string mobileUserAgent,string userName)
        {
            string sql = @"INSERT INTO MOBILEAPP_VISIT
                            ( VISITID ,IP, VISIT_DATE, BROWSER ,MOBILE_USER_AGENT ,USERNAME)
                            VALUES ( SEQ_MOBILEAPP.Nextval, :ip ,to_date(:visitDate,'yyyy-MM-DD hh24:mi:ss') ,:browser ,:mobileUserAgent ,:userName)";

            OracleParameter[] para = new OracleParameter[5];
            para[0] = new OracleParameter("ip", ip);
            para[1] = new OracleParameter("visitDate", visitDate.ToString());
            para[2] = new OracleParameter("browser", browser);
            para[3] = new OracleParameter("mobileUserAgent", mobileUserAgent);
            para[4] = new OracleParameter("userName", userName);

            OracleDataTool.ExecuteNonQuery(ConnectStringOracle.GetTableConnection(), sql, para);

        }

        public static void UpdateVisitMsg(string visitID, string ip, DateTime visitDate, string browser, string mobileUserAgent, string userName)
        {
            string sql = @"UPDATE MOBILEAPP_VISIT SET IP=:ip ,VISIT_DATE=to_date(:visitDate,'yyyy-MM-DD hh24:mi:ss') ,BROWSER=:browser, MOBILE_USER_AGENT=:mobileUserAgent, USERNAME=:userName
                           WHERE VISITID=:visitID";

            OracleParameter[] para = new OracleParameter[6];
            para[0] = new OracleParameter("visitID", visitID);
            para[1] = new OracleParameter("ip", ip);
            para[2] = new OracleParameter("visitDate", visitDate.ToString());
            para[3] = new OracleParameter("browser", browser);
            para[4] = new OracleParameter("mobileUserAgent", mobileUserAgent);
            para[5] = new OracleParameter("userName", userName);
           
            OracleDataTool.ExecuteNonQuery(ConnectStringOracle.GetTableConnection(), sql, para);
        }

        public static void DeleteVisitMsg(string visitID)
        {
            string sql = @"DELETE FROM  MOBILEAPP_VISIT WHERE VISITID=:visitID ";

            DataSet ds = OracleDataTool.ExecuteDataset(ConnectStringOracle.GetTableConnection(), sql);

            OracleParameter[] para = new OracleParameter[1];
            para[0] = new OracleParameter("visitID", visitID);

            OracleDataTool.ExecuteNonQuery(ConnectStringOracle.GetTableConnection(), sql, para);
        }

        public static DataTable GetVisitMsgs()
        {
            string sql = @"SELECT VISITID ,IP, VISIT_DATE, BROWSER ,MOBILE_USER_AGENT ,USERNAME
                            FROM  MOBILEAPP_VISIT ";

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
