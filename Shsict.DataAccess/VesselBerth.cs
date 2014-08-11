using System;
using System.Data;
using System.Data.OracleClient;

using Microsoft.ApplicationBlocks.Data;


namespace Shsict.DataAccess
{
    /// <summary>
    /// 靠离泊情况
    /// </summary>
    public class VesselBerth
    {
        public static DataTable GetVesselBerths()
        {
            string sql = @"SELECT  REPORT_DATE,VSL_CNNAME,VBT_PBTHDT,VBT_ABTHDT, VBT_STATUS, VOT_AWKSTTM,  ISLATER
                            FROM  SSICT_DAILYREPORT_BERTH_VW ";

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

        public static DataTable GetVesselBerthByDate(DateTime reportDate)
        {
            string sql = @"SELECT  REPORT_DATE,VSL_CNNAME,VBT_PBTHDT,VBT_ABTHDT, VBT_STATUS, VOT_AWKSTTM,  ISLATER
                            FROM  SSICT_DAILYREPORT_BERTH_VW  WHERE REPORT_DATE=to_date(:reportDate,'yyyy-mm-dd')";

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
