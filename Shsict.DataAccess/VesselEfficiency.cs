using System;
using System.Data;
using System.Data.OracleClient;

using Microsoft.ApplicationBlocks.Data;


namespace Shsict.DataAccess
{
    /// <summary>
    /// 船舶效率
    /// </summary>
    public class VesselEfficiency
    {
        public static DataTable GetVesselEfficiencys()
        {
            string sql = @"SELECT  REPORT_DATE, VSL_CNNAME,QCOPTM ,QCNETTM ,AVGEFF ,ABTHNO                 
                            FROM  SSICT_APP_VESSEL_EFF ";

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

        public static DataTable GetVesselEfficiencyByDate(DateTime reportDate)
        {
            string sql = @"SELECT  REPORT_DATE, VSL_CNNAME,QCOPTM ,QCNETTM ,AVGEFF ,ABTHNO                 
                            FROM  SSICT_APP_VESSEL_EFF 
                            WHERE REPORT_DATE=to_date(:reportDate,'yyyy-mm-dd')";

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
