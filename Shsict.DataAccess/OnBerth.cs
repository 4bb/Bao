using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Text;

namespace Shsict.DataAccess
{
    /// <summary>
    /// 在泊船舶实际及计划毛船时量
    /// </summary>
    public class OnBerth
    {
        public static DataTable GetOnBerths()
        {
            string sql = @"SELECT   VESSELNAME,VESSELTYPE,VOCOPTM ,AMOUNTOFVESSEL ,TARGETVOCTM 
                            FROM  SSICT_APP_ONBERTH_EFF";

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
