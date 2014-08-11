using System.Data;
using System.Data.OracleClient;

using Microsoft.ApplicationBlocks.Data;

namespace Shsict.DataAccess
{/// <summary>
    /// VesselPlan 船舶计划
    /// </summary>
    public class OVesselPlan
    {
        public static DataRow GetVesselPlanByID(string vpID)
        {
            string sql = @"SELECT id, VESSEL_NAME, VESSEL_ENGLISH_NAME, VESSEL_TYPE, VOYAGE_NUMBER, Import_Or_Export_Flag, ARRIVE_PLAN_TIME, ARRIVE_ACTUAL_TIME, DEPARTURE_PLAN_TIME, 
                         DEPARTURE_ACTUAL_TIME, BERTH_PLAN, BERTH_ACTUAL, IS_CUSTOMS_CLOSING, STATUS, CSI, CONTAINER_BEGIN_TIME, Container_Deadline, Agency, Port_Of_Call_ID, Is_Active, Remark
                         FROM   V_VESSEL_PLAN
                         WHERE (id = :vpID)";
           
            OracleParameter[] para = new OracleParameter[1];
            para[0] = new OracleParameter("vpID", vpID);

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
       
        public static DataTable GetVesselPlans()
        {
            string sql = @"SELECT id, VESSEL_NAME, VESSEL_ENGLISH_NAME, VESSEL_TYPE, VOYAGE_NUMBER, Import_Or_Export_Flag, ARRIVE_PLAN_TIME, ARRIVE_ACTUAL_TIME, DEPARTURE_PLAN_TIME, 
                         DEPARTURE_ACTUAL_TIME, BERTH_PLAN, BERTH_ACTUAL, IS_CUSTOMS_CLOSING, STATUS, CSI, CONTAINER_BEGIN_TIME, Container_Deadline, Agency, Port_Of_Call_ID, Is_Active, Remark
                         FROM V_VESSEL_PLAN 
                         ORDER BY Container_Begin_Time ASC ,VESSEL_NAME DESC ";

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

