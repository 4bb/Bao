using System;
using System.Data;
using System.Data.SqlClient;

using Microsoft.ApplicationBlocks.Data;

/// <summary>
/// VesselPlan 船舶计划
/// </summary>

namespace Shsict.DataAccess
{
    public class VesselPlan
    {
        public static DataRow GetVesselPlanByID(int vpID)
        {
            string sql = @"SELECT ID, VesselName, VesselEnglishName, VesselType, VoyageNumber, ImportOrExportFlag, ArrivePlanTime, ArriveActualTime, DeparturePlanTime, 
                         DepartureActualTime, BerthPlan, BerthActual, IsCustomsClosing, Status, CSI, ContainerBeginTime, ContainerDeadline, Agency, PortOfCallID, IsActive, Remark
                         FROM VesselPlan
                         WHERE (ID = @vpID)";

            DataSet ds = SqlHelper.ExecuteDataset(ConnectStringMsSql.GetConnection(), CommandType.Text, sql, new SqlParameter("@vpID", vpID));

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return ds.Tables[0].Rows[0];
            }
        }

        public static void InsertVesselPlan(int vpID, string vesselName, string vesselEnglishName, int vesselType, string voyageNumber, string importOrExportFlag, DateTime arrivePlanTime, DateTime? arriveActualTime, DateTime departurePlanTime, DateTime? departureActualTime, string berthPlan, string berthActual, bool isCustomsClosing, int status, string csi, DateTime containerBeginTime, DateTime containerDeadline, string agency, int portOfCallID, bool isActive, string remark)
        {
            string sql = @"INSERT INTO [VesselPlan] 
                            (VesselName, VesselEnglishName, VesselType, VoyageNumber, ImportOrExportFlag, ArrivePlanTime, ArriveActualTime, DeparturePlanTime, DepartureActualTime, BerthPlan, BerthActual, IsCustomsClosing, Status, CSI, ContainerBeginTime, ContainerDeadline, Agency, PortOfCallID, IsActive, Remark) VALUES 
                            (@vesselName, @vesselEnglishName, @vesselType, @voyageNumber, @importOrExportFlag, @arrivePlanTime, @arriveActualTime, @departurePlanTime, @departureActualTime, @berthPlan, @berthActual, @isCustomsClosing, @status, @csi, @containerBeginTime, @containerDeadline, @agency, @portOfCallID, @isActive, @remark)";

            SqlParameter[] para = { new SqlParameter(),
                                    new SqlParameter("@vesselName", vesselName), 
                                    new SqlParameter("@vesselEnglishName", vesselEnglishName), 
                                    new SqlParameter("@vesselType", vesselType), 
                                    new SqlParameter("@voyageNumber", voyageNumber), 
                                    new SqlParameter("@importOrExportFlag", importOrExportFlag), 
                                    new SqlParameter("@arrivePlanTime", arrivePlanTime),
                                    new SqlParameter("@arriveActualTime", arriveActualTime.HasValue ? (object)arriveActualTime.Value : (object)DBNull.Value),
                                    new SqlParameter("@departurePlanTime", departurePlanTime),
                                    new SqlParameter("@departureActualTime", departureActualTime.HasValue ? (object)departureActualTime.Value : (object)DBNull.Value), 
                                    new SqlParameter("@berthPlan", berthPlan), 
                                    new SqlParameter("@berthActual", berthActual), 
                                    new SqlParameter("@isCustomsClosing", isCustomsClosing), 
                                    new SqlParameter("@status", status), 
                                    new SqlParameter("@csi", csi), 
                                    new SqlParameter("@containerBeginTime", containerBeginTime), 
                                    new SqlParameter("@containerDeadline", containerDeadline), 
                                    new SqlParameter("@agency", agency), 
                                    new SqlParameter("@portOfCallID", portOfCallID), 
                                    new SqlParameter("@isActive", isActive),
                                    new SqlParameter("@remark", remark)};

            SqlHelper.ExecuteNonQuery(ConnectStringMsSql.GetConnection(), CommandType.Text, sql, para);
        }

