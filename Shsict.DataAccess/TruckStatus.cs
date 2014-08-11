using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Text;

namespace Shsict.DataAccess
{
    /// <summary>
    /// 单车运行周期
    /// </summary>
    public class TruckStatus
    {
        public static DataTable GetTruckStatus()
        {
            string sql = @"SELECT    TRUCKNO ,COMPLETETRUCKNUM ,AVEPERIOD ,CURRENTINSTRUCTION ,TOLOC1,TOLOC2,STATUS,STOPFG
                            FROM  SSICT_APP_TRUCKSTATUS";

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
