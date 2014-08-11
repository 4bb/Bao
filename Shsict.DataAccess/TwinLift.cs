using System;
using System.Data;
using System.Data.OracleClient;

using Microsoft.ApplicationBlocks.Data;


namespace Shsict.DataAccess
{
    /// <summary>
    /// 双吊具
    /// </summary>
    public class TwinLift
    {
        public static DataTable GetTwinLifts()
        {
            string sql = @"SELECT SCD_ID ,VESSELNAME ,IEFG ,TOTALCNT ,CANSTGOPTCNT  ,CANSTGOPTRATE ,STORAGECNT ,STORAGERATE ,OPERATECNT ,OPERATERATE, EFFICIENCY  ,REPORTDATE   
                            FROM  SSICT_DAILYREPORT_TWINLIFT ";

            DataSet ds = OracleDataTool.ExecuteDataset(ConnectStringOracle.GetInternalTableConnection(), sql);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return ds.Tables[0];
            }
        }

        public static DataTable GetTwinLiftByDate(DateTime reportDate)
        {
            string sql = @"SELECT SCD_ID ,VESSELNAME ,IEFG ,TOTALCNT ,CANSTGOPTCNT  ,CANSTGOPTRATE ,STORAGECNT ,STORAGERATE ,OPERATECNT ,OPERATERATE ,EFFICIENCY ,REPORTDATE   
                            FROM  SSICT_DAILYREPORT_TWINLIFT  WHERE REPORTDATE=to_date(:reportDate,'yyyy-mm-dd')";

            OracleParameter[] para = new OracleParameter[1];
            para[0] = new OracleParameter("reportDate", reportDate);

            DataSet ds = OracleDataTool.ExecuteDataset(ConnectStringOracle.GetInternalTableConnection(), sql, para);

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