        public static void UpdateVesselPlan(int vpID, string vesselName, string vesselEnglishName, int vesselType, string voyageNumber, string importOrExportFlag, DateTime arrivePlanTime, DateTime? arriveActualTime, DateTime departurePlanTime, DateTime? departureActualTime, string berthPlan, string berthActual, bool isCustomsClosing, int status, string csi, DateTime containerBeginTime, DateTime containerDeadline, string agency, int portOfCallID, bool isActive, string remark)
        {
            string sql = @"UPDATE [VesselPlan] SET VesselName = @vesselName, VesselEnglishName = @vesselEnglishName, VesselType=@vesselType, VoyageNumber=@voyageNumber, ImportOrExportFlag = @importOrExportFlag, ArrivePlanTime = @arrivePlanTime, ArriveActualTime = @arriveActualTime, DeparturePlanTime = @departurePlanTime,DepartureActualTime = @departureActualTime
                                BerthPlan = @berthPlan, BerthActual=@berthActual, IsCustomsClosing=@isCustomsClosing, CSI=@csi, ContainerBeginTime=containerBeginTime, ContainerDeadline=@containerDeadline  Status=@status, Agency=@agency, PortOfCallID=@portOfCallID, IsActive=@isActive, Remark=@remark WHERE ID = @vpID";

            SqlParameter[] para = { new SqlParameter("@vpID",vpID),
                                    new SqlParameter("@vesselName", vesselName), 
                                    new SqlParameter("@vesselEnglishName", vesselEnglishName), 
                                    new SqlParameter("@vesselType", vesselType), 
                                    new SqlParameter("@voyageNumber", voyageNumber), 
                                    new SqlParameter("@importOrExportFlag", importOrExportFlag), 
                                    new SqlParameter("@arrivePlanTime", arrivePlanTime),
                                    new SqlParameter("@arriveActualTime", arriveActualTime.HasValue ? (object)arriveActualTime.Value : (object)DBNull.Value),
                                    new SqlParameter("@departurePlanTime", departurePlanTime),
                                    new SqlParameter("@departureActualTime", departureActualTime.HasValue ? (object)departureActualTime.Value : (object)DBNull.Value), 
                                    new SqlParameter("@berthPlan", berthPlan), 
                                    new SqlParameter("@berthActual", berthActual), 
                                    new SqlParameter("@isCustomsClosing", isCustomsClosing), 
                                    new SqlParameter("@status", status), 
                                    new SqlParameter("@csi", csi), 
                                    new SqlParameter("@containerBeginTime", containerBeginTime), 
                                    new SqlParameter("@containerDeadline", containerDeadline), 
                                    new SqlParameter("@agency", agency), 
                                    new SqlParameter("@PortOfCallID", portOfCallID), 
                                    new SqlParameter("@isActive", isActive),
                                    new SqlParameter("@remark", remark)};

            SqlHelper.ExecuteNonQuery(ConnectStringMsSql.GetConnection(), CommandType.Text, sql, para);
        }

        public static void DeleteVesselPlan(int vpID)
        {
            string sql = "DELETE FROM [VesselPlan] WHERE ID = @vpID";

            SqlParameter[] para = { new SqlParameter("@vpID", vpID) };

            SqlHelper.ExecuteNonQuery(ConnectStringMsSql.GetConnection(), CommandType.Text, sql, para);
        }

        public static DataTable GetVesselPlans()
        {
            string sql = @"SELECT ID, VesselName, VesselEnglishName, VesselType, VoyageNumber, ImportOrExportFlag, ArrivePlanTime, ArriveActualTime, DeparturePlanTime, 
                         DepartureActualTime, BerthPlan, BerthActual, IsCustomsClosing, Status, CSI, ContainerBeginTime, ContainerDeadline, Agency, PortOfCallID, IsActive, Remark 
                         FROM [VesselPlan] ORDER BY ID DESC";

            DataSet ds = SqlHelper.ExecuteDataset(ConnectStringMsSql.GetConnection(), CommandType.Text, sql);

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
