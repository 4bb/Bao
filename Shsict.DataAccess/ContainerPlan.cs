using System.Data;
using System.Data.OracleClient;

using Microsoft.ApplicationBlocks.Data;

namespace Shsict.DataAccess
{
    /// <summary>
    /// 计划受理
    /// </summary>
    public class ContainerPlan
    {
        public static DataRow GetContainerPlanByID(string cID)
        {
            string sql = @"SELECT   ID, VesselVoyage ,OPERATION ,PLANACCEPT ,PlanTime ,PlanAcceptedTime ,planno ,custom
                           FROM  v_container_plan
                           WHERE (ID = :cID)";

            OracleParameter[] para = new OracleParameter[1];
            para[0] = new OracleParameter("cID", cID);

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

        public static DataTable GetContainerPlans()
        {
            string sql = @"SELECT  ID, VesselVoyage ,OPERATION ,PLANACCEPT ,PlanTime ,PlanAcceptedTime ,planno ,custom
                           FROM  v_container_plan ORDER BY ID ";

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

        public static DataTable GetContainerPlans(string custom)
        {
            string sql = @"SELECT  ID, VesselVoyage ,OPERATION ,PLANACCEPT ,PlanTime ,PlanAcceptedTime ,planno ,custom
                           FROM  v_container_plan
                           WHERE (custom = :custom) ";

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
