using System;
using System.Data;
using System.Data.OracleClient;

using Microsoft.ApplicationBlocks.Data;


namespace Shsict.DataAccess
{
    /// <summary>
    /// 昼夜吞吐量
    /// </summary>
    public class DailyReport
    {
        public static DataTable GetDailyReports()
        {
            string sql = @"SELECT  REPORT_DATE,LASTALLDAY_PLAN,LASTALLDAY_ACTUAL,LASTALLDAY_BARGE,LASTALLDAY_SHUTTLE,round(LASTALLDAY_COMPLETERATE,5)
                           ,MONTHLY_PLAN,MONTHLY_TARGET,MONTHLY_ACTUAL,MONTHLY_BARGE,MONTHLY_SHUTTLE,round(MONTHLY_COMPLETERATE,5),round(MONTHLY_PLANCONTAINER,5)
                           ,ANNUAL_PLAN,ANNUAL_ACTUAL,ANNUAL_BARGE,ANNUAL_SHUTTLE,round(ANNUAL_COMPLETERATE,5),round(ANNUAL_PLANCONTAINER,5)
                            FROM  SSICT_DAILY_REPORT_VW ";

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

        public static DataTable GetDailyReportByDate(DateTime reportDate)
        {
            string sql = @"SELECT REPORT_DATE,LASTALLDAY_PLAN,LASTALLDAY_ACTUAL,LASTALLDAY_BARGE,LASTALLDAY_SHUTTLE, round(LASTALLDAY_COMPLETERATE,5)
                           ,MONTHLY_PLAN,MONTHLY_TARGET,MONTHLY_ACTUAL,MONTHLY_BARGE,MONTHLY_SHUTTLE,MONTHLY_COMPLETERATE,round(MONTHLY_PLANCONTAINER,5)
                           ,ANNUAL_PLAN,ANNUAL_ACTUAL,ANNUAL_BARGE,ANNUAL_SHUTTLE, round(ANNUAL_COMPLETERATE,5),round(ANNUAL_PLANCONTAINER,5)
                            FROM  SSICT_DAILY_REPORT_VW  WHERE REPORT_DATE=to_date(:reportDate,'yyyy-mm-dd')";

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
