using System;
using System.Data;
using System.Data.OracleClient;

using Microsoft.ApplicationBlocks.Data;


namespace Shsict.DataAccess
{
    /// <summary>
    /// 双吊具
    /// </summary>
    public class YardDensity
    {
        public static DataTable GetYardDensitys()
        {
            string sql = @"SELECT YD_ID ,YD_CNTR_STATUS ,YD_SAC_SUM ,YD_YARD_SLOT_SUM ,YD_YARD_SLOT_TOTAL ,round(YD_PCT,5) ,round(YD_DES,5)   
                            FROM  SSICT_YARD_DENSITY ";

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
