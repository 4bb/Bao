using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.OracleClient;

namespace Shsict.DataAccess
{
    /// <summary>
    /// 箱货用户
    /// </summary>
    public class ContainerPlanUser
    {
        public static DataRow GetContainerPlanUserByID(string username, string userpasswd)
        {
            string sql = @"SELECT   usercd ,username ,userpasswd 
                           FROM  v_container_plan_user
                           WHERE (username = :username) and (userpasswd=:userpasswd)";


            OracleParameter[] para = new OracleParameter[2];
            para[0] = new OracleParameter("username", username);
            para[1] = new OracleParameter("userpasswd", userpasswd);

            DataSet ds = OracleDataTool.ExecuteDataset(ConnectStringOracle.GetViewConnection(), sql, para);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return ds.Tables[0].Rows[0];
            }
        }

        public static DataTable GetContainerPlanUsers()
        {
            string sql = @"SELECT  usercd ,username ,userpasswd 
                           FROM  v_container_plan_user ";

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
