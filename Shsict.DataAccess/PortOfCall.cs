using System.Data;
using System.Data.OracleClient;

using Microsoft.ApplicationBlocks.Data;

namespace Shsict.DataAccess
{
    /// <summary>
    /// 挂靠港
    /// </summary>
    public class PortOfCall
    {
        public static DataTable GetPortOfCallByID(string pID)
        {
            string sql = @"SELECT ID, CN, EDI ,PortDisplayIndex
                         FROM   v_port_of_call
                         WHERE (ID = :pID) order by PortDisplayIndex";
           

            OracleParameter[] para = new OracleParameter[1];
            para[0] = new OracleParameter("pID", pID);

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

        public static DataTable GetPortOfCalls()
        {
            string sql = @"SELECT ID, CN, EDI ,PortDisplayIndex
                         FROM   v_port_of_call ORDER BY PortDisplayIndex DESC";

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

