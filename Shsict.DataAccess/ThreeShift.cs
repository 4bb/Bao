using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Text;

namespace Shsict.DataAccess
{
    public class ThreeShift
    {
        public static DataRow GetThreeShiftByID(string sID)
        {
            string sql = @"SELECT  SHIFTDATE, SHIFT, SHIFTPLAN, SHIFTACTUAL, SHIFTCOMPLETERATE 
                            FROM SSICT_APP_THREESHIFT_VW WHERE (ID = :tID)";

            OracleParameter[] para = new OracleParameter[1];
            para[0] = new OracleParameter("SID", sID);

            DataSet ds = OracleDataTool.ExecuteDataset(ConnectStringOracle.GetInternalTableConnection(), sql, para);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return ds.Tables[0].Rows[0];
            }
        }

        public static DataTable GetThreeShifts()
        {
            string sql = @"SELECT  SHIFTDATE, SHIFT, SHIFTPLAN, SHIFTACTUAL, round(SHIFTCOMPLETERATE,5) 
                            FROM  SSICT_APP_THREESHIFT_VW";

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

        public static DataTable GetThreeShiftByDate(DateTime shiftDate)
        {
            string sql = @"SELECT  SHIFTDATE, SHIFT, SHIFTPLAN, SHIFTACTUAL, SHIFTCOMPLETERATE 
                            FROM  SSICT_APP_THREESHIFT_VW  WHERE SHIFTDATE=to_date(:shiftDate,'yyyy-mm-dd')";

            OracleParameter[] para = new OracleParameter[1];
            para[0] = new OracleParameter("shiftDate", shiftDate);

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
