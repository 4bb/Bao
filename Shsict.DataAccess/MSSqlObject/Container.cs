using System;
using System.Data;
using System.Data.SqlClient;

using Microsoft.ApplicationBlocks.Data;

/// <summary>
/// Container 集装箱信息
/// </summary>

namespace Shsict.DataAccess
{
    public class Container
    {
        public static DataRow GetContainerByID(int cID)
        {
            string sql = @"SELECT     ID, ContainerNo, ArriveTime, DepartureTime, ArriveType, DepartureType, CustomsClearance, VesselID, ArrivalContainerTime, CustomsClearanceTime, 
                         StowageTime, VesselTime, PlanTime, PlanAcceptedTime, VesselName, VoyageNumber, BillOfLadingNum, ArrivalPortTime, SendPackingListTime, PlanAarrangeTime, AcceptanceNo,
                         IsActive, Remark
                         FROM      [Container]
                         WHERE     (ID = @cID)";

            DataSet ds = SqlHelper.ExecuteDataset(ConnectStringMsSql.GetConnection(), CommandType.Text, sql, new SqlParameter("@cID", cID));

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return ds.Tables[0].Rows[0];
            }
        }

        public static void InsertContainer(int cID, string containerNo, DateTime arriveTime, DateTime departureTime, string arriveType, string departureType, string customsClearance, int vesselID, DateTime arrivalContainerTime, DateTime customsClearanceTime, DateTime stowageTime, DateTime vesselTime, DateTime planTime, DateTime planAcceptedTime, string vesselName, string voyageNumber, string billOfLadingNum, DateTime arrivalPortTime, DateTime sendPackingListTime, DateTime planAarrangeTime, string acceptanceNo, bool isActive, string remark)
        {
            string sql = @"INSERT INTO [Container] 
                            (ContainerNo, ArriveTime, DepartureTime, ArriveType, DepartureType, CustomsClearance, VesselID, ArrivalContainerTime, CustomsClearanceTime, StowageTime, VesselTime, PlanTime, PlanAcceptedTime, VesselName, VoyageNumber, BillOfLadingNum, ArrivalPortTime, SendPackingListTime, PlanAarrangeTime,AcceptanceNo, IsActive, Remark) VALUES 
                            (@containerNo, @arriveTime, @departureTime, @arriveType, @departureType, @customsClearance, @vesselID, @arrivalContainerTime, @arrivalContainerTime, @customsClearanceTime, @stowageTime ,@vesselTime, @planTime, @planAcceptedTime, @vesselName, @voyageNumber, @billOfLadingNum, @arrivalPortTime, @sendPackingListTime, @planAarrangeTime,@acceptanceNo, @isActive, @remark)";

            SqlParameter[] para = { new SqlParameter(),
                                    new SqlParameter("@containerNo", containerNo), 
                                    new SqlParameter("@arriveTime", arriveTime), 
                                    new SqlParameter("@departureTime", departureTime), 
                                    new SqlParameter("@arriveType", arriveType), 
                                    new SqlParameter("@departureType", departureType),
                                    new SqlParameter("@customsClearance", customsClearance),
                                    new SqlParameter("@vesselID", vesselID),
                                    new SqlParameter("@arrivalContainerTime", arrivalContainerTime), 
                                    new SqlParameter("@customsClearanceTime", customsClearanceTime), 
                                    new SqlParameter("@stowageTime", stowageTime), 
                                    new SqlParameter("@vesselTime", vesselTime), 
                                    new SqlParameter("@planTime", planTime), 
                                    new SqlParameter("@planAcceptedTime", planAcceptedTime), 
                                    new SqlParameter("@vesselName", vesselName), 
                                    new SqlParameter("@voyageNumber", voyageNumber), 
                                    new SqlParameter("@billOfLadingNum", billOfLadingNum),
                                    new SqlParameter("@arrivalPortTime", arrivalPortTime),
                                    new SqlParameter("@sendPackingListTime", sendPackingListTime),
                                    new SqlParameter("@planAarrangeTime", planAarrangeTime), 
                                    new SqlParameter("@isActive", isActive),
                                    new SqlParameter("@acceptanceNo", acceptanceNo),
                                    new SqlParameter("@remark", remark), 
                                   };

            SqlHelper.ExecuteNonQuery(ConnectStringMsSql.GetConnection(), CommandType.Text, sql, para);
        }

