using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.OracleClient;

namespace Shsict.DataAccess
{
    public class TVDangerContainer
    {
        public static DataTable GetTVDangerContainerByID(string planNo)
        {
            string sql = @"SELECT CONTAINERNO, PLANNO
                         FROM   v_Tvdanger_Containers
                         WHERE (PLANNO = :planNo) order by CONTAINERNO DESC";


            OracleParameter[] para = new OracleParameter[1];
            para[0] = new OracleParameter("planNo", planNo);

            DataSet ds = OracleDataTool.ExecuteDataset(ConnectStringOracle.GetViewConnection(), sql, para);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return ds.Tables[0];
            }
        }

        public static DataTable GetTVDangerContainers()
        {
            string sql = @"SELECT CONTAINERNO, PLANNO
                         FROM   v_Tvdanger_Containers ORDER BY CONTAINERNO DESC";

            DataSet ds = OracleDataTool.ExecuteDataset(ConnectStringOracle.GetViewConnection(), sql);


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
