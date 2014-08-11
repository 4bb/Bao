using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Text;

namespace Shsict.DataAccess
{    /// <summary>
    /// 直装直提
    /// </summary>
    public class TVDangerPlan
    {

        public static DataRow GetTVDangerPlanByID(string tID)
        {
            string sql = @"SELECT   ID, PLANNO ,CUSTOM ,VESSELVOYAGE ,ARRIVE_PLAN_TIME ,DEPARTURE_PLAN_TIME ,TVDATE ,EXACTTVDATE
                           FROM  V_TVDANGER_PLAN  
                           WHERE (ID = :tID)";

            OracleParameter[] para = new OracleParameter[1];
            para[0] = new OracleParameter("tID", tID);

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

        public static DataTable GetTVDangerPlans()
        {
            string sql = @"SELECT   ID, PLANNO ,CUSTOM ,VESSELVOYAGE ,ARRIVE_PLAN_TIME ,DEPARTURE_PLAN_TIME ,TVDATE ,EXACTTVDATE
                           FROM  V_TVDANGER_PLAN ORDER BY TVDATE Desc ";

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

        public static DataTable GetTVDangerPlans(string custom)
        {
            string sql = @"SELECT   ID, PLANNO ,CUSTOM ,VESSELVOYAGE ,ARRIVE_PLAN_TIME ,DEPARTURE_PLAN_TIME ,TVDATE ,EXACTTVDATE
                           FROM  V_TVDANGER_PLAN  
                           WHERE (CUSTOM = :custom) ORDER BY TVDATE Desc";

            OracleParameter[] para = new OracleParameter[1];
            para[0] = new OracleParameter("custom", custom);

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

    }
}


