
using System.Data;
using System.Data.OracleClient;

using Microsoft.ApplicationBlocks.Data;

namespace Shsict.DataAccess
{
    /// <summary>
    /// 用户
    /// </summary>
    public class InternalUser
    {
        public static DataTable GetInternalUsers()
        {
            string sql = @"SELECT SUR_USERACCOUNT ,SUR_PASSWORD ,SUR_DISPLAYNAME ,SUR_DESCRIPTION ,SUR_CREATETIME , SUR_UPDATETIME ,SUR_GROUP ,SUR_STATUS ,SUR_ERRORCOUNT ,SUR_ISLOOKED
                            FROM SYS_USER";

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

        public static DataTable GetInternalUserByUserName(string userAccount)
        {
            string sql = @"SELECT SUR_USERACCOUNT ,SUR_PASSWORD ,SUR_DISPLAYNAME ,SUR_DESCRIPTION ,SUR_CREATETIME , SUR_UPDATETIME ,SUR_GROUP ,SUR_STATUS ,SUR_ERRORCOUNT ,SUR_ISLOOKED
                            FROM SYS_USER Where  SUR_USERACCOUNT = :userAccount";

            OracleParameter[] para = new OracleParameter[1];
            para[0] = new OracleParameter("userAccount", userAccount);

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
        public static DataTable GetUserResourceByUserName(string userName)
        {
            string sql = @"SELECT SUR_USERACCOUNT ,SUR_RESOURCECODE 
                            FROM SYS_USER_RESOURCE  Where  SUR_USERACCOUNT = :userName";

            OracleParameter[] para = new OracleParameter[1];
            para[0] = new OracleParameter("userName", userName);

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