        public static void UpdateContainer(int cID, string containerNo, DateTime arriveTime, DateTime departureTime, string arriveType, string departureType, string customsClearance, int vesselID, DateTime arrivalContainerTime, DateTime customsClearanceTime, DateTime stowageTime, DateTime vesselTime, DateTime planTime, DateTime planAcceptedTime, string vesselName, string voyageNumber, string billOfLadingNum, DateTime arrivalPortTime, DateTime sendPackingListTime, DateTime planAarrangeTime, string acceptanceNo, bool isActive, string remark)
        {
            string sql = @"UPDATE [Container] SET containerNo = @containerNo, ArriveTime = @arriveTime, DepartureTime=@departureTime, ArriveType = @arriveType, DepartureType = @departureType, CustomsClearance=@customsClearance  VesselID=@vesselID,  ArrivalContainerTime = @arrivalContainerTime, CustomsClearanceTime = @customsClearanceTime, StowageTime = @stowageTime, VesselTime = @vesselTime, PlanTime = @planTime, PlanAcceptedTime=@planAcceptedTime, VesselName=@vesselName, VoyageNumber = @voyageNumber, BillOfLadingNum = @billOfLadingNum, ArrivalPortTime = @arrivalPortTime, SendPackingListTime = @sendPackingListTime, PlanAarrangeTime = @planAarrangeTime AcceptanceNo=@acceptanceNo  WHERE ID = @cID";

            SqlParameter[] para = { new SqlParameter("@cID",cID),
                                    new SqlParameter("@containerNo", containerNo), 
                                    new SqlParameter("@arriveTime", arriveTime), 
                                    new SqlParameter("@departureTime", departureTime), 
                                    new SqlParameter("@arriveType", arriveType), 
                                    new SqlParameter("@departureType", departureType),
                                    new SqlParameter("@customsClearance", customsClearance),
                                    new SqlParameter("@vesselID", vesselID),
                                    new SqlParameter("@arrivalContainerTime", arrivalContainerTime), 
                                    new SqlParameter("@customsClearanceTime", customsClearanceTime), 
                                    new SqlParameter("@stowageTime", stowageTime), 
                                    new SqlParameter("@vesselTime", vesselTime), 
                                    new SqlParameter("@planTime", planTime), 
                                    new SqlParameter("@planAcceptedTime", planAcceptedTime), 
                                    new SqlParameter("@vesselName", vesselName), 
                                    new SqlParameter("@voyageNumber", voyageNumber), 
                                    new SqlParameter("@billOfLadingNum", billOfLadingNum),
                                    new SqlParameter("@arrivalPortTime", arrivalPortTime),
                                    new SqlParameter("@sendPackingListTime", sendPackingListTime),
                                    new SqlParameter("@planAarrangeTime", planAarrangeTime), 
                                    new SqlParameter("@acceptanceNo", acceptanceNo),           
                                    new SqlParameter("@isActive", isActive),
                                    new SqlParameter("@remark", remark), 
                                   };

            SqlHelper.ExecuteNonQuery(ConnectStringMsSql.GetConnection(), CommandType.Text, sql, para);
        }

        public static void DeleteContainer(int cID)
        {
            string sql = "DELETE FROM [Container] WHERE ID = @cID";

            SqlParameter[] para = { new SqlParameter("@cID", cID) };

            SqlHelper.ExecuteNonQuery(ConnectStringMsSql.GetConnection(), CommandType.Text, sql, para);
        }

        public static DataTable GetContainers()
        {
            string sql = @"SELECT ID, ContainerNo, ArriveTime, DepartureTime, ArriveType, DepartureType, CustomsClearance, VesselID, ArrivalContainerTime, CustomsClearanceTime, 
                         StowageTime, VesselTime, PlanTime, PlanAcceptedTime, VesselName, VoyageNumber, BillOfLadingNum, ArrivalPortTime, SendPackingListTime, PlanAarrangeTime, AcceptanceNo,
                         IsActive, Remark 
                         FROM [Container] ORDER BY ID DESC";

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
