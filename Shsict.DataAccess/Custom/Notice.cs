using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.OracleClient;

namespace Shsict.DataAccess
{
    public class Notice
    {
        public static DataRow GetNoticeByID(string nID)
        {
            string sql = @"SELECT NoticeID, NoticeTitle, CreateTime, NoticeContent, IsActive, Remark
                            FROM MobileApp_Notice WHERE (NoticeID = :nID)";

            OracleParameter[] para = new OracleParameter[1];
            para[0] = new OracleParameter("nID", nID);

            DataSet ds = OracleDataTool.ExecuteDataset(ConnectStringOracle.GetTableConnection(), sql, para);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return ds.Tables[0].Rows[0];
            }
        }

        public static DataTable GetNotices()
        {
            string sql = @"SELECT  NoticeID, NoticeTitle, CreateTime, NoticeContent, IsActive, Remark
                            FROM MobileApp_Notice ORDER BY  CreateTime DESC";

            DataSet ds = OracleDataTool.ExecuteDataset(ConnectStringOracle.GetTableConnection(), sql);

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
