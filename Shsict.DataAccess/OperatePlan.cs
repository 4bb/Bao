using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Text;

namespace Shsict.DataAccess
{
    /// <summary>
    /// 出勤人员资质信息
    /// </summary>
    public class OperatePlan
    {
        public static DataTable GetOperatePlans()
        {
            string sql = @"SELECT    SHIFT_DATE ,SHIFT ,TEAMNAME ,OP_ROUTE ,QB ,HG ,FZ , OTHER ,SHIFT_NUM ,ATD_DIFF   
                            FROM SSICT_APP_OPERATEPLAN";

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

    
    }
}

