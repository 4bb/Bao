using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Text;

namespace Shsict.DataAccess
{            /// <summary>
    /// Favourite 收藏夹
    /// </summary>
    public class MyFavourite
    {
        public static DataRow GetFavouriteByID(string fID)
        {
            string sql = @"SELECT ID, URL, USERNAME, CREATETIME, STATUS, UPDATETIME , OBJECTID , OBJECTCONTENT,OBJECTTYPE, ISACTIVE ,REMARK
                            FROM MOBILEAPP_FAVOURITE WHERE (ID = :fID) ";

            OracleParameter[] para = new OracleParameter[1];
            para[0] = new OracleParameter("fID", fID);

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
        public static void InsertFavourite(string fID, string url, string userName, DateTime createTime, int status, DateTime updateTime, string objectID, string objectContent, string objectType, int isActive, string remark)
        {
            string sql = @"INSERT INTO MOBILEAPP_FAVOURITE
                            (ID, URL, USERNAME, CREATETIME, STATUS, UPDATETIME , OBJECTID, OBJECTCONTENT,OBJECTTYPE , ISACTIVE ,REMARK  )
                            VALUES ( SEQ_MOBILEAPP.Nextval, :url ,:userName ,to_date(:createTime,'yyyy-MM-DD hh24:mi:ss') ,:status ,to_date(:updateTime,'yyyy-MM-DD hh24:mi:ss') ,:objectID ,:objectContent , :objectType, :isActive ,:remark )";

            OracleParameter[] para = new OracleParameter[10];
            para[0] = new OracleParameter("url", url);
            para[1] = new OracleParameter("userName", userName);
            para[2] = new OracleParameter("createTime", createTime.ToString());
            para[3] = new OracleParameter("status", status);
            para[4] = new OracleParameter("updateTime", updateTime.ToString());
            para[5] = new OracleParameter("objectID", objectID);
            para[6] = new OracleParameter("objectContent", objectContent);
            para[7] = new OracleParameter("objectType", objectType);
            para[8] = new OracleParameter("isActive", isActive);
            para[9] = new OracleParameter("remark", remark);

            OracleDataTool.ExecuteNonQuery(ConnectStringOracle.GetTableConnection(), sql, para);

        }

        public static void UpdateFavourite(string fID, string url, string userName, DateTime createTime, int status, DateTime updateTime, string objectID, string objectContent, string objectType, int isActive, string remark)
        {
            string sql = @"UPDATE MOBILEAPP_FAVOURITE SET URL=:url, USERNAME=:userName, CREATETIME=to_date(:createTime ,'yyyy-MM-DD hh24:mi:ss'), STATUS=:status,
                           UPDATETIME=to_date(:updateTime,'yyyy-MM-DD hh24:mi:ss'), OBJECTID=:objectID, OBJECTCONTENT=:objectContent, OBJECTTYPE=:objectType, ISACTIVE=:isActive, REMARK=:remark
                           WHERE ID=:fID";

            OracleParameter[] para = new OracleParameter[11];
            para[0] = new OracleParameter("fID", fID);
            para[1] = new OracleParameter("url", url);
            para[2] = new OracleParameter("userName", userName);
            para[3] = new OracleParameter("createTime", createTime.ToString());
            para[4] = new OracleParameter("status", status);
            para[5] = new OracleParameter("updateTime", updateTime.ToString());
            para[6] = new OracleParameter("objectID", objectID);
            para[7] = new OracleParameter("objectContent", objectContent);
            para[8] = new OracleParameter("objectType", objectType);
            para[9] = new OracleParameter("isActive", isActive);
            para[10] = new OracleParameter("remark", remark);

            OracleDataTool.ExecuteNonQuery(ConnectStringOracle.GetTableConnection(), sql, para);

        }

        public static void DeleteFavourite(string fID)
        {
            string sql = @"DELETE FROM  MOBILEAPP_FAVOURITE WHERE ID=:fID ";

            DataSet ds = OracleDataTool.ExecuteDataset(ConnectStringOracle.GetTableConnection(), sql);

            OracleParameter[] para = new OracleParameter[1];
            para[0] = new OracleParameter("fID", fID);

            OracleDataTool.ExecuteNonQuery(ConnectStringOracle.GetTableConnection(), sql, para);
        }

        public static DataTable GetFavourites()
        {
            string sql = @"SELECT ID, URL, USERNAME, CREATETIME, STATUS, UPDATETIME ,OBJECTID , OBJECTCONTENT ,OBJECTTYPE ,ISACTIVE ,REMARK 
                            FROM  MOBILEAPP_FAVOURITE ORDER BY STATUS DESC, UPDATETIME DESC, CREATETIME DESC";

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
